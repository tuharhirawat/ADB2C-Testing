using System;
using System.Collections.Generic;

namespace Sarat_Proj.Models;

public partial class Transactiondetail
{
    public int Transactiondetailsid { get; set; }

    public int Voucherid { get; set; }

    public int AccountHeadId { get; set; }

    public string Narration { get; set; } = null!;

    public double? Amount { get; set; }

    public string DrCr { get; set; } = null!;
}
