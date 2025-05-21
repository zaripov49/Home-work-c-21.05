using System.Net;
using Dapper;
using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class CourseService(DataContext context) : ICourseService
{
    public async Task<Response<string>> CreateCourseAsync(Course course)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"INSERT INTO Courses (Title, Description, DurationWeeks)
                            VALUES (@Title, @Description, @DurationWeeks)";
            var result = await connection.ExecuteAsync(cmd, course);
            if (result == 0)
            {
                return new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError);
            }
            return new Response<string>(null, "Course successfully created");
        }
    }

    public async Task<Response<List<Course>>> GetAllCoursesAsync()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"Select * from Courses";
            var result = await connection.QueryAsync<Course>(cmd);
            return new Response<List<Course>>(result.ToList(), "Courses retrieved successfuly");
        }
    }

    public async Task<Response<Course?>> GetCourseByIdAsync(int id)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"Select * from Courses where id = @id";
            var result = await connection.QueryFirstOrDefaultAsync<Course>(cmd, new { id = id });
            if (result == null)
            {
                return new Response<Course?>("Book not found", HttpStatusCode.NotFound);
            }
            return new Response<Course?>(result, "Book successfully retrieved");
        }
    }

    public async Task<Response<string>> UpdateCourseAsync(Course course)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = $@"Update Courses set 
                        title = @title, Description = @Description, DurationWeeks = @DurationWeeks 
                        where id = @id";
            var result = await connection.ExecuteAsync(cmd, course);
            if (result == 0)
            {
                return new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError);
            }
            return new Response<string>(null, "Course successfully updated");
        }
    }

    public async Task<Response<string>> DeleteCourseAsync(int id)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = $@"Delete from Courses Where id = @id";
            var result = await connection.ExecuteAsync(cmd, new { id = id });
            if (result == 0)
            {
                return new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError);
            }
            return new Response<string>(null, "Courses successfully deleted");
        }
    }
}
