using System;
using System.Collections.Generic;

namespace InvetoryManagementSystem;

public partial class IssueOrder
{
    public int IssueOrderId { get; set; }

    public int IssueOrderNumber { get; set; }

    public int StoreId { get; set; }

    public DateOnly? IssueDate { get; set; }

    public string? IssuedTo { get; set; }

    public string? RequesterName { get; set; }

    public string? RequesterDepartment { get; set; }

    public string? Purpose { get; set; }

    public string? IssueType { get; set; }

    public string? ApprovedBy { get; set; }

    public string? Status { get; set; }

    public int? TotalValue { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<IssueOrderDetail> IssueOrderDetails { get; set; } = new List<IssueOrderDetail>();

    public virtual Store Store { get; set; } = null!;
}
