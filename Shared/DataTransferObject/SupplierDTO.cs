using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject
{
    public class SupplierDTO
    {

      //  public int SupplierId { get; set; }

        public int SupplierCode { get; set; }

        public string SupplierName { get; set; } = null!;

        public int? ContactPerson { get; set; }

        public string? Email { get; set; }
        public string? PaymentTerms { get; set; }

    }
}
