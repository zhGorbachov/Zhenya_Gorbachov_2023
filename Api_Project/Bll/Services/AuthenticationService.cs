using Bll.Exceptions;
using Bll.Services.Interfaces;
using Dal.Repositories.Interfaces;

namespace Bll.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> AuthenticateAsync(string surname, string password)
    {
        var user = await _userRepository.GetUserByCredentialsAsync(surname, password);
        if (user is not null)
        {
            return Guid.Parse(user.Id.ToString());
        }
        
        throw new AuthException();
    }
}