public class WorkOrderDetail
{
    public int WoDetailId { get; set; }
    public int? WoStatus { get; set; }
    public int? DepartmentId { get; set; }
    public DateTime? WoDate { get; set; }
    public float? WoTime { get; set; }
    public DateTime? CDate { get; set; }
    public float? CTime { get; set; }
    public int? StaffId { get; set; }
    public int? WorkOrderId { get; set; }
    public int? WorkflowNo { get; set; }
    public int? CStatus { get; set; }
    public string? Description { get; set; }
}
