using AutoMapper;
using DomainLayer.Contracs;
using ServiceAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager(IUnitOfWork _unitofwork,IMapper _mapper) : IServiceManager
    {
        private readonly Lazy<IItemService> _LazyItemservice = new Lazy<IItemService>(() => new ItemMasterServices(_unitofwork, _mapper));
        public IItemService itemservice => _LazyItemservice.Value;
 

        ////
        private readonly Lazy<ISerialService> _lazyserial = new Lazy<ISerialService>(() => new SerialNumberService(_unitofwork, _mapper));

        public ISerialService serialservice => _lazyserial.Value;

        ////
        private readonly Lazy<IRecivingOrderService> _LazyIreceivingorder = new Lazy<IRecivingOrderService>(() => new ReceivingOrderService(_unitofwork, _mapper));
      

        public IRecivingOrderService recivingorderservice => _LazyIreceivingorder.Value;


        // public ISerialService serialService => _LazyItemservice.Value;

        // public ISerialService serialservice => _lazyserial.Value;
    }
}
