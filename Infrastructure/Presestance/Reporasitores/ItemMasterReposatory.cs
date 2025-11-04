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

namespace Persistence.Reporasitores
{
    public class ItemMasterReposator: GenaricReporasatories<ItemMaster,int>  , IItemMasterReposatory
    {
        
        private readonly InventoryManagementSystemContext _dbcontext;
        public ItemMasterReposator(InventoryManagementSystemContext dbContext) : base(dbContext)
        {
          _dbcontext = dbContext;
        }


      
        public async Task<ItemMaster?> GetByCodeAsync(int code)
        {
            return await   _dbcontext.Set<ItemMaster>().FirstOrDefaultAsync(i => i.ItemCode == code);
        }

        public  async Task<ItemMaster?> GetByNameAsync(string name)
        {
            return await _dbcontext.Set<ItemMaster>().FirstOrDefaultAsync(i => i.ItemName == name);

        }
    }
}

