using Domain.ApiResponse;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatisticsController(StatisticsService statisticsService) : ControllerBase
{
    [HttpGet("get-total-student-count")]
    public async Task<Response<int>> GetTotalStudentsCount()
    {
        return await statisticsService.GetTotalStudentsCount();
    }

    [HttpGet("get-total-groups-count")]
    public async Task<Response<int>> GetTotalGroupsCount()
    {
        return await statisticsService.GetTotalGroupsCount();
    }

    [HttpGet("get-total-courses-count")]
    public async Task<Response<int>> GetTotalCoursesCount()
    {
        return await statisticsService.GetTotalCoursesCount();
    }

    [HttpGet("get-total-mentors-count")]
    public async Task<Response<int>> GetTotalMentorsCount()
    {
        return await statisticsService.GetTotalMentorsCount();
    }

    [HttpGet("get-all-start-date")]
    public async Task<Response<List<DateTime>>> GetAllStartDates()
    {
        return await statisticsService.GetAllStartDates();
    }
}
