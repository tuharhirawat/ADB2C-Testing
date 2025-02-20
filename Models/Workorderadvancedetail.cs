using System;
using System.Collections.Generic;

namespace Sarat_Proj.Models;

public partial class Workorderadvancedetail
{
    public int Referencetypeid { get; set; }

    public int? Voucherid { get; set; }

    public int? Workorderid { get; set; }

    public int? Amount { get; set; }
}
