using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceAbstraction;

namespace ServiceAbstraction
{
    public interface IItemService 
    {
        Task<IEnumerable<ItemMasterDTO>> GetAllItems();
        Task<ItemMasterDTO> GetItemById(int ItemId);
        //  Task<ItemMasterDTO> GetByName(string ItemName);
          Task<ItemMasterDTO> GetByItemCode(int code);
        Task<ItemMasterDTO?> GetByNameAsync(string name);
        Task<int> AddItem(ItemMasterDTO item);
        Task<ItemMasterDTO  > Update(int item, ItemMasterDTO itemdto );
      //  Task Delete(int item);
        Task deletByAsync(int itemid);
        //  Task<IEnumerable<SerialNumberDTO>> IsSerialized();
        Task<IEnumerable<ItemMasterDTO>> GetallserializedAsync();
       // Task<IEnumerable<ItemMasterDTO>> GetwithpaginationAsync(int pagenumber);
        Task<paginationdto<ItemMasterDTO>> GetwithpaginationAsync(int pagenumber);

    }
}
