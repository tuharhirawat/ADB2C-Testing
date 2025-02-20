using System.ComponentModel.DataAnnotations;

public class WorkOrderAdvanceDetails
{
    [Key]  // This marks it as the primary key
    public int WorkOrderAdvanceDetailsId { get; set; }

    public int WorkOrderId { get; set; } // Foreign key to WorkOrderMaster
    public decimal AdvanceAmount { get; set; }
    public DateTime AdvanceDate { get; set; }
}
