using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class HomeController : BaseApiController
    {
        private readonly DataContext _context;
        public HomeController(DataContext context){
            _context = context;
        }


        
        [HttpGet]
        public async Task<string> GetHomeDataAsync()
        {
            int totalItemsCount = await _context.TaskItems.CountAsync();
            return "{\"lists\":\"1\", \"todo\":\"1\", \"active\":\"1\"}";
        }
      
    



    }
}