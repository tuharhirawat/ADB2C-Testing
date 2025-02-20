using System.ComponentModel.DataAnnotations;

public class BillWorkDetails
{
    [Key]  // This marks it as the primary key
    public int BillWorkDetailId { get; set; }

    public string WorkDescription { get; set; }
    public decimal Amount { get; set; }
}
