using System.ComponentModel.DataAnnotations;

public class WorkOrderTaxDetails
{
    [Key]  // Marks this as the primary key
    public int WorkOrderTaxDetailsId { get; set; }

    public int WorkOrderId { get; set; }
    public decimal TaxAmount { get; set; }
    public string TaxType { get; set; }
}
