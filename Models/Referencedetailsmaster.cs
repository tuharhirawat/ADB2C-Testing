using System;
using System.Collections.Generic;

namespace Sarat_Proj.Models;

public partial class Referencedetailsmaster
{
    public int Referenceid { get; set; }

    public string Voucherid { get; set; } = null!;

    public double Referencetypeid { get; set; }

    public string? Referenceno { get; set; }

    public double Amount { get; set; }

    public int? Branchid { get; set; }

    public int? Custid { get; set; }
}
