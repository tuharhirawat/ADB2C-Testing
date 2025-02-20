using System;
using System.Collections.Generic;

namespace Sarat_Proj.Models;

public partial class Taxmaster
{
    public int Taxid { get; set; }

    public string? Taxname { get; set; }

    public string? Taxper { get; set; }

    public DateOnly? Wef { get; set; }

    public int? Mode { get; set; }
}
