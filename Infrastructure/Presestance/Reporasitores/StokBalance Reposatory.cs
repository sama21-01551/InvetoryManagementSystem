using DomainLayer.Contracs;
using InvetoryManagementSystem;
using InvetoryManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Reporasitores
{
    public class StokBalance_Reposatory(InventoryManagementSystemContext _dbcontext) : GenaricReporasatories<StockBalance, int>(_dbcontext), IstokBalanceReposatory
    {
        public async Task<IEnumerable<StockBalance>> AvailableQuantatyAsync()
        {
            var entity = await _dbcontext.Set<StockBalance>().Where(x => x.AvailableQuantity > 0).ToListAsync();
            if (entity == null)
            {
                Console.WriteLine("empty");
            }
            return entity.ToList();
        }

        public Task<StockBalance> TotalQuantaty(StockBalance stockBalance)
        {
            throw new NotImplementedException();
        }
    }
}
