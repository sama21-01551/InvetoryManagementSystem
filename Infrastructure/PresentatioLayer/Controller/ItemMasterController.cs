using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentatioLayer.Controller
{
    [ApiController]
    [Route ("api/[controller]")]
    public class ItemMasterController (IServiceManager servicemanager)  :ControllerBase
    {
        //get all
        [HttpGet]
        public async Task< ActionResult<IEnumerable<ItemMasterDTO>>> GetAllItems() {
        
   var items= await  servicemanager.itemservice.GetAllItems();
            return Ok(items);
        }

        //get by id
        [HttpGet("id/{id:int}")]
        public async Task<ActionResult<ItemMasterDTO>> GetById(int id)
        {
            var items = await servicemanager.itemservice.GetItemById(id);
            return Ok(items);

        }

        //get by name
        [HttpGet("name/{name}")]
        public async Task<ActionResult<ItemMasterDTO>>GetByName(string name)
        {
            var itemname= await servicemanager.itemservice.GetByNameAsync(name);
            return Ok(itemname);

        }
        //get by code 
        [HttpGet("code/{code:int}")]
        public async Task<ActionResult<ItemMasterDTO>> GetByCode(int code)
        {
            var items = await servicemanager.itemservice.GetByItemCode(code);
            return Ok(items);

        }
        //add item 
        [HttpPost]
        public async Task<ActionResult> add_newitem(ItemMasterDTO item)
        {
             await servicemanager.itemservice.AddItem(item);
            return Ok("Item added successfully");
        }


        //update 



        //delete

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {

             await servicemanager.itemservice.Delete(id);
            return Ok("Item deleted successfully");

        }

        [HttpPut("{itemdto}")]
        public async Task<ActionResult> Update(int itemdto)
        {
            await servicemanager.itemservice.Update(itemdto);
            return Ok(" updated ");

        }

    }
}
