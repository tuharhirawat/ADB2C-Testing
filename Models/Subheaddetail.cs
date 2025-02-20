using System;
using System.Collections.Generic;

namespace Sarat_Proj.Models;

public partial class Subheaddetail
{
    public int Subheadid { get; set; }

    public string? Subhead { get; set; }

    public int? Mainheadid { get; set; }

    public int? Machineid { get; set; }

    public double? Professionalrate { get; set; }

    public double? Ammaturerate { get; set; }

    public double? Subheadrate { get; set; }

    public int? Status { get; set; }

    public int? Parentsubheadid { get; set; }

    public DateOnly? Efdate { get; set; }

    public int? Ratemode { get; set; }

    public string? Details { get; set; }

    public int? Mode { get; set; }
}
