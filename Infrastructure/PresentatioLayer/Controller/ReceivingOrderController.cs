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
  public  class ReceivingOrderController(IServiceManager servicemanager):ControllerBase
    {
        [HttpGet("{id:int}")]    //get price
        public async Task<ActionResult<ReceivingOrderDTO>> GetPrice(int receiveorderid)
        {
            var receive = await servicemanager.recivingorderservice.GetPrice(receiveorderid);
            return Ok(receive);

        }
        // create ReceivingOrder
        [HttpPost]
        public async Task<ActionResult<ReceivingOrderDTO>> CreateRecivingOrder(ReceivingOrderDTO receivedto)
        {
            var createe=await servicemanager.recivingorderservice.CreateRecivingOrder(receivedto);

            return Ok(createe);
        }





        //getstore by id
        [HttpGet("{idforstoe:int}")]
        public async Task<ActionResult<StoreDTO>> GetStoreById(int recivingorderid)
        {
            var store= await servicemanager.recivingorderservice.GetStoreById(recivingorderid);
            return Ok(store);
        }
        //get supplier by id
        [HttpGet("{idforsupplier:int}")]
        public async Task<ActionResult<StoreDTO>> GetSupplierById(int recivingorderid)
        {
            var supplier = await servicemanager.recivingorderservice.GetSupplierById(recivingorderid);
            return Ok(supplier);
        }
        //get price






    }
}
