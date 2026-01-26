using InvetoryManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contracs
{
  public  interface IstokBalanceReposatory:IGenericRepository<StockBalance,int>
    {
        Task<IEnumerable<StockBalance> >AvailableQuantatyAsync();
        Task<StockBalance> TotalQuantaty(StockBalance stockBalance);
    }
}
