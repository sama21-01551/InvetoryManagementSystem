using InvetoryManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contracs
{
    public interface ISerialNumberReposatory :IGenericRepository<ItemSerialNumber,int>
    {
        Task<ItemSerialNumber> GetSerialStatus(int serialNumber);
        //  Task<ItemSerialNumber> UpdateGSerialStatus(int serialnumber);
        Task<ItemSerialNumber> RemovebyID(int serialNumber);
    }
}
