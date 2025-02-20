public class TransactionDetail
{
    public int TransactionDetailsId { get; set; }
    public int VoucherId { get; set; }
    public int AccountHeadId { get; set; }
    public string? Narration { get; set; }
    public double? Amount { get; set; }
    public string DrCr { get; set; }
}
