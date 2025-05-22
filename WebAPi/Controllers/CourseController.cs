using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController(CourseService courseService) : ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> CreateCourseAsync(Course course)
    {
        return await courseService.CreateCourseAsync(course);
    }

    [HttpGet]
    public async Task<Response<List<Course>>> GetAllCoursesAsync()
    {
        return await courseService.GetAllCoursesAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Course?>> GetCourseByIdAsync(int id)
    {
        return await courseService.GetCourseByIdAsync(id);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateCourseAsync(Course course)
    {
        return await courseService.UpdateCourseAsync(course);
    }

    [HttpDelete("{id:int}")]
    public async Task<Response<string>> DeleteCourseAsync(int id)
    {
        return await courseService.DeleteCourseAsync(id);
    }
}
