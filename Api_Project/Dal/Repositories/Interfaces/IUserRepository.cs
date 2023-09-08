using Dal.Entities;

namespace Dal.Repositories.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetUserByCredentialsAsync(string name, string password);
}