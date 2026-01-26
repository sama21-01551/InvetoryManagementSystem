using Microsoft.AspNetCore.Authorization;
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
        // get all
             [HttpGet ("AllItems")]
        [Authorize]
             public async Task<ActionResult<IEnumerable<ItemMasterDTO>>> GetAllItems()
        {

            var items = await servicemanager.itemservice.GetAllItems();
            return Ok(items);
        }

        [HttpGet("pagenumber/{pagenumber:int}")]
        [Authorize(Roles ="SuperAdmin")]
        public async Task<ActionResult<IEnumerable<ItemMasterDTO>>> GetwithPagination(int pagenumber)
        {

            var items = await servicemanager.itemservice.GetwithpaginationAsync(pagenumber);
          //  return Ok(items,currentpage);
          return Ok(items);
        }


        [HttpGet("Serialized")]
        public async Task<ActionResult<IEnumerable<ItemMasterDTO>>> GetallserializedAsync()
        {

            var items = await servicemanager.itemservice.GetallserializedAsync();
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
        public async Task<ActionResult> AddNewItem(ItemMasterDTO item)
        {
           var ItemId =  await servicemanager.itemservice.AddItem(item);
            await servicemanager.serialservice.AddSerialNumber(new SerialNumberDTO { ItemId= ItemId });
          
            //await servicemanager.SavechangesAsync();
            return Ok(new
            {
                message = "Item added successfully",
                ItemId= ItemId
            });
        }
        //add 
        //public async Task<ActionResult> addd(ItemMasterDTO item) 
        //{
        //    var itemid = await servicemanager.itemservice.AddItem(item);
        //    await

        //}

        //update 



        //delete

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await servicemanager.itemservice.deletByAsync(id);
            // await servicemanager.serialservice.Delete(id);
            //  await servicemanager.itemservice.Delete(id);
            return Ok(new
            {
                message = "item deleted "
                

            });


        }

        [HttpPut("{itemdto}")]
        public async Task<ActionResult> Update(int itemdto ,[FromBody]ItemMasterDTO item)
        {
            await servicemanager.itemservice.Update(itemdto ,item);
            return Ok(item);

        }

    }
}
