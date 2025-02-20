using System;
using System.Collections.Generic;

namespace Sarat_Proj.Models;

public partial class Workorderdetail
{
    public int Wodetailid { get; set; }

    public int? Wostatus { get; set; }

    public int? Departmentid { get; set; }

    public DateOnly? Wodate { get; set; }

    public float? Wotime { get; set; }

    public DateOnly? Cdate { get; set; }

    public float? Ctime { get; set; }

    public int? Staffid { get; set; }

    public int? Workorderid { get; set; }

    public int? Workflowno { get; set; }

    public int? Cstatus { get; set; }

    public string? Descr { get; set; }
}
