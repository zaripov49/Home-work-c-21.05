using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController(StudentService studentService) : ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> CreateStudentAsync(Student student)
    {
        return await studentService.CreateStudentAsync(student);
    }

    [HttpGet]
    public async Task<Response<List<Student>>> GetAllStudentsAsync()
    {
        return await studentService.GetAllStudentsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Student?>> GetStudentByIdAsync(int id)
    {
        return await studentService.GetStudentByIdAsync(id);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateStudentAsync(Student student)
    {
        return await studentService.UpdateStudentAsync(student);
    }

    [HttpDelete("{id:int}")]
    public async Task<Response<string>> DeleteStudentAsync(int id)
    {
        return await studentService.DeleteStudentAsync(id);
    }
}
