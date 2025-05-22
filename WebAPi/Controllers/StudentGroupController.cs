using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentGroupController(StudentGroupService studentGroupService) : ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> CreateStudentAsync(StudentGroups studentGroups)
    {
        return await studentGroupService.CreateStudentGroupAsync(studentGroups);
    }

    [HttpGet]
    public async Task<Response<List<StudentGroups>>> GetAllStudentsAsync()
    {
        return await studentGroupService.GetAllStudentGroupsAsync();
    }

    [HttpPut]
    public async Task<Response<string>> UpdateStudentAsync(StudentGroups studentGroups)
    {
        return await studentGroupService.UpdateStudentGroupAsync(studentGroups);
    }

    [HttpDelete("{id:int}")]
    public async Task<Response<string>> DeleteStudentAsync(int id)
    {
        return await studentGroupService.DeleteStudentGroupAsync(id);
    }
}
