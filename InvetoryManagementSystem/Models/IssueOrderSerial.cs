using System;
using System.Collections.Generic;

namespace InvetoryManagementSystem;

public partial class IssueOrderSerial
{
    public int IssueSerialId { get; set; }

    public int IssueDetailId { get; set; }

    public int SerialId { get; set; }

    public DateOnly? IssueDate { get; set; }

    public string? ReturnExpected { get; set; }

    public DateOnly? ExpectedReturnDate { get; set; }

    public string? Notes { get; set; }

    public virtual IssueOrderDetail IssueDetail { get; set; } = null!;

    public virtual ItemSerialNumber Serial { get; set; } = null!;
}
