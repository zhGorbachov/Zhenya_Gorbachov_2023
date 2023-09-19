using AutoMapper;
using Bll.Exceptions;
using Bll.Models;
using Bll.Models.AddModels;
using Bll.Models.UpdateModels;
using Bll.Services;
using Dal.Entities;
using Dal.Repositories.Interfaces;
using Moq;

namespace TestsBll.ServiceTests;

public class UserServiceTests
{
    private Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
    private Mock<IMapper> _mapperMock = new Mock<IMapper>();

    [Theory]
    [InlineData("c687b3fb-d8b6-43bc-b31c-7f68c5df3f1d")]
    [InlineData("bf396d4e-e98e-4057-9f0c-041121096a7c")]
    public async Task GetUserAsync_UserExists_ResultReceived(string id)
    {
        var guid = Guid.Parse(id);
        var expected = GetTestUserModels.First(x => x.Id == id);
        
        _userRepositoryMock.Setup(m => m.GetByIdAsync(guid))!
            .ReturnsAsync(GetTestUserEntities.FirstOrDefault(x => x.Id == guid));
        _mapperMock.Setup(m => m.Map<User, UserModel>
            (It.IsAny<User>())).Returns(expected);

        var service = new UserService(_userRepositoryMock.Object, _mapperMock.Object);

        // act
        var result = await service.GetUserAsync(guid);

        // assert
        _userRepositoryMock.Verify(x => x.GetByIdAsync(guid), Times.Once);
        _mapperMock.Verify(x => x.Map<UserModel>(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public async Task AddUserAsync_ValidData_UserAdded()
    {
        // arrange
        _mapperMock.Setup(m => m.Map<AddUserModel, User>
            (It.IsAny<AddUserModel>())).Returns(new User());
        _userRepositoryMock.Setup(m => m.AddAsync(It.IsAny<User>()));

        var service = new UserService(_userRepositoryMock.Object, _mapperMock.Object);
        var newUser = new AddUserModel {  Name = "User", Surname = "AgainUser", Password = "Password" };
        
        // act
        await service.AddUserAsync(newUser);

        // assert
        _mapperMock.Verify(x => x.Map<User>(newUser));
        _userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()));
    }

    [Fact]
    public async Task AddUserAsync_ModelHasEmptyFields_ThrowsUserModelEmptyFieldException()
    {
        // arrange
        _mapperMock.Setup(m => m.Map<AddUserModel, User>
            (It.IsAny<AddUserModel>())).Returns(new User());
        _userRepositoryMock.Setup(m => m.AddAsync(It.IsAny<User>()));

        var service = new UserService(_userRepositoryMock.Object, _mapperMock.Object);
        var newUser = new AddUserModel {  Name = "", Surname = "", Password = "" };
        
        // act
        var act = async () => await service.AddUserAsync(newUser);

        // assert
        await Assert.ThrowsAsync<ModelIsEmptyException>(act);
    }

    [Fact]
    public async Task UpdateUserAsync_ValidData_UserUpdated()
    {
        // arrange
        _userRepositoryMock.Setup(m => m.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(It.IsAny<User>());
        _mapperMock.Setup(m => m.Map<UpdateUserModel, User>
            (It.IsAny<UpdateUserModel>(), It.IsAny<User>())).Returns(new User());
        _userRepositoryMock.Setup(m => m.UpdateAsync(It.IsAny<User>()));

        var service = new UserService(_userRepositoryMock.Object, _mapperMock.Object);
        var updated = new UpdateUserModel { Id = Guid.NewGuid().ToString() ,Name = "User", Surname = "AgainUser", Password = "Password" };
        
        // act
        await service.UpdateUserAsync(updated);

        // assert
        _mapperMock.Verify(x => x.Map(updated, It.IsAny<User>()));
        _userRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<User>()));
    }

    [Fact]
    public async Task UpdateUserAsync_ModelHasEmptyFields_ThrowsUserModelEmptyFieldException()
    {
        // arrange
        _userRepositoryMock.Setup(m => m.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(It.IsAny<User>());
        _mapperMock.Setup(m => m.Map<UpdateUserModel, User>
            (It.IsAny<UpdateUserModel>(), It.IsAny<User>())).Returns(new User());
        _userRepositoryMock.Setup(m => m.UpdateAsync(It.IsAny<User>()));

        var service = new UserService(_userRepositoryMock.Object, _mapperMock.Object);
        var user = new UpdateUserModel { Id = Guid.NewGuid().ToString() ,Name = "", Surname = "", Password = "" };
        
        // act
        var act = async () => await service.UpdateUserAsync(user);

        // assert
        await Assert.ThrowsAsync<ModelIsEmptyException>(act);
    }

    [Theory]
    [InlineData("c687b3fb-d8b6-43bc-b31c-7f68c5df3f1d")]
    [InlineData("bf396d4e-e98e-4057-9f0c-041121096a7c")]
    public async Task DeleteUserAsync_UserDeleted(string id)
    {
        // arrange
        _userRepositoryMock.Setup(m => m.DeleteAsync(It.IsAny<Guid>()));

        var service = new UserService(_userRepositoryMock.Object, _mapperMock.Object);
        var guid = Guid.Parse(id);
        
        // act
        await service.DeleteUserAsync(guid);
        
        // assert
        _userRepositoryMock.Verify(x => x.DeleteAsync(guid));
    }
    
    private IEnumerable<User> GetTestUserEntities => new List<User>
    {
        new() { Id = Guid.Parse("c687b3fb-d8b6-43bc-b31c-7f68c5df3f1d"), Name = "name1", Surname = "surname1", Password = "12345" },
        new() { Id = Guid.Parse("bf396d4e-e98e-4057-9f0c-041121096a7c"), Name = "name1", Surname = "surname4", Password = "3315" }
    };
    
    private IEnumerable<UserModel> GetTestUserModels => new List<UserModel>
    {
        new() { Id = "c687b3fb-d8b6-43bc-b31c-7f68c5df3f1d", Name = "name1", Surname = "surname1" },
        new() { Id = "bf396d4e-e98e-4057-9f0c-041121096a7c", Name = "name1", Surname = "surname4" }
    };
}