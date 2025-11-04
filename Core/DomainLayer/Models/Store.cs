using System;
using System.Collections.Generic;

namespace InvetoryManagementSystem;

public partial class Store
{
    public int StoreId { get; set; }

    public int StoreCode { get; set; }

    public string StoreName { get; set; } = null!;

    public string? StoreType { get; set; }

    public string Address { get; set; }

    public int? StoreManager { get; set; }

    public int? ContactNumber { get; set; }

    public string? StoreStatus { get; set; }

    public int? StorageCapacity { get; set; }

    public DateOnly? CreateDate { get; set; }

    public virtual ICollection<InventoryTransactionLog> InventoryTransactionLogFromStores { get; set; } = new List<InventoryTransactionLog>();

    public virtual ICollection<InventoryTransactionLog> InventoryTransactionLogToStores { get; set; } = new List<InventoryTransactionLog>();

    public virtual ICollection<IssueOrder> IssueOrders { get; set; } = new List<IssueOrder>();

    public virtual ICollection<ItemSerialNumber> ItemSerialNumbers { get; set; } = new List<ItemSerialNumber>();

    public virtual ICollection<ReceivingOrder> ReceivingOrders { get; set; } = new List<ReceivingOrder>();

    public virtual ICollection<StockBalance> StockBalances { get; set; } = new List<StockBalance>();
}
