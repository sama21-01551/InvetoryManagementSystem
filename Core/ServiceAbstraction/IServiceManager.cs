using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IServiceManager
    {
        public IItemService  itemservice { get;  }
        public ISerialService serialservice { get; }
        public IRecivingOrderService recivingorderservice { get; }

    }
}
