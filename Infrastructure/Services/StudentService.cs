using System.Net;
using Dapper;
using Domain.ApiResponse;
using Domain.DTOS;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class StudentService(DataContext context) : IStudentService
{
    public async Task<Response<string>> CreateStudentAsync(Student student)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"INSERT INTO Students (FullName, Email, Phone, EnrollmentDate)
                            VALUES (@FullName, @Email, @Phone, @EnrollmentDate)";
            var result = await connection.ExecuteAsync(cmd, student);
            if (result == 0)
            {
                return new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError);
            }
            return new Response<string>(null, "Student successfully created");
        }
    }

    public async Task<Response<List<Student>>> GetAllStudentsAsync()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"Select * from Students";
            var result = await connection.QueryAsync<Student>(cmd);
            return new Response<List<Student>>(result.ToList(), "Students retrieved successfuly");
        }
    }

    public async Task<Response<Student?>> GetStudentByIdAsync(int id)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"Select * from Students where id = @id";
            var result = await connection.QueryFirstOrDefaultAsync<Student>(cmd, new { id = id });
            if (result == null)
            {
                return new Response<Student?>("Book not found", HttpStatusCode.NotFound);
            }
            return new Response<Student?>(result, "Book successfully retrieved");
        }
    }

    public async Task<Response<string>> UpdateStudentAsync(Student student)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = $@"Update Students set 
                        fullName = @fullName, email = @email, phone = @phone, enrollmentDate = @enrollmentDate 
                        where id = @id";
            var result = await connection.ExecuteAsync(cmd, student);
            if (result == 0)
            {
                return new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError);
            }
            return new Response<string>(null, "Student successfully updated");
        }
    }

    public async Task<Response<string>> DeleteStudentAsync(int id)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = $@"Delete from Students Where id = @id";
            var result = await connection.ExecuteAsync(cmd, new { id = id });
            if (result == 0)
            {
                return new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError);
            }
            return new Response<string>(null, "Students successfully deleted");
        }
    }

    public async Task<Response<List<StudentByGroup>>> GetStudentsWithGroupsAsync()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"Select s.id, s.fullName, g.id, g.groupName
                            from Students as s
                            Join StudentGroups as st on s.id = st.studentId
                            Join Groups as g on st.groupId = g.id";
            var result = await connection.QueryAsync<StudentByGroup>(cmd);
            return new Response<List<StudentByGroup>>(result.ToList(), "Successfully");
        }
    }

    public async Task<Response<List<Student>>> GetStudentsWithoutGroupsAsync()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"Select (s.*) from Students as s
                        left join StudentGroups sg on s.Id = sg.studentId
                        where sg.studentId is null";
            var result = await connection.QueryAsync<Student>(cmd);
            return new Response<List<Student>>(result.ToList(), "Successfully");
        }
    }

    public async Task<Response<List<Student>>> GetDroppedOutStudentsAsync()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"Select * from Students as s
                        Join StudentGroups as sg on s.id = sg.studentId
                        where sg.status = 2";
            var result = await connection.QueryAsync<Student>(cmd);
            return new Response<List<Student>>(result.ToList(), "Successfully");
        }
    }

    public async Task<Response<List<Student>>> GetGraduatedStudentsAsync()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"Select * from Students as s
                        Join StudentGroups as sg on s.id = sg.studentId
                        where sg.status = 3";
            var result = await connection.QueryAsync<Student>(cmd);
            return new Response<List<Student>>(result.ToList(), "Successfully");
        }
    }

}
