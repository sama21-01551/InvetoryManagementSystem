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
[Route("api/[controller]")]
  public  class StockBalaneController(IServiceManager servicemanager) : ControllerBase
    {
        [Authorize]
        //get all
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StokBalancDTO>>> GetAllItems()
        {

            var items = await servicemanager.Stockbalanceservice.AvailableQuantatyAsync();
            return Ok(items);
        }

    }
}
