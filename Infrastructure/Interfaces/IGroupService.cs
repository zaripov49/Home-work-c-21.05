using System.Text.RegularExpressions;
using Domain.ApiResponse;
using Domain.DTOS;

namespace Infrastructure.Interfaces;

public interface IGroupService
{
    public Task<Response<string>> CreateGroupAsync(Group group);
    public Task<Response<List<Group>>> GetAllGroupsAsync();
    public Task<Response<Group?>> GetGroupByIdAsync(int id);
    public Task<Response<string>> UpdateGroupAsync(Group group);
    public Task<Response<string>> DeleteGroupAsync(int id);
    public Task<Response<List<GroupDTO>>> GetStudentsPerGroup();
    public Task<Response<List<GroupDTO>>> GetEmptyGroups();
}
