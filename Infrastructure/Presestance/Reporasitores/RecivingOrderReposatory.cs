using DomainLayer.Contracs;
using InvetoryManagementSystem;
using InvetoryManagementSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Reporasitores
{
 public   class RecivingOrderReposatory : GenaricReporasatories<ReceivingOrder, int>, IReceivingOrderReoisatory
    {

      
        private readonly InventoryManagementSystemContext _dbcontext;
        public RecivingOrderReposatory(InventoryManagementSystemContext dbContext) : base(dbContext)
        {
            _dbcontext = dbContext;
        }
      


        public async Task<ReceivingOrder> CreateRecivingOrder(ReceivingOrder receivingOrder)
        {
              await _dbcontext.ReceivingOrders.AddAsync(receivingOrder);
         
        //   await _dbcontext.SaveChangesAsync();

            return receivingOrder;
        }

        public async Task<int?> GetPrice(int ReceivingOrderid)
        {
            return await _dbcontext.Set<ReceivingOrder>().Where(e => e.ReceivingOrderId == ReceivingOrderid).Select(e=>e.TotalAmount ??0).FirstOrDefaultAsync();
       
        }
        public async Task<int> GetStoreById(int recivingorderid)
        {
          return await _dbcontext.ReceivingOrders.Where(e=>e.ReceivingOrderId == recivingorderid).Select(e=>e.StoreId).FirstOrDefaultAsync();
        }

        public async Task<int> GetSupplierById(int recivingorderid)
        {
           return await _dbcontext.ReceivingOrders.Where(e=>e.ReceivingOrderId== recivingorderid).Select(e=>e.SupplierId).FirstOrDefaultAsync();
        }

        

        //public async Task<Supplier> GetSupplierById(int supplierId)
        //{
        //    return await _dbcontext.Set<Supplier>().FirstOrDefaultAsync(e => e.SupplierId == supplierId);
        //}


        //public async Task<Store> GetStoreId(int storeId)
        //{
        //    return await _dbcontext.Set<store>().FirstOrDefaultAsync(e => e.StoreId == storeId);
        //}




    }
}
