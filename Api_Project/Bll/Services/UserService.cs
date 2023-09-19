using AutoMapper;
using Bll.Exceptions;
using Bll.Models;
using Bll.Models.AddModels;
using Bll.Models.UpdateModels;
using Bll.Services.Interfaces;
using Dal.Entities;
using Dal.Repositories.Interfaces;

namespace Bll.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task AddUserAsync(AddUserModel userModel)
    {
        if (userModel.Name == "" || userModel.Surname == "" || userModel.Password == "")
        {
            throw new ModelIsEmptyException();
        }
        
        var entity = _mapper.Map<User>(userModel);
        await _userRepository.AddAsync(entity);
    }

    public async Task UpdateUserAsync(UpdateUserModel userModel)
    {
        if (userModel.Id == "" || userModel.Name == "" || userModel.Surname == "" || userModel.Password == "")
        {
            throw new ModelIsEmptyException();
        }
        
        var oldId = Guid.Parse(userModel.Id);
        var userOld = await _userRepository.GetByIdAsync(oldId);
        _mapper.Map(userModel, userOld);
        await _userRepository.UpdateAsync(userOld);
    }

    public async Task DeleteUserAsync(Guid id)
    {
        await _userRepository.DeleteAsync(id);
    }

    public async Task<UserModel> GetUserAsync(Guid id)
    {
        var entity = await _userRepository.GetByIdAsync(id);
        var userModel = _mapper.Map<UserModel>(entity);
        return userModel;
    }
}