using System.ComponentModel.DataAnnotations;

public class WorkOrderAdvanceDetails1
{
    [Key]  // Marks this as the primary key
    public int WorkOrderAdvanceDetailsId { get; set; }

    public int WorkOrderId { get; set; }
    public decimal AdvanceAmount { get; set; }
    public DateTime PaymentDate { get; set; }
}
