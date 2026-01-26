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
using System.Transactions;
using System.Text.Json.Serialization;
using DomainLayer;


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
        public async Task<IEnumerable<ItemMasterDTO>> GetAllItems()   /// pagesize=10 totoalpages=10
        {
          
        var Products = await _unitOfWork.GetRepository<ItemMaster, int>().GetAllAsync();
        return _mapper.Map<IEnumerable<ItemMaster>, IEnumerable<ItemMasterDTO>>(Products);
        

        }
        public async Task<int> AddItem(ItemMasterDTO item)
        {
            
            try
            {
          
                var entity = _mapper.Map<ItemMaster>(item);
                var x = await _unitOfWork.GetRepository<ItemMaster, int>().AddAsync(entity);
               //  await _unitOfWork.SaveChanges();

                var itemserial = new ItemSerialNumber
                {
                //    ItemId = x.ItemId,
                Item=x,

                   SerialStatus = "Available"
                };
                // itemserial.Item = x.ItemId;

                //var stock = new StockBalance
                //{
                //    Item = x
                //};
                // await _unitOfWork.GetRepository<ItemSerialNumber, int>().AddAsync(itemserial);
                // await _unitOfWork.GetRepository<StockBalance, int>().AddAsync(stock);
                var result = await _unitOfWork.SaveChanges();


                return entity.ItemId;

                //if (result > 0)
                //{
                //    x.IsSerialized = "Y";
                //    return entity.ItemId;
                //    // Console.WriteLine("Item added successfully to DB");
                //}
                //else
                //{
                //    throw new Exception("Failed to save item to DB");
                //}

            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        




            //if (serialResult <= 0)
            //{
            //    throw new Exception("Failed to save item serial to DB");
            //}

        }
            public async Task<ItemMasterDTO> GetItemById(int ItemId)
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

        public async Task<ItemMasterDTO> Update(int id ,ItemMasterDTO itemdto )
        {
            var theitem = await _unitOfWork.GetRepository<ItemMaster, int>().GetByIdAsync(id);
            _mapper.Map(itemdto, theitem);

            _unitOfWork.GetRepository<ItemMaster, int>().Update(theitem);
            await _unitOfWork.SaveChanges();
            return _mapper.Map<ItemMasterDTO>(theitem);
            //  var item = await _unitOfWork.GetRepository<ItemMaster, int>().GetByIdAsync(itemdto);
            //  _unitOfWork.GetRepository<ItemMaster, int>().Update(item);
            //  await _unitOfWork.SaveChanges();
            // return _mapper.Map<ItemMaster, ItemMasterDTO>(item);

        }

        //public async Task Delete(int Item_Id)
        //{
        //    var entity = await _unitOfWork.GetRepository<ItemMaster, int>().GetByIdAsync(Item_Id); //20 item id    //item master ////
        //                                                                                           // var serial = _unitOfWork.GetRepository<ItemSerialNumber, int>().GetByIdAsync(Item_Id);
        //                                                                                           //var serial = new ItemSerialNumber
        //                                                                                           //{
        //                                                                                           //    ItemId = entity.ItemId,
        //                                                                                           //   // ItemId = entity.ItemId
        //                                                                                           //};
        //                                                                                           //        var serials = await _unitOfWork
        //                                                                                           //.GetRepository<ItemSerialNumber, int>()
        //                                                                                           //.FindAsync(s => s.ItemId == Item_Id);
        //                                                                                           //  _unitOfWork.GetRepository<ItemSerialNumber, int>().Remove(serials.First<>);

        //    //  var s = await _unitOfWork.GetRepository<ItemMaster,int>().fi
        //    //_unitOfWork.GetRepository<ItemSerialNumber, int>().Remove(s);
        //    //await _unitOfWork.SaveChanges();
        //    ////if (entity == null)
        //    //    throw new Exception($"Item ID {ItemId} not found");

        //    var serial = new ItemSerialNumber
        //    {
        //        ItemId = entity.ItemId
        //    };
        // //   _unitOfWork.SerialNumberReposatory<ItemSerialNumber, int>().RemovebyID(serial);
         

        //    _unitOfWork.GetRepository<ItemMaster, int>().Remove(entity);
           
        //    var result = await _unitOfWork.SaveChanges();


        //    if (result > 0)
        //    {
               
        //         Console.WriteLine("Item deleted successfully to DB");
        //    }
        //    else
        //    {
        //        throw new Exception("Failed to delet item to DB");
        //    }

        //}

        public async Task<paginationdto<ItemMasterDTO>> GetwithpaginationAsync(int pagenumber)
        {
            // var items = await _unitOfWork.GetRepository<ItemMaster, int>().GetwithpaginationAsync(pagenumber);
            // return _mapper.Map<IEnumerable<ItemMaster>, IEnumerable<ItemMasterDTO>>(items);
            #region work
            //////////
            //    var paginnation = new Pagination
            //    {
            //        PageNumber = pagenumber,
            //        currentpage=pagenumber,

            //   };
            //var items=    await _unitOfWork.GetRepository<ItemMaster,int>().GetwithpaginationAsync(paginnation);
            //    return _mapper.Map<IEnumerable<ItemMaster>, IEnumerable<ItemMasterDTO>>(items);
            //////
            #endregion
            
            
            var pagina= new Pagination { PageNumber = pagenumber };
            var items = await _unitOfWork.GetRepository<ItemMaster, int>().GetwithpaginationAsync(pagina);
            //  return _mapper.Map < IEnumerable < ItemMaster > ,paginationdto <ItemMasterDTO>>(items);
            return new paginationdto<ItemMasterDTO>
            {
                CurrentPage = items.CurrentPage,
                TotalPages = items.TotalPages,
                     HasNext=items.HasNext,
                Data = _mapper.Map<IEnumerable<ItemMasterDTO>>(items.Data)
            };
        }


        public async Task deletByAsync(int itemId)
        {
        
             await _unitOfWork.GetRepository<ItemSerialNumber,int>().deletByAsync(s=>s.ItemId==itemId);
            await _unitOfWork.GetRepository<ItemMaster, int>().deletByAsync(s => s.ItemId == itemId);
            //    var item = await _unitOfWork
            //        .GetRepository<ItemMaster, int>()
            //        .GetByIdAsync(itemId);

            //    if (item == null)
            //        throw new Exception($"Item with ID {itemId} not found");

            //    _unitOfWork
            //        .GetRepository<ItemMaster, int>()
            //        .Remove(item);


            //    await _unitOfWork.SaveChanges();
            var result = await _unitOfWork.SaveChanges();


            if (result > 0)
            {
               
                 Console.WriteLine("Item deleted successfully from DB");
            }
            else
            {
                throw new Exception("Failed to delete item from DB");
            }
        }

        public async Task<IEnumerable<ItemMasterDTO>> GetallserializedAsync()  
        {

            var fromserial = await _unitOfWork.ItemMasterReposatory.SerializedAsync(); //list 1,2,3
            var items = await _unitOfWork.ItemMasterReposatory.GetlAsync(i => fromserial.Contains(i.ItemId));
           
            return _mapper.Map<IEnumerable<ItemMasterDTO>>(items);        
           

        }
       
        public async Task SaveChangesAsync()
        {

            await _unitOfWork.SaveChanges();
        }

        //get if item exist at serialnumber table 2 the itemid of the item wihch exist at serial number == itemmaster.itemid

    }
}

