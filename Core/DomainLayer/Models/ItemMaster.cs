using System;
using System.Collections.Generic;

namespace InvetoryManagementSystem;

public partial class ItemMaster
{
    public int ItemId { get; set; }

    public int ItemCode { get; set; }

    public string ItemName { get; set; } = null!;

    public string? ItemCategory { get; set; }

    public string? UnitOfMeasure { get; set; }

    public int? MinimumStockLevel { get; set; }

    public int? MaximumStockLevel { get; set; }

    public decimal UnitPrice { get; set; }

    public string IsSerialized { get; set; } = null!;

    public string? ItemStatus { get; set; }

    public string? Specifications { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public virtual ICollection<InventoryTransactionLog> InventoryTransactionLogs { get; set; } = new List<InventoryTransactionLog>();

    public virtual ICollection<IssueOrderDetail> IssueOrderDetails { get; set; } = new List<IssueOrderDetail>();

    public virtual ICollection<ItemSerialNumber> ItemSerialNumbers { get; set; } = new List<ItemSerialNumber>();

    public virtual ICollection<ReceivingOrderDetail> ReceivingOrderDetails { get; set; } = new List<ReceivingOrderDetail>();

    public virtual ICollection<StockBalance> StockBalances { get; set; } = new List<StockBalance>();
}
