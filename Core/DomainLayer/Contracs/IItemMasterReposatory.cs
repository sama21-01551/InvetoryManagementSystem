using InvetoryManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contracs
{
    public interface IItemMasterReposatory : IGenericRepository<ItemMaster, int>
    {

        Task<ItemMaster?> GetByCodeAsync(int code);
        Task<ItemMaster?> GetByNameAsync(string name);
        // Task<ItemSerialNumber> removebyitemid(int serial);
        Task<List<int>> SerializedAsync();
        Task<IEnumerable<ItemMaster>> GetlAsync(Expression<Func<ItemMaster, bool>> predicate);
    }
}
