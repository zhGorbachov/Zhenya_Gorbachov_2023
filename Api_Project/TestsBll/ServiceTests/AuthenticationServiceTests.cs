
using Bll.Services;
using Dal.Entities;
using Dal.Repositories.Interfaces;
using Moq;

namespace TestsBll.ServiceTests;

public class AuthenticationServiceTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();

    [Theory]
    [InlineData("surname1", "12345", "c687b3fb-d8b6-43bc-b31c-7f68c5df3f1d")]
    [InlineData("surname4", "3315", "bf396d4e-e98e-4057-9f0c-041121096a7c")]
    public async Task AuthenticateAsync_CorrectData_ReturnedUserId(
        string surname, string password, string expectedId)
    {
        // arrange
        _userRepositoryMock.Setup(m => m.GetUserByCredentialsAsync(surname, password))!
            .ReturnsAsync(GetTestUserEntities.FirstOrDefault(x => x.Surname == surname && x.Password == password));

        var service = new AuthenticationService(_userRepositoryMock.Object);

        // act
        var result = await service.AuthenticateAsync(surname, password);

        // assert
        _userRepositoryMock.Verify(x => x.GetUserByCredentialsAsync(surname, password), Times.Once);
        Assert.Equal(expectedId, result.ToString());
    }

    private IEnumerable<User> GetTestUserEntities => new List<User>
    {
        new() { Id = Guid.Parse("c687b3fb-d8b6-43bc-b31c-7f68c5df3f1d"), Name = "name1", Surname = "surname1", Password = "12345" },
        new() { Id = Guid.Parse("bf396d4e-e98e-4057-9f0c-041121096a7c"), Name = "name1", Surname = "surname4", Password = "3315" }
    };
}