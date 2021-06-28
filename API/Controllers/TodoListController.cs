using API.Data;
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