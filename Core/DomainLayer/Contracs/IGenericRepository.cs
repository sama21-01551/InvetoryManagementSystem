using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contracs
{
    public interface IGenericRepository<Tentity, Tkey> where Tentity :BaseEntity<Tkey>
    {
        Task<IEnumerable<Tentity>> GetAllAsync();
        Task<Tentity?> GetByIdAsync( Tkey id);
        Task AddAsync(Tentity entity);
        void Update( Tentity entity);
        void Remove(Tentity entity);



    }
}
