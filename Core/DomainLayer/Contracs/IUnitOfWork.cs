using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contracs
{
    public interface IUnitOfWork
    {
        IItemMasterReposatory ItemMasterReposatory { get; }
        ISerialNumberReposatory SerialNumberReposatory { get; } 

        IGenericRepository<Tentity, Tkey> GetRepository<Tentity, Tkey>() where Tentity : BaseEntity<Tkey>;
        IReceivingOrderReoisatory ReceivingOrderReoisatory { get; }
        Task<int> SaveChanges();










    }
}
