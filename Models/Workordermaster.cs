using System;
using System.Collections.Generic;

namespace Sarat_Proj.Models;

public partial class Workordermaster
{
    public int Workorderid { get; set; }

    public string? Workorderno { get; set; }

    public int? Customerid { get; set; }

    public int? Worktypeid { get; set; }

    public int? Noofphoto { get; set; }

    public DateOnly? Wdate { get; set; }

    public string? Wtime { get; set; }

    public DateOnly? Ddate { get; set; }

    public string? Dtime { get; set; }

    public int? Workstatus { get; set; }

    public int? Type { get; set; }

    public string? Description { get; set; }

    public string? Remarks { get; set; }

    public int? Deliverytypeid { get; set; }

    public int? Cstatus { get; set; }

    public int? Id { get; set; }

    public int? Machineid { get; set; }

    public int? Noofcopies { get; set; }

    public int? Staffid { get; set; }

    public int? Wno { get; set; }

    public int? SeId { get; set; }

    public string? Ordervia { get; set; }

    public int? Branchid { get; set; }
}
