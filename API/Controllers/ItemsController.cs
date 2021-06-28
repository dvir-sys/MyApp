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
            List<TaskItem> items = await _context.TaskItems.Where(item => (!(item.IsCompleted))).ToListAsync();
            List<ItemDto> itemDtos = new List<ItemDto>();
            items.ForEach(item => itemDtos.Add(new ItemDto { Caption = item.Caption }));
            return itemDtos;
        }
        
        [Route("/add-item/")]
        [HttpPost()]
        //[HttpPost("add-item")]
        public async Task<ActionResult<ItemDto>> CreateNewItem(NewItemDto itemDto)
        {
            var item = new TaskItem
            {
                Caption = itemDto.Caption,
                ListId = itemDto.ListId,
                IsCompleted = false
            };

            _context.TaskItems.Add(item);
            await _context.SaveChangesAsync();

            return new ItemDto
            {
                Caption = itemDto.Caption
            };
            //return NoContent();
        }

        
        [Route("/edit-item/")]
        [HttpPut()]
        //[HttpPut("edit-item")]
        public async Task<ActionResult> EditItem(EditItemDto itemDto)
        {
            TaskItem item = await _context.TaskItems.FindAsync(itemDto.Id);
            
            item.IsCompleted = itemDto.IsCompleted;

            _context.TaskItems.Update(item);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}