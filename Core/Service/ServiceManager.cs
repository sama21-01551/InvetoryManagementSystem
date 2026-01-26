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
    public class ServiceManager(IUnitOfWork _unitofwork, IItemService _itemservice, ISerialService _serialservice ,IIdentityService identity, IRecivingOrderService _recivingOrderService ,IstokBalanceService _Stockbalanceservice) : IServiceManager
    {
        public IItemService itemservice {  get; }= _itemservice;

        public ISerialService serialservice {  get; } = _serialservice;

        public IRecivingOrderService recivingorderservice { get; } = _recivingOrderService;
        public IstokBalanceService Stockbalanceservice { get; } =_Stockbalanceservice;
        public IIdentityService identityservice { get; } = identity;
        public async Task SavechangesAsync()
        {
            await unitofwork.SaveChanges();
        }

        public IUnitOfWork unitofwork { get; } = _unitofwork;


        //public IItemService itemservice => _LazyItemservice.Value;
        //private readonly Lazy<IItemService> _LazyItemservice = new Lazy<IItemService>(() => new ItemMasterServices(_unitofwork, _mapper));
        //////
        //private readonly Lazy<ISerialService> _lazyserial = new Lazy<ISerialService>(() => new SerialNumberService(_unitofwork, _mapper));

        //public ISerialService serialservice => _lazyserial.Value;

        //////
        //private readonly Lazy<IRecivingOrderService> _LazyIreceivingorder = new Lazy<IRecivingOrderService>(() => new ReceivingOrderService(_unitofwork, _mapper));


        //public IRecivingOrderService recivingorderservice => _LazyIreceivingorder.Value;

        //public Task SaveAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
