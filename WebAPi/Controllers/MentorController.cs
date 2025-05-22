using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MentorController(MentorService mentorService) : ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> CreateMentorAsync(Mentor mentor)
    {
        return await mentorService.CreateMentorAsync(mentor);
    }

    [HttpGet]
    public async Task<Response<List<Mentor>>> GetAllMentorsAsync()
    {
        return await mentorService.GetAllMentorsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Mentor?>> GetMentorByIdAsync(int id)
    {
        return await mentorService.GetMentorByIdAsync(id);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateMentorAsync(Mentor mentor)
    {
        return await mentorService.UpdateMentorAsync(mentor);
    }

    [HttpDelete("{id:int}")]
    public async Task<Response<string>> DeleteMentorAsync(int id)
    {
        return await mentorService.DeleteMentorAsync(id);
    }
}
