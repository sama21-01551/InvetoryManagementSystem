using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IItemService 
    {
        Task<IEnumerable<ItemMasterDTO>> GetAllItems();
        Task<ItemMasterDTO> GetItemById(int ItemId);
        //  Task<ItemMasterDTO> GetByName(string ItemName);
          Task<ItemMasterDTO> GetByItemCode(int code);
        Task<ItemMasterDTO?> GetByNameAsync(string name);
        Task AddItem(ItemMasterDTO item);
        Task Update(int item);
        Task Delete(int item);

    }
}
