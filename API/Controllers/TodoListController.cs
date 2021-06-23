using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class TodoListController : BaseApiController
    {
        public TodoListController(){

        }


        
        [HttpGet]
        // api/todoList
        
        public string GetAllLists([FromQuery] string startsWith)
        {
            return "C";
        }
      
    



    }
}