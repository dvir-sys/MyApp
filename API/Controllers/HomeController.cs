using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class HomeController : BaseApiController
    {
        public HomeController(){

        }


        
        [HttpGet]
   
        
        public string GetHomeData()
        {
            return "{\"lists\":\"1\", \"todo\":\"1\", \"active\":\"1\"}";
        }
      
    



    }
}