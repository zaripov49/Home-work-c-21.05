using System.Text.RegularExpressions;
using Domain.ApiResponse;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupController(GroupService groupService) : ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> CreateGroupAsync(Group group)
    {
        return await groupService.CreateGroupAsync(group);
    }

    [HttpGet]
    public async Task<Response<List<Group>>> GetAllGroupsAsync()
    {
        return await groupService.GetAllGroupsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Group?>> GetGroupByIdAsync(int id)
    {
        return await groupService.GetGroupByIdAsync(id);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateGroupAsync(Group group)
    {
        return await groupService.UpdateGroupAsync(group);
    }

    [HttpDelete("{id:int}")]
    public async Task<Response<string>> DeleteGroupAsync(int id)
    {
        return await groupService.DeleteGroupAsync(id);
    }
}
