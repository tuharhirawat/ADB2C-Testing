//namespace WebApplication1.Models
//{
//    public class WorkOrderDetail
//    {
//    }
//}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class WorkOrderAdvanceModeDetails
{
    [Key]
    public int DetailId { get; set; }

    [ForeignKey("WorkOrder")]
    public int WorkOrderId { get; set; }

    public string DetailInfo { get; set; }

    public virtual WorkOrderAlbumSizeDetails1 WorkOrder { get; set; }
}
