using DomainLayer.Contracs;
using DomainLayer.Models;
using InvetoryManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Reporasitores
{
    public class GenaricReporasatories<Tentity, Tkey>(InventoryManagementSystemContext _DbContext) : IGenericRepository<Tentity, Tkey> where Tentity : BaseEntity<Tkey>
    {
        

        public async Task AddAsync(Tentity entity) => await _DbContext.Set<Tentity>().AddAsync(entity);


        public async Task<IEnumerable<Tentity>> GetAllAsync() => await _DbContext.Set<Tentity>().ToListAsync();


        public async Task<Tentity?> GetByIdAsync(Tkey id) => await _DbContext.Set<Tentity>().FindAsync(id);
       

        public void Remove(Tentity entity) =>_DbContext.Set<Tentity>().Remove(entity);
        

        public void Update(Tentity entity) =>_DbContext.Set<Tentity>().Update(entity);
       
    }
}
