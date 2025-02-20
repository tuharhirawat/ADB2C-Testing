using System;
using System.Collections.Generic;

namespace Sarat_Proj.Models;

public partial class Accountheadmaster
{
    public int Accountheadid { get; set; }

    public int Groupid { get; set; }

    public string Accountheadname { get; set; } = null!;

    public string? Type { get; set; }

    public int TypeId { get; set; }

    public int? BranchId { get; set; }
}
