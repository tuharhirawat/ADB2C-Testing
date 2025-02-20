using System;
using System.Collections.Generic;

namespace Sarat_Proj.Models;

public partial class Workordertaxdetail
{
    public int Workorderid { get; set; }

    public int? Taxid { get; set; }

    public double? Amount { get; set; }
}
