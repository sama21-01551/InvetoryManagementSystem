using InvetoryManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contracs
{
    public interface IItemMasterReposatory :IGenericRepository<ItemMaster,int>
    {

        Task<ItemMaster?>GetByCodeAsync(int code);
        Task<ItemMaster?> GetByNameAsync(string name);

    }
}
