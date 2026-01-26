using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject
{
    public class StoreDTO
    {
      //  public int StoreId { get; set; }

        public int StoreCode { get; set; }

        public string StoreName { get; set; } = null!;
        public string Address { get; set; } 
    }
}
