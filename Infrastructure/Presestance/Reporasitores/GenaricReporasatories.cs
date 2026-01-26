using DomainLayer;
using DomainLayer.Contracs;
using DomainLayer.Models;
using InvetoryManagementSystem;
using InvetoryManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Reporasitores
{
    public class GenaricReporasatories<Tentity, Tkey>(InventoryManagementSystemContext _DbContext) : IGenericRepository<Tentity, Tkey> where Tentity : BaseEntity<Tkey>
    {
        

        public async Task<Tentity> AddAsync(Tentity entity)
        {
            var x = await _DbContext.Set<Tentity>().AddAsync(entity);
            return entity;

        }

        public async Task deletByAsync(Expression<Func<Tentity, bool>> predicate)
        {
            var entitie = await _DbContext.Set<Tentity>()
                                   .Where(predicate)
                                   .ToListAsync();
            //if (entitie!== null)
            //{
            //    _DbContext.Set<Tentity>().RemoveRange
            //}
            if (entitie.Any())
            {
                  _DbContext.Set<Tentity>().RemoveRange(entitie);
                
            }
        }

        //public Task<Tentity> editasync(Tkey id)
        //{
        //var element= _DbContext.Set<Tentity>().FindAsync(id);
        //    var eee = _DbContext.Set<Tentity>();
        //    return element
        //}

        public Task FindElmentAsync(Expression<Func<Tentity, bool>> predicate)
        {
           var element =_DbContext.Set<Tentity>().FirstOrDefaultAsync(predicate);
            return element;
        }

        //public async Task<List<<Tentity>> FindAsync(Expression<Func<Tentity, bool>> predicate)
        //{
        //    return await _DbContext.Set<Tentity>().Where(predicate).ToListAsync();
        //}

        public async Task<IEnumerable<Tentity>> GetAllAsync() => await _DbContext.Set<Tentity>().ToListAsync();


        public async Task<Tentity?> GetByIdAsync(Tkey id) => await _DbContext.Set<Tentity>().FindAsync(id);

      

        public async Task<DataforResult<Tentity>> GetwithpaginationAsync(Pagination pagenumber)
        {
            var allitems= _DbContext.Set<Tentity>().Count();
          var items=  await _DbContext.Set<Tentity>().Skip((pagenumber.PageNumber - 1) * pagenumber.Pagesize).Take(pagenumber.Pagesize).ToListAsync();
           // return items;
           //items has a list of records
            var pagination = new DataforResult<Tentity>
            {
              CurrentPage = pagenumber.PageNumber,
            //    PageSize = pagenumber.Pagesize,
               TotalPages =(int)Math.Ceiling( allitems / 10.0),
               Data = items,
               
              
            };
            return pagination;
        }

        //public async Task<(IEnumerable<Tentity>, int totalpages)> ppagibnationAsync(int pagenumber, int pagesize)
        //{
        //  var items= await _DbContext.Set<Tentity>().Skip((pagenumber-1)*pagesize).Take(pagesize).ToListAsync();
        //    return (IEnumerable<Tentity>,items);
        //}

        public void Remove(Tentity entity) =>_DbContext.Set<Tentity>().Remove(entity);

        //public Task<Tentity> removebyitemid(int serial)
        //{
        //    return _DbContext.Set<ItemSerialNumber>();
        //}

        public void Update(Tentity entity) =>_DbContext.Set<Tentity>().Update(entity);

     //   public async Task<List<Tentity>> FindAsync(
     //Expression<Func<Tentity, bool>> predicate)
     //   {
     //       return await _DbContext.Set<Tentity>().Where(predicate).ToListAsync();
     //   }
    }
}
