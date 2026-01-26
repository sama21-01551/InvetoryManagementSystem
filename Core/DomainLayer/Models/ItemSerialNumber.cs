using DomainLayer.Models;
using System;
using System.Collections.Generic;

namespace InvetoryManagementSystem;

public partial class ItemSerialNumber : BaseEntity<int>
{
    public int SerialId { get; set; }

    public int ItemId { get; set; }
    
    public int SerialNumber { get; private set; }
   

    public string? SerialStatus { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    public DateOnly? WarrantyExpiryDate { get; set; }

    public int? CurrentStoreId { get; set; }

    public string? Note { get; set; }

    public virtual Store? CurrentStore { get; set; }

    public virtual ICollection<InventoryTransactionLog> InventoryTransactionLogs { get; set; } = new List<InventoryTransactionLog>();

    public virtual ICollection<IssueOrderSerial> IssueOrderSerials { get; set; } = new List<IssueOrderSerial>();

    public virtual ItemMaster Item { get; set; } = null!; 

    public virtual ICollection<ReceivingOrderSerial> ReceivingOrderSerials { get; set; } = new List<ReceivingOrderSerial>();
    
}
