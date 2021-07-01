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

        public TodoListController(DataContext context, IMapper mapper1)
        {
            _mapper = mapper1;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoList>>> GetAllLists(){
            return await _context.TodoLists.ToListAsync();
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetListsCount(){
            return await _context.TodoLists.CountAsync();
        }

        //[Route("/:id")]
        [HttpGet("{id}")]
         public async Task<ActionResult<TodoList>> GetListById(int id){
            return await _context.TodoLists.FindAsync(id);
         }

        //[Route("/TodoList/:id")]
        //[HttpPut("{id}")]
        //[HttpPost("updateList")]
        [HttpPut]
        public async Task<ActionResult<int>> EditListById(/*int id,*/ TodoListDto listDto){
            int id = listDto.id;
            if (id == -1){
                return await CreateNewList(listDto);
            }else{
                TodoList list = await _context.TodoLists.FindAsync(id);
                
                list.url = listDto.url!=null ? listDto.url : "";
                list.title = listDto.title!=null ? listDto.title : "";
                list.description = listDto.description!=null ? listDto.description : "";
                list.color = listDto.color!=null ? listDto.color : "";
                list.image = listDto.image!=null ? listDto.image : "";

                _context.TodoLists.Update(list);
                await _context.SaveChangesAsync();
            }
            return Ok(id);
        }

        private async Task<ActionResult<int>> CreateNewList(TodoListDto listDto)
        {
            var list = new TodoList
            {
                //url = listDto.url,
                tasks = new List<TaskItem>(),
                url = listDto.url!=null ? listDto.url : "",
                title = listDto.title!=null ? listDto.title : "",
                description = listDto.description!=null ? listDto.description : "",
                color = listDto.color!=null ? listDto.color : "",
                image = listDto.image!=null ? listDto.image : "",
            };

            await _context.TodoLists.AddAsync(list);
            await _context.SaveChangesAsync();

            return Ok(list.Id);
            /*new TodoListDto
            {
                url = list.url,
                items = list.tasks,
                title = list.title,
                description = list.description,
                color = list.color,
                image = list.image
            };*/
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