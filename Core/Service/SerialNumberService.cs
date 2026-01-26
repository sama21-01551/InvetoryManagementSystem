using AutoMapper;
using DomainLayer.Contracs;
using InvetoryManagementSystem;
using ServiceAbstraction;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SerialNumberService(IUnitOfWork _unitofwork, IMapper mapper) : ISerialService
    {


        public async Task<IEnumerable<SerialNumberDTO>> GetAllSerialsAsync()
        {

            var Serials = await _unitofwork.GetRepository<ItemSerialNumber, int>().GetAllAsync();
            return mapper.Map<IEnumerable<ItemSerialNumber>, IEnumerable<SerialNumberDTO>>(Serials);
        }
        public async Task AddSerialNumber(SerialNumberDTO serialdto)
        {

            var item = mapper.Map<ItemSerialNumber>(serialdto);
            await _unitofwork.GetRepository<ItemSerialNumber, int>().AddAsync(item);
            var result = await _unitofwork.SaveChanges();
            if (result > 0)
            {
                Console.WriteLine("Item added successfully to DB");
            }
            else
            {
                Console.WriteLine("Failed to save item to DB");
            }
        }




        public async Task<SerialNumberDTO> GetBySerialIdAsync(int SerialNumber)
        {

            var serialid = await _unitofwork.GetRepository<ItemSerialNumber, int>().GetByIdAsync(SerialNumber);
            if (serialid == null)
            {
                Console.WriteLine("Not Found");
            }
            return mapper.Map<SerialNumberDTO>(serialid);
        }






        public async Task<SerialNumberDTO?> GetSerialStatus(int serialId)
        {
            var serialid = await _unitofwork.SerialNumberReposatory.GetSerialStatus(serialId);
            if (serialid == null)
            {
                Console.WriteLine("Not Found");
            }
            return mapper.Map<SerialNumberDTO>(serialid);
        }
        //public async Task DeletbyItemId(int id)
        //{
        //    var entity = await _unitofwork.GetRepository<ItemSerialNumber, int>().RemovebyID()
        //}

        public async Task Delete(int id)
        {
            var entity = await _unitofwork.GetRepository<ItemSerialNumber, int>().GetByIdAsync(id);
            _unitofwork.GetRepository<ItemSerialNumber, int>().Remove(entity);
            await _unitofwork.SaveChanges();
            ////////////////////////////////////////
            //var item = new ItemMaster
            //{
            //    Id = entity.Id,
            //};
            // _unitofwork.GetRepository<ItemMaster, int>().Remove(item);
            //var serials = entity.Where(x => x.ItemId == itemId).ToList();
            ///////
            //var item=await _unitofwork.GetRepository<ItemMaster, int>().GetByIdAsync(id);
            //_unitofwork.GetRepository<ItemMaster,int>().Remove(item);
            ///////
            var result = await _unitofwork.SaveChanges();
            if (result > 0)
            {

                Console.WriteLine("Item deleted successfully to DB");
            }
            else
            {
                throw new Exception("Failed to save item to DB");
            }
        } 

        public Task Update(SerialNumberDTO serialDto)
        {
            throw new NotImplementedException();
        }
    }


}

