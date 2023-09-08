using Dal;
using Dal.Entities;
using Dal.Repositories;
using NUnit.Framework;
using Tests.Data;

namespace Tests.DataTests;

public class UserRepositoryTests
{
    [TestCase("585dbcf1-2a39-4e24-8b66-2339ab6bdbab")]
    [TestCase("96865278-eff1-4be5-88a2-6d1272e2feeb")]
    public async Task UserRepository_GetByIdAsync_ReturnsValue(string id)
    {
        // arrange

        using var context = new AppDbContext(UnitTestHelper.GetUnitTestsDbOptions());
        var userRepository = new UserRepository(context);

        var expected = RepositoryData.ExpectedUsers.FirstOrDefault(x => x.Id.ToString() == id);

        // act

        var result = await userRepository.GetByIdAsync(Guid.Parse(id));

        // assert

        Assert.IsNotNull(result, message: "Expected not null");
        Assert.That(result, Is.EqualTo(expected).Using(new UserEqualityComparer()), message: "Result is invalid");
    }

    [Test]
    public async Task UserRepository_GetAllAsync_ReturnsAllValues()
    {
        using var context = new AppDbContext(UnitTestHelper.GetUnitTestsDbOptions());
        var userRepository = new UserRepository(context);

        var result = await userRepository.GetAllAsync();

        Assert.That(result, Is.EqualTo(RepositoryData.ExpectedUsers).Using(new UserEqualityComparer()),
            message: "Results are not equal to expected");
    }

    [Test]
    public async Task UserRepository_AddAsync_AddsValueToDatabase()
    {
        using var context = new AppDbContext(UnitTestHelper.GetUnitTestsDbOptions());
        var userRepository = new UserRepository(context);

        var newUser = new User { Name = "Name", Surname = "Surname", Password = "Pswrd" };

        await userRepository.AddAsync(newUser);
        await context.SaveChangesAsync();

        Assert.That(context.Users.Count(), !Is.EqualTo(RepositoryData.ExpectedUsers.Count()), message: "AddAsync works");
    }

    [Test]
    public async Task UserRepository_UpdateAsync_ValueUpdated()
    {
        using var context = new AppDbContext(UnitTestHelper.GetUnitTestsDbOptions());
        var userRepository = new UserRepository(context);

        var userId = Guid.Parse("585dbcf1-2a39-4e24-8b66-2339ab6bdbab");
        var notExpected = RepositoryData.ExpectedUsers.FirstOrDefault(x => x.Id == userId);
        var user = new User
        {
            Id = userId,
            Name = "Name",
            Surname = "Surname",
            Password = "Pswrd"
        };

        await userRepository.UpdateAsync(user);
        await context.SaveChangesAsync();

        Assert.That(user, !Is.EqualTo(notExpected), message: "UpdateAsync works");
    }

    [TestCase("585dbcf1-2a39-4e24-8b66-2339ab6bdbab")]
    [TestCase("96865278-eff1-4be5-88a2-6d1272e2feeb")]
    public async Task UserRepository_DeleteAsync_ObjectIsDeleted(string id)
    {
        using var context = new AppDbContext(UnitTestHelper.GetUnitTestsDbOptions());

        var userRepository = new UserRepository(context);

        await userRepository.DeleteAsync(Guid.Parse(id));
        await context.SaveChangesAsync();

        Assert.That(context.Users.Count(), !Is.EqualTo(RepositoryData.ExpectedUsers.Count()), message: "DeleteByIdAsync works incorrect");
    }

    [Test]
    public async Task UserRepository_GetUserByCredentialsAsync_CredentialsAreCorrect_UserReturned()
    {
        using var context = new AppDbContext(UnitTestHelper.GetUnitTestsDbOptions());

        var userRepository = new UserRepository(context);

        var name = "Name2";
        var password = "drowssaP";

        var expected = RepositoryData.ExpectedUsers.FirstOrDefault(x => x.Name == name && x.Password == password);
        
        var result = await userRepository.GetUserByCredentialsAsync(name, password);

        Assert.That(result, Is.EqualTo(expected).Using(new UserEqualityComparer()), message: "User is invalid, and me too");
    }
}