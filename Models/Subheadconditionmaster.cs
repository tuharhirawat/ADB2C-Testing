using System;
using System.Collections.Generic;

namespace Sarat_Proj.Models;

public partial class Subheadconditionmaster
{
    public int Id { get; set; }

    public int? Mainheadid { get; set; }

    public string? Maxpage { get; set; }

    public string? Extrarate { get; set; }

    public int? Mode { get; set; }
}
