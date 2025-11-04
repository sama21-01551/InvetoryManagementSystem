using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IRecivingOrderService
    {
        Task<ReceivingOrderDTO> CreateRecivingOrder(ReceivingOrderDTO receivedto);  //create recivingorder
        Task<ReceivingOrderDTO> GetPrice(int recivingorderid); //getprice
        Task<SupplierDTO> GetSupplierById(int recivingorderid);                    //getsupplierid 
        Task<StoreDTO> GetStoreById( int recivingorderid);             //get storeid
                    




    }
}
