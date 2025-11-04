


using DomainLayer.Contracs;
using DomainLayer.Models;
using InvetoryManagementSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Reporasitores
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryManagementSystemContext _DbContext;
        private readonly Dictionary<string, object> _repositories = new();

        public IItemMasterReposatory ItemMasterReposatory { get; }
        public ISerialNumberReposatory SerialNumberReposatory { get; }
        public IReceivingOrderReoisatory ReceivingOrderReoisatory { get; }

       
        public UnitOfWork(
            InventoryManagementSystemContext DbContext,
            IItemMasterReposatory itemMasterReposatory,
            ISerialNumberReposatory serialNumberReposatory,
            IReceivingOrderReoisatory receivingOrderReoisatory)
        {
            _DbContext = DbContext;
            ItemMasterReposatory = itemMasterReposatory;
            SerialNumberReposatory = serialNumberReposatory;
            ReceivingOrderReoisatory = receivingOrderReoisatory;
        }

        public IGenericRepository<Tentity, Tkey> GetRepository<Tentity, Tkey>()
            where Tentity : BaseEntity<Tkey>
        {
            var TypeName = typeof(Tentity).Name;

            if (_repositories.TryGetValue(TypeName, out object? value))
            {
                return (IGenericRepository<Tentity, Tkey>)value;
            }
            else
            {
                var Repo = new GenaricReporasatories<Tentity, Tkey>(_DbContext);
                _repositories[TypeName] = Repo;
                return Repo;
            }
        }

        public async Task<int> SaveChanges() => await _DbContext.SaveChangesAsync();
    }
}

