using System.Net;
using System.Text.RegularExpressions;
using Dapper;
using Domain.ApiResponse;
using Domain.DTOS;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class GroupService(DataContext context) : IGroupService
{
    public async Task<Response<string>> CreateGroupAsync(Group group)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"INSERT INTO Groups (GroupName, CourseId, MentorId, StartDate, EndDate)
                            VALUES (@GroupName, @CourseId, @MentorId, @StartDate, @EndDate)";
            var result = await connection.ExecuteAsync(cmd, group);
            if (result == 0)
            {
                return new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError);
            }
            return new Response<string>(null, "Group successfully created");
        }
    }

    public async Task<Response<List<Group>>> GetAllGroupsAsync()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"Select * from Groups";
            var result = await connection.QueryAsync<Group>(cmd);
            return new Response<List<Group>>(result.ToList(), "Groups retrieved successfuly");
        }
    }

    public async Task<Response<Group?>> GetGroupByIdAsync(int id)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"Select * from Groups where id = @id";
            var result = await connection.QueryFirstOrDefaultAsync<Group>(cmd, new { id = id });
            if (result == null)
            {
                return new Response<Group?>("Book not found", HttpStatusCode.NotFound);
            }
            return new Response<Group?>(result, "Book successfully retrieved");
        }
    }

    public async Task<Response<string>> UpdateGroupAsync(Group group)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = $@"Update Groups set 
                        groupName = @groupName, courseId = @courseId, mentorId = @mentorId, startDate = @startDate, endDate = @endDate
                        where id = @id";
            var result = await connection.ExecuteAsync(cmd, group);
            if (result == 0)
            {
                return new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError);
            }
            return new Response<string>(null, "Group successfully updated");
        }
    }

    public async Task<Response<string>> DeleteGroupAsync(int id)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = $@"Delete from Groups Where id = @id";
            var result = await connection.ExecuteAsync(cmd, new { id = id });
            if (result == 0)
            {
                return new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError);
            }
            return new Response<string>(null, "Groups successfully deleted");
        }
    }

    public async Task<Response<List<GroupDTO>>> GetStudentsPerGroup()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"Select g.id, g.groupName, count(sg.studentId)
                        from Groups as g
                        Join studentGroups as sg on g.id = sg.groupId
                        Group by g.id, g.groupName";
            var result = await connection.QueryAsync<GroupDTO>(cmd);
            return new Response<List<GroupDTO>>(result.ToList(), "Success");
        }
    }

    public async Task<Response<List<GroupDTO>>> GetEmptyGroups()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"Select g.id, g.groupName, count(sg.studentId) as countStudent
                        from Groups as g
                        left Join studentGroups as sg on g.id = sg.groupId
                        Group by g.id, g.groupName
						having countStudent = 0";
            var result = await connection.QueryAsync<GroupDTO>(cmd);
            return new Response<List<GroupDTO>>(result.ToList(), "Success");
        }
    }
}
