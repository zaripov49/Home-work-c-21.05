using Domain.ApiResponse;

namespace Infrastructure.Interfaces;

public interface IStatisticsService
{
    public Task<Response<int>> GetTotalStudentsCount();
    public Task<Response<int>> GetTotalGroupsCount();
    public Task<Response<int>> GetTotalCoursesCount();
    public Task<Response<int>> GetTotalMentorsCount();
    public Task<Response<List<DateTime>>> GetAllStartDates();
}
