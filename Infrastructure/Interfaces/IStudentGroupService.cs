using Domain.ApiResponse;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IStudentGroupService
{
    public Task<Response<string>> CreateStudentGroupAsync(StudentGroups studentGroup);
    public Task<Response<List<StudentGroups>>> GetAllStudentGroupsAsync();
    public Task<Response<string>> UpdateStudentGroupAsync(StudentGroups studentGroup);
    public Task<Response<string>> DeleteStudentGroupAsync(int id);
}
