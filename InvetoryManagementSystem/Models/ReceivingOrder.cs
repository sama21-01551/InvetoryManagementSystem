using System;
using System.Collections.Generic;

namespace InvetoryManagementSystem;

public partial class ReceivingOrder
{
    public int ReceivingOrderId { get; set; }

    public int? ReceivingOrderNumber { get; set; }

    public int? PurchaseOrderNumber { get; set; }

    public int? SupplierId { get; set; }

    public int? StoreId { get; set; }

    public DateOnly? ReceivingDate { get; set; }

    public DateOnly? ExpectedDeliveryDate { get; set; }

    public string? ReceivedBy { get; set; }

    public int? InvoiceNumber { get; set; }

    public DateOnly? InvoiceDate { get; set; }

    public int? TotalAmount { get; set; }

    public string? Status { get; set; }

    public string? Notes { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public virtual ICollection<ReceivingOrderDetail> ReceivingOrderDetails { get; set; } = new List<ReceivingOrderDetail>();

    public virtual Store? Store { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
