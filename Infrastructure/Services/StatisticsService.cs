using Dapper;
using Domain.ApiResponse;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class StatisticsService(DataContext context) : IStatisticsService
{
    public async Task<Response<int>> GetTotalStudentsCount()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"Select count(*) from Students";
            var result = await connection.ExecuteScalarAsync<int>(cmd);
            return new Response<int>(result, "Success");
        }
    }

    public async Task<Response<int>> GetTotalGroupsCount()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"Select Distinct(count(*)) from Groups";
            var result = await connection.ExecuteScalarAsync<int>(cmd);
            return new Response<int>(result, "Succcess");
        }
    }

    public async Task<Response<int>> GetTotalCoursesCount()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"select Distinct(count(*)) from Courses";
            var result = await connection.ExecuteScalarAsync<int>(cmd);
            return new Response<int>(result, "Success");
        }
    }

    public async Task<Response<int>> GetTotalMentorsCount()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"Select count(*) from Mentors";
            var result = await connection.ExecuteScalarAsync<int>(cmd);
            return new Response<int>(result, "Success");
        }
    }

    public async Task<Response<List<DateTime>>> GetAllStartDates()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();

            string cmd = @"select Distinct(startDate) from Groups";
            var result = await connection.QueryAsync<DateTime>(cmd);
            return new Response<List<DateTime>>(result.ToList(), "Success");
        }
    }

}
