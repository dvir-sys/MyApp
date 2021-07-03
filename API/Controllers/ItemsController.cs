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
            items.ForEach(item => itemDtos.Add(new ItemDto {Id = item.Id, Caption = item.Caption }));
            return itemDtos;
        }

        //[Route("/active-items-count/")]
        [HttpGet("active-items-count")]
        public async Task<ActionResult<int>> GetActiveItemsCount(){
            return await _context.TaskItems.Where(item => (!(item.IsCompleted))).CountAsync();
        }

        //[Route("/count/")]
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetAllItemsCount(){
            return await _context.TaskItems.CountAsync();
        }

        //[Route("/from-list/:id/")]
        [HttpGet("from-list/{id}")]
        public async Task<ActionResult<IEnumerable<ListItemDto>>> GetItemsByListId(int id){
            /*var items = _context.TaskItems.AsQueryable();
            items = items.Where(item => item.ListId.Equals(listId));
            return await items.Select(item => )*/
            
            return await _context.TaskItems.Where(item => (item.ListId.Equals(id)))
                .Select(item => new ListItemDto{
                    Id = item.Id,
                    Caption = item.Caption,
                    ListId = item.ListId,
                    IsCompleted = item.IsCompleted
                }).ToListAsync();
        }
        
        //[Route("")]
        [HttpPost("add/")]
        //[HttpPost("add-item")]
        public async Task<ActionResult<ItemDto>> CreateNewItem(NewItemDto itemDto)
        {
            //Console.WriteLine(itemDto.ToString());
            var item = new TaskItem
            {
                Caption = itemDto.Caption,
                ListId = itemDto.ListId,
                IsCompleted = false/*,
                TodoList = itemDto.TodoList*/
            };

            _context.TaskItems.Add(item);
            await _context.SaveChangesAsync();

            return new ItemDto
            {
                Id = item.Id,
                Caption = itemDto.Caption
            };
            //return NoContent();
        }

        
        //[Route("/edit-item/")]
        [HttpPut("complete/")]
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