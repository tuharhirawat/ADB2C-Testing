using System;
using System.Collections.Generic;

namespace Sarat_Proj.Models;

public partial class Workordertimedetail
{
    public int Workorderid { get; set; }

    public float? Totalhr { get; set; }

    public DateOnly? Ybdate { get; set; }

    public string? Ybtime { get; set; }

    public DateOnly? Rbdate { get; set; }

    public string? Rbtime { get; set; }
}
