using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject
{
 public   class ReceivingOrderDTO
    {

        public int ReceivingOrderId { get; set; }

        public int? ReceivingOrderNumber { get; set; }

        public int? PurchaseOrderNumber { get; set; }

        public int? SupplierId { get; set; }

        public int? StoreId { get; set; }
        public string? ReceivedBy { get; set; }

        public int? InvoiceNumber { get; set; }

        public DateOnly? ReceivingDate { get; set; }
        public int? TotalAmount { get; set; }
        public DateOnly? CreatedDate { get; set; }

    }
}
