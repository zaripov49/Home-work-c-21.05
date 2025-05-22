using Domain.ApiResponse;
using Domain.DTOS;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IStudentService
{
    public Task<Response<string>> CreateStudentAsync(Student student);
    public Task<Response<List<Student>>> GetAllStudentsAsync();
    public Task<Response<Student?>> GetStudentByIdAsync(int id);
    public Task<Response<string>> UpdateStudentAsync(Student student);
    public Task<Response<string>> DeleteStudentAsync(int id);
    public Task<Response<List<StudentByGroup>>> GetStudentsWithGroupsAsync();
    public Task<Response<List<Student>>> GetStudentsWithoutGroupsAsync();
    public Task<Response<List<Student>>> GetDroppedOutStudentsAsync();
    public Task<Response<List<Student>>> GetGraduatedStudentsAsync();
}
