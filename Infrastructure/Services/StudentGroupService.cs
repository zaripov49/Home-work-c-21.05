using System.Net;
using Dapper;
using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class StudentGroupService(DataContext context) : IStudentGroupService
{
    public async Task<Response<string>> CreateStudentGroupAsync(StudentGroups studentGroup)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"INSERT INTO StudentGroups (StudentId, GroupId, Status)
                            VALUES (@StudentId, @GroupId, @Status)";
            var result = await connection.ExecuteAsync(cmd, studentGroup);
            if (result == 0)
            {
                return new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError);
            }
            return new Response<string>(null, "StudentGroup successfully created");
        }
    }

    public async Task<Response<List<StudentGroups>>> GetAllStudentGroupsAsync()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"Select * from StudentGroups";
            var result = await connection.QueryAsync<StudentGroups>(cmd);
            return new Response<List<StudentGroups>>(result.ToList(), "StudentGroups retrieved successfuly");
        }
    }

    public async Task<Response<string>> UpdateStudentGroupAsync(StudentGroups studentGroup)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = $@"Update StudentGroups set 
                        studentId = @studentId, groupId = @groupId, status = @status 
                        where id = @id";
            var result = await connection.ExecuteAsync(cmd, studentGroup);
            if (result == 0)
            {
                return new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError);
            }
            return new Response<string>(null, "StudentGroup successfully updated");
        }
    }

    public async Task<Response<string>> DeleteStudentGroupAsync(int id)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = $@"Delete from StudentGroups Where id = @id";
            var result = await connection.ExecuteAsync(cmd, new { id = id });
            if (result == 0)
            {
                return new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError);
            }
            return new Response<string>(null, "StudentGroups successfully deleted");
        }
    }
}
