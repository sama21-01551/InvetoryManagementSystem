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
    public class Stockbalanceservice(IUnitOfWork _unitOfWork, IMapper _mappe) : IstokBalanceService
    {
        public async Task<IEnumerable<StokBalancDTO>> AvailableQuantatyAsync()
        {
           var entity=await _unitOfWork.StokBalance_Reposatory.AvailableQuantatyAsync();
            return _mappe.Map<IEnumerable<StockBalance>, IEnumerable<StokBalancDTO>>(entity);
        }
    }
}
