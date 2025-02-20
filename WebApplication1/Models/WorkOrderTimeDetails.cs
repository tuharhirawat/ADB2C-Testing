using System.ComponentModel.DataAnnotations;

public class WorkOrderTimeDetails
{
    [Key]  // Marks this as the primary key
    public int WorkOrderTimeDetailsId { get; set; }

    public int WorkOrderId { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
