using System;
using System.Collections.Generic;

namespace Sarat_Proj.Models;

public partial class Workorderadvancemodedetail
{
    public int Workorderid { get; set; }

    public int? Mode { get; set; }

    public int? Accountheadid { get; set; }
}
