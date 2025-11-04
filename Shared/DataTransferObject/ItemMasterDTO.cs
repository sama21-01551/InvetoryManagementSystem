using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject
{
    public class ItemMasterDTO
    {
      //  public int ItemId { get; set; }

        public string ItemName { get; set; } = default!;
        public int ItemCode { get; set; }
        public string? ItemCategory { get; set; }

        public string? UnitOfMeasure { get; set; }


        public decimal UnitPrice { get; set; }
        public int? MinimumStockLevel { get; set; }

        public int? MaximumStockLevel { get; set; }
        public string IsSerialized { get; set; } = "N";
    }
}
