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
    [Route("api/[controller]")]

    public class SerialNumberController(IServiceManager servicemanager) : ControllerBase
    {
        [HttpGet] //get all items
        public async Task<ActionResult<IEnumerable<SerialNumberDTO>>> GetAllItems()
        {
            var serialnumer = await servicemanager.serialservice.GetAllSerialsAsync();
            return Ok(serialnumer);
        }
        [HttpPost]
        public async Task<ActionResult<SerialNumberDTO>> AddSerialNumber(SerialNumberDTO serialnum)
        {

            await servicemanager.serialservice.AddSerialNumber(serialnum);
            return Ok("Item add successfully");
        }
        [HttpDelete ]
        public async Task<ActionResult<SerialNumberDTO>> Delete(int id)
        {
            await servicemanager.serialservice.Delete(id);
            return Ok("Deleted Serial Number ");

        }
        [HttpGet ("serialId/{serialId:int}") ]
        public async Task<ActionResult<SerialNumberDTO>> GetBySerialId(int serialId)
        {
         var item  = await servicemanager.serialservice.GetBySerialIdAsync(serialId);
            return Ok(item);


        }
        [HttpGet("serialForStatus/{serialForStatus:int}")]
        public async Task<ActionResult<SerialNumberDTO>> GetSerialStatus(int serialForStatus)
        {
            var item = await servicemanager.serialservice.GetBySerialIdAsync(serialForStatus);
            return Ok(item.SerialStatus);


        }

    }
}
