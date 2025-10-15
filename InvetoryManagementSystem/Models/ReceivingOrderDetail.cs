using System;
using System.Collections.Generic;

namespace InvetoryManagementSystem;

public partial class ReceivingOrderDetail
{
    public int ReceivingDetailId { get; set; }

    public int ReceivingOrderId { get; set; }

    public int ItemId { get; set; }

    public int? QuantityOrdered { get; set; }

    public int? QuantityReceived { get; set; }

    public int? UnitPrice { get; set; }

    public int? LineTotal { get; set; }

    public int? BatchNumber { get; set; }

    public DateOnly? ManufacturingDate { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public string? InspectionStatus { get; set; }

    public string? Notes { get; set; }

    public virtual ItemMaster Item { get; set; } = null!;

    public virtual ReceivingOrder ReceivingOrder { get; set; } = null!;

    public virtual ICollection<ReceivingOrderSerial> ReceivingOrderSerials { get; set; } = new List<ReceivingOrderSerial>();
}
