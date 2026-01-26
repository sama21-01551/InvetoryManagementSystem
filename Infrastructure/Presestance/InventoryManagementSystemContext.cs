//using System;
using System.Collections.Generic;
using DomainLayer.Models.IdentityModule;

//using DomainLayer.Models.IdentityModule;
using InvetoryManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InvetoryManagementSystem.Infrastructure.Data;

public partial class InventoryManagementSystemContext :IdentityDbContext<ApplicationUser> //DbContext
{
    public InventoryManagementSystemContext()
    {
    }

    public InventoryManagementSystemContext(DbContextOptions<InventoryManagementSystemContext> options): base(options)
    {
    }

    public virtual DbSet<InventoryTransactionLog> InventoryTransactionLogs { get; set; }

    public virtual DbSet<IssueOrder> IssueOrders { get; set; }

    public virtual DbSet<IssueOrderDetail> IssueOrderDetails { get; set; }

    public virtual DbSet<IssueOrderSerial> IssueOrderSerials { get; set; }

    public virtual DbSet<ItemMaster> ItemMasters { get; set; }

    public virtual DbSet<ItemSerialNumber> ItemSerialNumbers { get; set; }
   

    public virtual DbSet<ReceivingOrder> ReceivingOrders { get; set; }

    public virtual DbSet<ReceivingOrderDetail> ReceivingOrderDetails { get; set; }

    public virtual DbSet<ReceivingOrderSerial> ReceivingOrderSerials { get; set; }

    public virtual DbSet<StockBalance> StockBalances { get; set; }

    public virtual DbSet<Store> Stores { get; set; }


    public virtual DbSet<Supplier> Suppliers { get; set; }
    public virtual DbSet<Ccategory> Ccategories { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.;Database=Inventory_Management_System;Trusted_Connection=True;TrustServerCertificate=True;");

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InventoryTransactionLog>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Inventor__9A8D5625FF51CF63");

            entity.ToTable("Inventory_Transaction_Log");

            entity.Property(e => e.TransactionId)
                .ValueGeneratedNever()
                .HasColumnName("Transaction_ID");
            entity.Property(e => e.CreatedDate).HasColumnName("Created_Date");
            entity.Property(e => e.FromStoreId).HasColumnName("From_Store_ID");
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.PerformedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Performed_By");
            entity.Property(e => e.ReferenceId).HasColumnName("Reference_ID");
            entity.Property(e => e.ReferenceType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Reference_Type");
            entity.Property(e => e.SerialId).HasColumnName("Serial_ID");
            entity.Property(e => e.ToStoreId).HasColumnName("To_Store_ID");
            entity.Property(e => e.TransactionDate).HasColumnName("Transaction_Date");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Transaction_Type");

            entity.HasOne(d => d.FromStore).WithMany(p => p.InventoryTransactionLogFromStores)
                .HasForeignKey(d => d.FromStoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__From___5BE2A6F2");

            entity.HasOne(d => d.Item).WithMany(p => p.InventoryTransactionLogs)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Item___59FA5E80");

            entity.HasOne(d => d.Serial).WithMany(p => p.InventoryTransactionLogs)
                .HasForeignKey(d => d.SerialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Seria__5AEE82B9");

            entity.HasOne(d => d.ToStore).WithMany(p => p.InventoryTransactionLogToStores)
                .HasForeignKey(d => d.ToStoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__To_St__5CD6CB2B");
        });
  base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IssueOrder>(entity =>
        {
            entity.HasKey(e => e.IssueOrderId).HasName("PK__Issue_Or__062A9D9E5964600C");

            entity.ToTable("Issue_Order");

            entity.Property(e => e.IssueOrderId)
                .ValueGeneratedNever()
                .HasColumnName("Issue_Order_ID");
            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Approved_By");
            entity.Property(e => e.CreatedDate).HasColumnName("Created_Date");
            entity.Property(e => e.IssueDate).HasColumnName("Issue_Date");
            entity.Property(e => e.IssueOrderNumber).HasColumnName("Issue_Order_Number");
            entity.Property(e => e.IssueType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Issue_Type");
            entity.Property(e => e.IssuedTo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Issued_To");
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.Purpose).HasColumnType("text");
            entity.Property(e => e.RequesterDepartment)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Requester_Department");
            entity.Property(e => e.RequesterName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Requester_Name");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.StoreId).HasColumnName("Store_ID");
            entity.Property(e => e.TotalValue).HasColumnName("Total_Value");

            entity.HasOne(d => d.Store).WithMany(p => p.IssueOrders)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Issue_Ord__Store__4F7CD00D");
        });

        modelBuilder.Entity<IssueOrderDetail>(entity =>
        {
            entity.HasKey(e => e.IssueDetailId).HasName("PK__Issue_Or__16078A0F2217C939");

            entity.ToTable("Issue_Order_Details");

            entity.Property(e => e.IssueDetailId)
                .ValueGeneratedNever()
                .HasColumnName("Issue_Detail_ID");
            entity.Property(e => e.IssueOrderId).HasColumnName("Issue_Order_ID");
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.LineTotal).HasColumnName("Line_Total");
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.QuantityIssued).HasColumnName("Quantity_Issued");
            entity.Property(e => e.UnitCost).HasColumnName("Unit_Cost");

            entity.HasOne(d => d.IssueOrder).WithMany(p => p.IssueOrderDetails)
                .HasForeignKey(d => d.IssueOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Issue_Ord__Issue__52593CB8");

            entity.HasOne(d => d.Item).WithMany(p => p.IssueOrderDetails)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Issue_Ord__Item___534D60F1");
        });

        modelBuilder.Entity<IssueOrderSerial>(entity =>
        {
            entity.HasKey(e => e.IssueSerialId).HasName("PK__Issue_Or__9591F2AE1A57F3DC");

            entity.ToTable("Issue_Order_Serials");

            entity.Property(e => e.IssueSerialId)
                .ValueGeneratedNever()
                .HasColumnName("Issue_Serial_ID");
            entity.Property(e => e.ExpectedReturnDate).HasColumnName("Expected_Return_Date");
            entity.Property(e => e.IssueDate).HasColumnName("Issue_Date");
            entity.Property(e => e.IssueDetailId).HasColumnName("Issue_Detail_ID");
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.ReturnExpected)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Return_Expected");
            entity.Property(e => e.SerialId).HasColumnName("Serial_ID");

            entity.HasOne(d => d.IssueDetail).WithMany(p => p.IssueOrderSerials)
                .HasForeignKey(d => d.IssueDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Issue_Ord__Issue__5629CD9C");

            entity.HasOne(d => d.Serial).WithMany(p => p.IssueOrderSerials)
                .HasForeignKey(d => d.SerialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Issue_Ord__Seria__571DF1D5");
        });

        modelBuilder.Entity<ItemMaster>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Item_Mas__3FB508748BF98A2F");

            entity.ToTable("Item_Master");

            entity.HasIndex(e => e.ItemCode, "UQ__Item_Mas__F003364591D72A9D").IsUnique();

            entity.Property(e => e.ItemId).HasColumnName("Item_Id");
            entity.Property(e => e.CreateDate).HasColumnName("Create_Date");
            entity.Property(e => e.IsSerialized)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Is_Serialized");
            entity.Property(e => e.ItemCategory)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Item_Category");
            entity.Property(e => e.ItemCode).HasColumnName("Item_Code");
            entity.Property(e => e.ItemName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Item_Name");
            entity.Property(e => e.ItemStatus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Item_Status");
            entity.Property(e => e.LastModifiedDate).HasColumnName("Last_Modified_Date");
            entity.Property(e => e.MaximumStockLevel).HasColumnName("Maximum_Stock_Level");
            entity.Property(e => e.MinimumStockLevel).HasColumnName("Minimum_Stock_Level");
            entity.Property(e => e.Specifications)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UnitOfMeasure)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Unit_Of_Measure");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("Unit_Price");
        });

        modelBuilder.Entity<ItemSerialNumber>(entity =>
        {
            entity.HasKey(e => e.SerialId).HasName("PK__Item_Ser__9F2EE2BD6C05F7C5");

            entity.ToTable("Item_Serial_Number");

            entity.HasIndex(e => e.SerialNumber, "UQ__Item_Ser__96AF66AB920742D8").IsUnique();

            entity.Property(e => e.SerialId).HasColumnName("Serial_Id");
            entity.Property(e => e.CurrentStoreId).HasColumnName("Current_Store_Id");
            entity.Property(e => e.ItemId).HasColumnName("Item_Id");
            entity.Property(e => e.Note).HasColumnType("text");
            entity.Property(e => e.PurchaseDate).HasColumnName("Purchase_Date");
            entity.Property(e => e.SerialNumber).HasColumnName("Serial_Number").HasComputedColumnSql(" DEFAULT (NEXT VALUE FOR [increment])");
            entity.Property(e => e.SerialStatus)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Serial_Status");
            entity.Property(e => e.WarrantyExpiryDate).HasColumnName("Warranty_Expiry_Date");

            entity.HasOne(d => d.CurrentStore).WithMany(p => p.ItemSerialNumbers)
                .HasForeignKey(d => d.CurrentStoreId)
                .HasConstraintName("FK__Item_Seri__Curre__3E52440B");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemSerialNumbers)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Item_Seri__Item___3D5E1FD2");
        });

        modelBuilder.Entity<ReceivingOrder>(entity =>
        {
            entity.HasKey(e => e.ReceivingOrderId).HasName("PK__Receivin__5F665925CEC9FD58");

            entity.ToTable("Receiving_Order");

            entity.Property(e => e.ReceivingOrderId).HasColumnName("Receiving_Order_Id");
            entity.Property(e => e.CreatedDate).HasColumnName("Created_Date");
            entity.Property(e => e.ExpectedDeliveryDate).HasColumnName("Expected_Delivery_Date");
            entity.Property(e => e.InvoiceDate).HasColumnName("Invoice_Date");
            entity.Property(e => e.InvoiceNumber).HasColumnName("Invoice_Number");
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.PurchaseOrderNumber).HasColumnName("Purchase_Order_Number");
            entity.Property(e => e.ReceivedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Received_By");
            entity.Property(e => e.ReceivingDate).HasColumnName("Receiving_Date");
            entity.Property(e => e.ReceivingOrderNumber).HasColumnName("Receiving_Order_Number");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.StoreId).HasColumnName("Store_Id");
            entity.Property(e => e.SupplierId).HasColumnName("Supplier_Id");
            entity.Property(e => e.TotalAmount).HasColumnName("Total_Amount");

            entity.HasOne(d => d.Store).WithMany(p => p.ReceivingOrders)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("FK__Receiving__Store__44FF419A");

            entity.HasOne(d => d.Supplier).WithMany(p => p.ReceivingOrders)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK__Receiving__Suppl__440B1D61");
        });

        modelBuilder.Entity<ReceivingOrderDetail>(entity =>
        {
            entity.HasKey(e => e.ReceivingDetailId).HasName("PK__Receivin__E574C4344D83659C");

            entity.ToTable("Receiving_Order_Details");

            entity.Property(e => e.ReceivingDetailId).HasColumnName("Receiving_Detail_ID");
            entity.Property(e => e.BatchNumber).HasColumnName("Batch_Number");
            entity.Property(e => e.ExpiryDate).HasColumnName("Expiry_Date");
            entity.Property(e => e.InspectionStatus)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Inspection_Status");
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.LineTotal).HasColumnName("Line_Total");
            entity.Property(e => e.ManufacturingDate).HasColumnName("Manufacturing_Date");
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.QuantityOrdered).HasColumnName("Quantity_Ordered");
            entity.Property(e => e.QuantityReceived).HasColumnName("Quantity_Received");
            entity.Property(e => e.ReceivingOrderId).HasColumnName("Receiving_Order_ID");
            entity.Property(e => e.UnitPrice).HasColumnName("Unit_Price");

            entity.HasOne(d => d.Item).WithMany(p => p.ReceivingOrderDetails)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Receiving__Item___48CFD27E");

            entity.HasOne(d => d.ReceivingOrder).WithMany(p => p.ReceivingOrderDetails)
                .HasForeignKey(d => d.ReceivingOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Receiving__Recei__47DBAE45");
        });

        modelBuilder.Entity<ReceivingOrderSerial>(entity =>
        {
            entity.HasKey(e => e.ReceivingSerialId).HasName("PK__Receivin__C3FCCEAB6061470F");

            entity.ToTable("Receiving_Order_Serials");

            entity.Property(e => e.ReceivingSerialId)
                .ValueGeneratedNever()
                .HasColumnName("Receiving_Serial_ID");
            entity.Property(e => e.Condition)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.ReceivedDate).HasColumnName("Received_Date");
            entity.Property(e => e.ReceivingDetailId).HasColumnName("Receiving_Detail_ID");
            entity.Property(e => e.SerialId).HasColumnName("Serial_ID");

            entity.HasOne(d => d.ReceivingDetail).WithMany(p => p.ReceivingOrderSerials)
                .HasForeignKey(d => d.ReceivingDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Receiving__Recei__4BAC3F29");

            entity.HasOne(d => d.Serial).WithMany(p => p.ReceivingOrderSerials)
                .HasForeignKey(d => d.SerialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Receiving__Seria__4CA06362");
        });

        modelBuilder.Entity<StockBalance>(entity =>
        {
            entity.HasKey(e => e.StockBalanceId).HasName("PK__Stock_Ba__A1BC83E269F6175F");

            entity.ToTable("Stock_Balance");

            entity.Property(e => e.StockBalanceId)
                .ValueGeneratedNever()
                .HasColumnName("Stock_Balance_ID");
            entity.Property(e => e.AvailableQuantity).HasColumnName("Available_Quantity");
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.LastUpdated)
                .HasColumnType("datetime")
                .HasColumnName("Last_Updated");
            entity.Property(e => e.ReorderPoint).HasColumnName("Reorder_Point");
            entity.Property(e => e.ReservedQuantity).HasColumnName("Reserved_Quantity");
            entity.Property(e => e.StoreId).HasColumnName("Store_Id");
            entity.Property(e => e.TotalQuantity).HasColumnName("Total_Quantity");

            entity.HasOne(d => d.Item).WithMany(p => p.StockBalances)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stock_Bal__Item___5FB337D6");

            entity.HasOne(d => d.Store).WithMany(p => p.StockBalances)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stock_Bal__Store__60A75C0F");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PK__Store__A0F15B611BE5CFEA");

            entity.ToTable("Store");

            entity.Property(e => e.StoreId)
                .ValueGeneratedNever()
                .HasColumnName("Store_Id");
            entity.Property(e => e.Address)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber).HasColumnName("Contact_Number");
            entity.Property(e => e.CreateDate).HasColumnName("Create_Date");
            entity.Property(e => e.StorageCapacity).HasColumnName("Storage_Capacity");
            entity.Property(e => e.StoreCode).HasColumnName("Store_Code");
            entity.Property(e => e.StoreManager).HasColumnName("Store_Manager");
            entity.Property(e => e.StoreName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Store_Name");
            entity.Property(e => e.StoreStatus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Store_Status");
            entity.Property(e => e.StoreType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Store_Type");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__83918DB8C46E9E25");

            entity.ToTable("Supplier");

            entity.HasIndex(e => e.SupplierCode, "UQ__Supplier__1D8777D0414721B6").IsUnique();

            entity.Property(e => e.SupplierId).HasColumnName("Supplier_Id");
            entity.Property(e => e.Address)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ContactPerson).HasColumnName("Contact_Person");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentTerms)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Payment_Terms");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SupplierCode).HasColumnName("Supplier_Code");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Supplier_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
