using Domain.Enums;

namespace Domain.Entities;

public class StudentGroups
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int GroupId { get; set; }
    public Status Status { get; set; }
}
