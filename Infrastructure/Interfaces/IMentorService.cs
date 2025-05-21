using Domain.ApiResponse;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IMentorService
{
    public Task<Response<string>> CreateMentorAsync(Mentor mentor);
    public Task<Response<List<Mentor>>> GetAllMentorsAsync();
    public Task<Response<Mentor?>> GetMentorByIdAsync(int id);
    public Task<Response<string>> UpdateMentorAsync(Mentor mentor);
    public Task<Response<string>> DeleteMentorAsync(int id);
}
