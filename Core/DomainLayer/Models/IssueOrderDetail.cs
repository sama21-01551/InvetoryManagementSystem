using System;
using System.Collections.Generic;

namespace InvetoryManagementSystem;

public partial class IssueOrderDetail
{
    public int IssueDetailId { get; set; }

    public int IssueOrderId { get; set; }

    public int ItemId { get; set; }

    public int? QuantityIssued { get; set; }

    public int? UnitCost { get; set; }

    public int? LineTotal { get; set; }

    public string? Notes { get; set; }

    public virtual IssueOrder IssueOrder { get; set; } = null!;

    public virtual ICollection<IssueOrderSerial> IssueOrderSerials { get; set; } = new List<IssueOrderSerial>();

    public virtual ItemMaster Item { get; set; } = null!;
}
