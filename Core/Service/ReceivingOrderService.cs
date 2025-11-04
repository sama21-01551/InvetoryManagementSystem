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
  public  class ReceivingOrderService(IUnitOfWork _unitOfWork, IMapper _mapper) : IRecivingOrderService
    {

       


        ////
      //  public async Task<ReceivingOrderDTO> CreateRecivingOrder(ReceivingOrder receivingOrder)
       //    // var createe = await _unitOfWork.ReceivingOrderReoisatory.CreateRecivingOrder(receivingOrder);

           //  var createe = await _unitOfWork.GetRepository<ReceivingOrder, int>().AddAsync();
             //   return _mapper.Map<ReceivingOrder,ReceivingOrderDTO>(createe);
              //  ReceivingOrderReoisatory.CreateRecivingOrder(ReceivingOrder receivingOrder).add
     //   }

        public async Task<ReceivingOrderDTO> CreateRecivingOrder(ReceivingOrderDTO receivedto)
        {
            //var createe= await _unitOfWork.ReceivingOrderReoisatory.CreateRecivingOrder(receivedto)
            //     return _mapper.Map<ReceivingOrderDTO>(receivedto);

            var createe = _mapper.Map<ReceivingOrder>(receivedto);
            var createdEntity = await _unitOfWork.ReceivingOrderReoisatory.CreateRecivingOrder(createe);
            return _mapper.Map<ReceivingOrderDTO>(createdEntity);


        }

        public async Task<ReceivingOrderDTO> GetPrice(int recivingorderid)
        {
           var price= await _unitOfWork.ReceivingOrderReoisatory.GetPrice(recivingorderid);
         

            return _mapper.Map<ReceivingOrderDTO>(price);
        }

        public async Task<StoreDTO> GetStoreById(int recivingorderid)
        {
           var store= await _unitOfWork.ReceivingOrderReoisatory.GetStoreById(recivingorderid);
            return _mapper.Map<StoreDTO>(store);
        }

        public async Task<SupplierDTO> GetSupplierById(int recivingorderid)
        {
          var supplier= await _unitOfWork.ReceivingOrderReoisatory.GetSupplierById(recivingorderid);
            return _mapper.Map<SupplierDTO>(supplier);
        }
    }
}
