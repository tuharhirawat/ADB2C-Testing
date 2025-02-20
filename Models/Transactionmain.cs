using System;
using System.Collections.Generic;

namespace Sarat_Proj.Models;

public partial class Transactionmain
{
    public int Voucherid { get; set; }

    public string Voucherno { get; set; } = null!;

    public DateOnly Voucherdate { get; set; }

    public int BranchId { get; set; }

    public string Mode { get; set; } = null!;

    public int? Tallyid { get; set; }
}
