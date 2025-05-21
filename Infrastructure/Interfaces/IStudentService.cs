using Domain.ApiResponse;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IStudentService
{
    public Task<Response<string>> CreateStudentAsync(Student student);
    public Task<Response<List<Student>>> GetAllStudentsAsync();
    public Task<Response<Student?>> GetStudentByIdAsync(int id);
    public Task<Response<string>> UpdateStudentAsync(Student student);
    public Task<Response<string>> DeleteStudentAsync(int id);
}
