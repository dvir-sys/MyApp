using API.Data;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class TodoListController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public TodoListController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoList>>> GetAllLists(){
            return await _context.TodoLists.ToListAsync();
        }

        [Route("/lists/:id")]
        [HttpGet]
         public async Task<ActionResult<TodoList>> GetListById(int id){
            return await _context.TodoLists.FindAsync(id);
         }

        [Route("/lists/:id")]
        [HttpPut()]
        //[HttpPost("updateList")]
        public async Task<ActionResult> EditListById(int id, TodoListDto listDto){
            if (id == -1){
                await CreateNewList(listDto);
            }else{
                TodoList list = await _context.TodoLists.FindAsync(id);
                
                list.url = listDto.url;
                list.title = listDto.title;
                list.description = listDto.description;
                list.color = listDto.color;
                list.image = listDto.image;

                _context.TodoLists.Update(list);
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }

        private async Task<ActionResult<TodoListDto>> CreateNewList(TodoListDto listDto)
        {
            var list = new TodoList
            {
                url = listDto.url,
                tasks = new List<TaskItem>(),
                title = listDto.title,
                description = listDto.description,
                color = listDto.color,
                image = listDto.image
            };

            _context.TodoLists.Add(list);
            await _context.SaveChangesAsync();

            return new TodoListDto
            {
                url = list.url,
                tasks = list.tasks,
                title = list.title,
                description = list.description,
                color = list.color,
                image = list.image
            };
        }
         
        /*
        [HttpGet]
        // api/todoList
        
        public string GetAllLists([FromQuery] string startsWith)
        {
            return "C";
        }
      
    */



    }
}