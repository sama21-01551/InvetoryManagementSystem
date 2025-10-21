using System;
using System.Collections.Generic;

namespace InvetoryManagementSystem;

public partial class ReceivingOrderSerial
{
    public int ReceivingSerialId { get; set; }

    public int ReceivingDetailId { get; set; }

    public int SerialId { get; set; }

    public DateOnly? ReceivedDate { get; set; }

    public string? Condition { get; set; }

    public string? Notes { get; set; }

    public virtual ReceivingOrderDetail ReceivingDetail { get; set; } = null!;

    public virtual ItemSerialNumber Serial { get; set; } = null!;
}
