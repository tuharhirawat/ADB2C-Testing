using System;
using System.Collections.Generic;

namespace Sarat_Proj.Models;

public partial class Worktype
{
    public int Worktypeid { get; set; }

    public string? Typename { get; set; }

    public int? Commercialornot { get; set; }

    public int? Discount { get; set; }
}
