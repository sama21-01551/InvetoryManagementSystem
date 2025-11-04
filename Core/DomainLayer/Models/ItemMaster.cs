using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvetoryManagementSystem;
[Table("Item_Master")]
public partial class ItemMaster :BaseEntity<int>
{
    [Key]
    [Column("Item_Id")]
    public int ItemId { get; set; }
    [Column("Item_Code")]
    public int ItemCode { get; set; }
    [Column("Item_Name")]
    public string ItemName { get; set; } = null!;
    [Column("Item_Category")]
    public string? ItemCategory { get; set; }
    [Column("Unit_Of_Measure")]
    public string? UnitOfMeasure { get; set; }
    [Column("Minimum_Stock_Level")]
    public int? MinimumStockLevel { get; set; }
    [Column("Maximum_Stock_Level")]
    public int? MaximumStockLevel { get; set; }
    [Column("Unit_Price")]
    public decimal UnitPrice { get; set; }
    [Column("Is_Serialized")]
    public string IsSerialized { get; set; } = null!;
    [Column("Item_Status")]
    public string? ItemStatus { get; set; }
    [Column("Specifications")]
    public string? Specifications { get; set; }
    [Column("Create_Date")]
    public DateOnly? CreateDate { get; set; }
    [Column("Last_Modified_Date")]

    public DateOnly? LastModifiedDate { get; set; }

    public virtual ICollection<InventoryTransactionLog> InventoryTransactionLogs { get; set; } = new List<InventoryTransactionLog>();

    public virtual ICollection<IssueOrderDetail> IssueOrderDetails { get; set; } = new List<IssueOrderDetail>();

    public virtual ICollection<ItemSerialNumber> ItemSerialNumbers { get; set; } = new List<ItemSerialNumber>();

    public virtual ICollection<ReceivingOrderDetail> ReceivingOrderDetails { get; set; } = new List<ReceivingOrderDetail>();

    public virtual ICollection<StockBalance> StockBalances { get; set; } = new List<StockBalance>();
}
