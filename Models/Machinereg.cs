using System;
using System.Collections.Generic;

namespace Sarat_Proj.Models;

public partial class Machinereg
{
    public int Machineid { get; set; }

    public string? Machinename { get; set; }

    public float? Maxpaperwidth { get; set; }

    public float? Maxpaperheight { get; set; }

    public string? Imagepath { get; set; }
}
