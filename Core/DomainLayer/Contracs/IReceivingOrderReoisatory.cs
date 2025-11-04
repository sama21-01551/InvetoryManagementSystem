using InvetoryManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contracs
{
    public interface IReceivingOrderReoisatory
    {
        Task<int> GetSupplierById(int receivingorderid);
        //createreciving order
        Task<ReceivingOrder> CreateRecivingOrder(ReceivingOrder receivingOrder);
        //  get all reciving order
        // Task<IEnumerable<ReceivingOrder>> GetAllRecivingOrder();       exist in generic 
        //get by reciving order id                                        exist in generic  
        //get price(reciving order id) 
        Task<int?> GetPrice(int recivingorderid);
        //get supplier id for the reciving order(supplier id)
        //get store id for the reciving order(store id)
        Task<int> GetStoreById(int recivingorderid);

    }
}
