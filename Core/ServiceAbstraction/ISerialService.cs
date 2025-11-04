using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface ISerialService
    {
        Task<IEnumerable<SerialNumberDTO>> GetAllSerialsAsync();
        Task<SerialNumberDTO> GetBySerialIdAsync(int SerialNumber);
        Task<SerialNumberDTO?> GetSerialStatus(int serialId);
        Task AddSerialNumber(SerialNumberDTO serialdto);
        Task Delete(int id);
        Task Update(SerialNumberDTO serialDto);

    }
}
