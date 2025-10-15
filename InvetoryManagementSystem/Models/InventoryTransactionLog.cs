using System;
using System.Collections.Generic;

namespace InvetoryManagementSystem;

public partial class InventoryTransactionLog
{
    public int TransactionId { get; set; }

    public string? TransactionType { get; set; }

    public DateOnly? TransactionDate { get; set; }

    public int ItemId { get; set; }

    public int SerialId { get; set; }

    public int FromStoreId { get; set; }

    public int ToStoreId { get; set; }

    public int? Quantity { get; set; }

    public string? ReferenceType { get; set; }

    public int? ReferenceId { get; set; }

    public string? PerformedBy { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? Notes { get; set; }

    public virtual Store FromStore { get; set; } = null!;

    public virtual ItemMaster Item { get; set; } = null!;

    public virtual ItemSerialNumber Serial { get; set; } = null!;

    public virtual Store ToStore { get; set; } = null!;
}
