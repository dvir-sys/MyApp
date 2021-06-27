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
    public class ItemsController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ItemsController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }


        [HttpGet]
        // api/items
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetAllActiveItems()
        {
            List<TaskItem> items = await _context.TaskItems.Where(item => !(item.IsCompleted)).ToListAsync();
            List<ItemDto> itemDtos = new List<ItemDto>();
            items.ForEach(item => itemDtos.Add(new ItemDto { Caption = item.Caption }));
            return itemDtos;
        }





    }
}