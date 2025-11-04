using ServiceAbstraction;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Contracs;
using InvetoryManagementSystem;
namespace Service
{
    public class ItemMasterServices(IUnitOfWork _unitOfWork ,IMapper _mapper) :  IItemService 
    {
        //private readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;

        //public ItemMasterServices(IUnitOfWork unitOfWork, IMapper mapper)
        //{
        //    _unitOfWork = unitOfWork;
        //    _mapper = mapper ;
        //}
        public async Task<IEnumerable<ItemMasterDTO>> GetAllItems()
        {
            var Products = await _unitOfWork.GetRepository<ItemMaster, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<ItemMaster>, IEnumerable<ItemMasterDTO>>(Products);
        }
        public async Task AddItem(ItemMasterDTO item)
        {
            var entity = _mapper.Map<ItemMaster>(item);
           await _unitOfWork.GetRepository<ItemMaster, int>().AddAsync(entity);
          var result=  await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                Console.WriteLine("Item added successfully to DB");
            }
            else
            {
                Console.WriteLine("Failed to save item to DB");
            }

        }
        public async Task<ItemMasterDTO?> GetItemById(int ItemId)
        {
            var productid = await _unitOfWork.GetRepository<ItemMaster, int>().GetByIdAsync(ItemId);
            if (productid == null)
            {
             return null; 
            }
            return _mapper.Map<ItemMasterDTO>(productid);
        }

      public async  Task<ItemMasterDTO?> GetByNameAsync(string name)
        {

            var itemName = await _unitOfWork.ItemMasterReposatory.GetByNameAsync(name);
            if (itemName == null)
            {
                return null;
            }
            return _mapper.Map<ItemMasterDTO>(itemName);
        }

        
        public async Task<ItemMasterDTO> GetByItemCode(int code)
        {

            var itemCode = await _unitOfWork.ItemMasterReposatory.GetByCodeAsync(code);
            if (itemCode == null)
            {
                return null;
            }
            return _mapper.Map<ItemMasterDTO>(itemCode);
        }

        public async Task Update(int itemdto)
        {
            
             var theitem = await _unitOfWork.GetRepository<ItemMaster, int>().GetByIdAsync(itemdto);
            _unitOfWork.GetRepository<ItemMaster, int>().Update(theitem);
            await _unitOfWork.SaveChanges();


        }

        public async Task Delete(int ItemId)
        {
            var entity = await _unitOfWork.GetRepository<ItemMaster, int>().GetByIdAsync(ItemId);

            if (entity == null)
                throw new Exception($"Item ID {ItemId} not found");

            _unitOfWork.GetRepository<ItemMaster, int>().Remove(entity);
            await _unitOfWork.SaveChanges();

        }
        
        //public async Task<ItemMasterDTO> Delete(int item)
        //{
        //    var entity = _mapper.Map<ItemMaster>(item);

        //  _unitOfWork.GetRepository<ItemMaster, int>().Remove(entity);

        //}


        //public async Task<ItemMasterDTO> GetByItemCode(int code)
        //{
        //    var itemCode = await _unitOfWork.ItemMasterReposatory.GetByCodeAsync(code);
        //    if (itemCode == null)
        //    {
        //        return null;
        //    }
        //    return _mapper.Map<ItemMasterDTO>(itemCode);
        //}


    }
}

