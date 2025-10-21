using System;
using System.Collections.Generic;

namespace InvetoryManagementSystem;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public int SupplierCode { get; set; }

    public string SupplierName { get; set; } = null!;

    public int? ContactPerson { get; set; }

    public string? Email { get; set; }

    public int? Phone { get; set; }

    public string? Address { get; set; }

    public string? PaymentTerms { get; set; }

    public int? Rating { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<ReceivingOrder> ReceivingOrders { get; set; } = new List<ReceivingOrder>();
}
