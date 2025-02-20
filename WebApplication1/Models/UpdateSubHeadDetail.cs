using System.ComponentModel.DataAnnotations;

public class UpdateSubHeadDetail
{
    [Key]  // This marks it as the primary key
    public int UpdateSubHeadDetailId { get; set; }

    public string SubHeadName { get; set; }
    public decimal Amount { get; set; }
}
