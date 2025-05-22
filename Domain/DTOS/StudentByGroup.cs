namespace Domain.DTOS;

public class StudentByGroup
{
    public int StudentId { get; set; }
    public string? FullName { get; set; }
    public int GroupId { get; set; }
    public string? GroupName { get; set; }
}
