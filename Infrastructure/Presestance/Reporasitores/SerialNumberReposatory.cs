using DomainLayer.Contracs;
using InvetoryManagementSystem;
using InvetoryManagementSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Reporasitores
{
    public class SerialNumberReposatory : GenaricReporasatories<ItemSerialNumber, int>, ISerialNumberReposatory
    {
        private readonly InventoryManagementSystemContext _dbcontext;
        public SerialNumberReposatory(InventoryManagementSystemContext dbContext) : base(dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<ItemSerialNumber> GetSerialStatus(int serialNumber)
        {
           
            return await _dbcontext.ItemSerialNumbers
                   .FirstOrDefaultAsync(x => x.SerialNumber == serialNumber);
        }

        public async Task<ItemSerialNumber> RemovebyID(int serialNumber)
        {
            return await _dbcontext.ItemSerialNumbers.FirstOrDefaultAsync(x => x.ItemId == serialNumber);
        }

        //public Task<ItemSerialNumber> UpdateGSerialStatus(int serialnumber)
        // {

        // }





    }
}
