//public class WorkOrderMaster
//{
//    public int WorkOrderId { get; set; }
//    public string? WorkOrderNo { get; set; }
//    public int? CustomerId { get; set; }
//    public int? WorkTypeId { get; set; }
//    public int? NoOfPhoto { get; set; }
//    public DateTime? WDate { get; set; }
//    public string? WTime { get; set; }
//    public DateTime? DDate { get; set; }
//    public string? DTime { get; set; }
//    public int? WorkStatus { get; set; }
//    public int? Type { get; set; }
//    public string? Description { get; set; }
//    public string? Remarks { get; set; }
//    public int? DeliveryTypeId { get; set; }
//    public int? CStatus { get; set; }
//    public int? Id { get; set; }
//    public int? MachineId { get; set; }
//    public int? NoOfCopies { get; set; }
//    public int? StaffId { get; set; }
//    public int? WNo { get; set; }
//    public int? SeId { get; set; }
//    public string? OrderVia { get; set; }
//    public int? BranchId { get; set; }
//    public object WorkOrderDetails { get; internal set; }
//}




namespace WebApplication1.Models  // Ensure this matches your project namespace
{
    public class WorkOrderMaster
    {
        public int WorkOrderId { get; set; }
        public string? WorkOrderNo { get; set; }
        public int? CustomerId { get; set; }
        public int? WorkTypeId { get; set; }
        public int? NoOfPhoto { get; set; }
        public DateTime? WDate { get; set; }
        public string? WTime { get; set; }
        public DateTime? DDate { get; set; }
        public string? DTime { get; set; }
        public int? WorkStatus { get; set; }
        public int? Type { get; set; }
        public string? Description { get; set; }
        public string? Remarks { get; set; }
        public int? DeliveryTypeId { get; set; }
        public int? CStatus { get; set; }
        public int? Id { get; set; }
        public int? MachineId { get; set; }
        public int? NoOfCopies { get; set; }
        public int? StaffId { get; set; }
        public int? WNo { get; set; }
        public int? SeId { get; set; }
        public string? OrderVia { get; set; }
        public int? BranchId { get; set; }
        public object WorkOrderDetails { get; internal set; }
    }
}
