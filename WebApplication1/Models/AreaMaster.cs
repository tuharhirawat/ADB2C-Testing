using System.ComponentModel.DataAnnotations;

public class AreaMaster
{
    [Key] // This attribute specifies it as the primary key
    public int AreaId { get; set; }

    public string AreaName { get; set; }
}
