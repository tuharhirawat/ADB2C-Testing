//namespace WebApplication1.Models
//{
//    public class WorkOrder
//    {
//    }
//}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class WorkOrderAlbumSizeDetails1
{
    [Key]
    public int WorkOrderId { get; set; }
    public string Description { get; set; }

    // Navigation property (One WorkOrder -> Many related tables)
    public virtual ICollection<WorkOrderAdvanceModeDetails> WorkOrderDetails { get; set; }
    public virtual ICollection<TaskAssignment> TaskAssignments { get; set; }
}
