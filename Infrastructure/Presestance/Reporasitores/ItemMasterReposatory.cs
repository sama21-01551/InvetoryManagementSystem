using DomainLayer.Contracs;
using InvetoryManagementSystem;
using InvetoryManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;
using System.Linq.Expressions;

namespace Persistence.Reporasitores
{
    public class ItemMasterReposator: GenaricReporasatories<ItemMaster,int>  , IItemMasterReposatory
    {
        
        private readonly InventoryManagementSystemContext _dbcontext;
        public ItemMasterReposator(InventoryManagementSystemContext dbContext) : base(dbContext)
        {
          _dbcontext = dbContext;
        }

        //public async Task<ItemSerialNumber> findserialAsync(int serial)
        //{
        //  //  var item=_dbcontext.FindAsync<ItemMaster>(serial==item)
        //    return await _dbcontext.FindAsync<ItemSerialNumber>(i => i.ItemId== serial);
        //}

        public async Task<ItemMaster?> GetByCodeAsync(int code)
        {
            return await   _dbcontext.Set<ItemMaster>().FirstOrDefaultAsync(i => i.ItemCode == code);
        }

        public  async Task<ItemMaster?> GetByNameAsync(string name)
        {
            return await _dbcontext.Set<ItemMaster>().FirstOrDefaultAsync(i => i.ItemName == name);

        }

        public async Task<IEnumerable< ItemMaster>> GetlAsync(Expression<Func<ItemMaster, bool>> predicate)
        {
        var entity= await _dbcontext.Set<ItemMaster>().Where(predicate).ToListAsync();
            return entity;
           
        }

        public async Task<List<int>> SerializedAsync()
        {
          return await _dbcontext.Set<ItemSerialNumber>().Select(i=>i.ItemId).ToListAsync();  
           
        }

        //public async Task<IEnumerable<ItemSerialNumber>> IsSerializedAsync(Expression<Func<ItemSerialNumber, bool>> predicate)
        //{
        //  var isserialized=await _dbcontext.Set<ItemSerialNumber>().Where(predicate).ToListAsync();
        //    return isserialized;
        //}



        //public async Task<IEnumerable<ItemSerialNumber>> IsSerializedAsync(ItemMaster serial) //serialnumber in itemserialnumber   select* from serialnumber , itemmasteer where i.itemid== s.itemmaster
        //{
        //    var serialized =await _dbcontext.Set<ItemSerialNumber>().(from i in ItemSerialNumber select new {i.})
        //    return serialized;



        //        }

        //public async Task<ItemSerialNumber> removebyitemid(int serial)
        //{
        //    return await _dbcontext.ItemSerialNumbers.FirstOrDefaultAsync(x => x.ItemId == serial);
        //}
    }
}

