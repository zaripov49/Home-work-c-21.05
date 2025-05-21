namespace Domain.Entities;

public class Course
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int DurationWeeks { get; set; }
}
