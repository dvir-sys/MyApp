using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Entities;

namespace API.DTOs
{
    public class ListEditDto
    {
        public string url { get; set; }
        public string title { get; set; }
        public string description{ get; set; }
        public string color { get; set; }
        public string image{ get; set; }
    }
}