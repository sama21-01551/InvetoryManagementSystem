using DomainLayer.Models;
using InvetoryManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contracs
{
    public interface IGenericRepository<Tentity, Tkey> where Tentity :BaseEntity<Tkey>
    {
        Task<IEnumerable<Tentity>> GetAllAsync();
        Task<Tentity?> GetByIdAsync( Tkey id);
        Task<Tentity> AddAsync(Tentity entity);
        void Update( Tentity entity);
        void Remove(Tentity entity);
      //  Task<Tentity> removebyitemid();
          Task  deletByAsync(Expression<Func<Tentity, bool>> predicate);
        Task FindElmentAsync(Expression<Func<Tentity,bool>> predicate);
        //   Task<IEnumerable<Tentity>> Pagination(int pagenumber,int pagesize );
        //  Task<(IEnumerable<Tentity>, int totalpages)> ppagibnationAsync(int pagenumber, int pagesize);
        //  Task<IEnumerable<Tentity>> GetwithpaginationAsync(Pagination pagenumber);
      //   Task<IEnumerable<Tentity>>GetwithpaginationAsync(Pagination pagination);
          Task<DataforResult<Tentity>> GetwithpaginationAsync(Pagination pagination);
        //Task<Tentity> editasync(Tkey id);
    }
}
