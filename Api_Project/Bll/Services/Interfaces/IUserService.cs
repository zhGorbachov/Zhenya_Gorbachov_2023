using Bll.Models;
using Bll.Models.AddModels;
using Bll.Models.UpdateModels;

namespace Bll.Services.Interfaces;

public interface IUserService
{
    public Task AddUserAsync(AddUserModel userModel);
    public Task UpdateUserAsync(UpdateUserModel userModel);
    public Task DeleteUserAsync(Guid id);
    public Task<UserModel> GetUserAsync(Guid id);
}