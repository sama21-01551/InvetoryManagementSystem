using System;
using System.Collections.Generic;

namespace InvetoryManagementSystem;

public partial class StockBalance
{
    public int StockBalanceId { get; set; }

    public int ItemId { get; set; }

    public int StoreId { get; set; }

    public int? AvailableQuantity { get; set; }

    public int? ReservedQuantity { get; set; }

    public int? TotalQuantity { get; set; }

    public DateTime? LastUpdated { get; set; }

    public int? ReorderPoint { get; set; }

    public int? Value { get; set; }

    public virtual ItemMaster Item { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
