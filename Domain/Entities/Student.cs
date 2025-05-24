using Microsoft.AspNetCore.Http;

namespace Domain.Entities;

public class Student
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public IFormFile? Photo { get; set; }
}
