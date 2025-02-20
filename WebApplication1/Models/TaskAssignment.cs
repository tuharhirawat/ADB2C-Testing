using System.ComponentModel.DataAnnotations;

public class TaskAssignment
{
    [Key]  // This marks it as a primary key
    public int TaskAssignmentId { get; set; }

    public string TaskName { get; set; }
    public int AssignedTo { get; set; }
    public DateTime AssignedDate { get; set; }
}
