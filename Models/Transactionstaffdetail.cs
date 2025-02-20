using System;
using System.Collections.Generic;

namespace Sarat_Proj.Models;

public partial class Transactionstaffdetail
{
    public int Transactionstaffid { get; set; }

    public int? Voucherid { get; set; }

    public int? Staffid { get; set; }

    public int? Mode { get; set; }
}
