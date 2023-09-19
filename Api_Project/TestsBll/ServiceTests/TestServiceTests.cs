using AutoMapper;
using Bll.Models;
using Bll.Models.AddModels;
using Bll.Models.UpdateModels;
using Bll.Services;
using Dal.Entities;
using Dal.Repositories.Interfaces;
using Moq;

namespace TestsBll.ServiceTests;

public class TestServiceTests
{
    private Mock<ITestRepository> _testRepositoryMock = new();
    private Mock<IMapper> _mapperMock = new();

    [Fact]
    public async Task GetTestsByUserIdAsync_ReturnsCollectionOfStrings()
    {
        // arrange
        var userId = Guid.Parse("2e0f90de-a603-4662-97bd-776eaf18fc0f");
        _testRepositoryMock.Setup(m => m.GetTestsByUserIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(GetTestEntities.Where(x => x.CreatedForUserId == userId));
        
        var service = new TestService(_testRepositoryMock.Object, _mapperMock.Object);

        // act
        var result  = await service.GetTestsByUserIdAsync(userId);

        // assert
        _testRepositoryMock.Verify(x => x.GetTestsByUserIdAsync(userId));
        _mapperMock.Verify(x => x.Map<IEnumerable<TestModel>>(It.IsAny<IEnumerable<Test>>()));
    }

    [Fact]
    public async Task GetTestDescriptionAsync_ReturnsDescription()
    {
        // arrange
        _testRepositoryMock.Setup(m => m.GetDescriptionAsync(It.IsAny<Guid>()));

        var service = new TestService(_testRepositoryMock.Object, _mapperMock.Object);

        // act
        await service.GetTestDescriptionAsync(It.IsAny<Guid>());

        // assert 
        _testRepositoryMock.Verify(x => x.GetDescriptionAsync(It.IsAny<Guid>()));
    }

    [Fact]
    public async Task GetTestWithQuestionsAsync_TestExists_ModelIsReturned()
    {
        // arrange
        var test = GetTestWithQuestions;
        
        _testRepositoryMock.Setup(m => m.GetByIdWithQuestionsAsync(It.IsAny<Guid>()))
            .ReturnsAsync(test);
        _mapperMock.Setup(m => m.Map<Test, TestModel>(It.IsAny<Test>()))
            .Returns(new TestModel());

        var service = new TestService(_testRepositoryMock.Object, _mapperMock.Object);

        // act 
        var result = await service.GetTestWithQuestionsAsync(It.IsAny<Guid>());

        // assert
        _testRepositoryMock.Verify(x => x.GetByIdWithQuestionsAsync(It.IsAny<Guid>()));
        _mapperMock.Verify(x => x.Map<TestModel>(test));
    }
    
    [Fact]
    public async Task DeleteTestAsync_TestIsDeleted()
    {
        // arrange
        var testId = Guid.NewGuid();
        _testRepositoryMock.Setup(m => m.DeleteAsync(testId));

        var service = new TestService(_testRepositoryMock.Object, _mapperMock.Object);
        
        // act
        await service.DeleteTestAsync(testId);
        
        // assert 
        _testRepositoryMock.Verify(x => x.DeleteAsync(testId));
    }

    [Fact]
    public async Task AddTestAsync_TestIsAdded()
    {
        // arrange
        _testRepositoryMock.Setup(m => m.AddAsync(It.IsAny<Test>()));
        _mapperMock.Setup(m => m.Map<AddTestModel, Test>(It.IsAny<AddTestModel>()))
            .Returns(new Test());

        var service = new TestService(_testRepositoryMock.Object, _mapperMock.Object);
        
        // act
        await service.AddTestAsync(It.IsAny<AddTestModel>());
        
        // assert
        _mapperMock.Verify(x => x.Map<Test>(It.IsAny<TestModel>()));
        _testRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Test>()));
    }

    [Fact]
    public async Task UpdateAsync_OldTestSelected_TestUpdated()
    {
        // arrange 
        var testId = Guid.NewGuid();
        // two setups for select methods
        _testRepositoryMock.Setup(m => m.GetByIdAsync(testId))
            .ReturnsAsync(new Test() { Id = testId });
        _testRepositoryMock.Setup(m => m.GetWithQuestionsAndAnswerAsync(testId))
            .ReturnsAsync(new Test() { Id = testId });
        _testRepositoryMock.Setup(m => m.UpdateAsync(It.Is<Test>(t => t.Id == testId)));
        _mapperMock.Setup(m => m.Map(It.Is<UpdateTestModel>(t => t.Id == testId.ToString()), It.IsAny<Test>()))
            .Returns(new Test() { Id = testId });
        
        var service = new TestService(_testRepositoryMock.Object, _mapperMock.Object);
        
        // act 
        await service.UpdateTestAsync(new UpdateTestModel() { Id = testId.ToString() });
        
        // assert
        _mapperMock.Verify(x => x.Map(It.Is<UpdateTestModel>(t => t.Id == testId.ToString()), It.IsAny<Test>()));
        _testRepositoryMock.Verify(x => x.UpdateAsync(It.Is<Test>(t => t.Id == testId)));
    }

    private static IEnumerable<Test> GetTestEntities => new List<Test>
    {
        new() { Id = Guid.Parse("ed5790c7-83ca-4b9f-af22-d10affe65ba9"), CreatedForUserId = Guid.Parse("2e0f90de-a603-4662-97bd-776eaf18fc0f")},
        new() { Id = Guid.Parse("71e08241-2181-4230-bed2-d7c4cb832e1a"), CreatedForUserId = Guid.Parse("2e0f90de-a603-4662-97bd-776eaf18fc0f")},
        new() { Id = Guid.Parse("1c6938cb-ba45-4028-9f04-88dd259d82bf"), CreatedForUserId = Guid.Parse("ab12630f-7eea-403f-a81e-3c1c9d579402") }
    };

    private static Test GetTestWithQuestions => new Test
    {
        Id = Guid.NewGuid(),
        Title = "TestTest",
        Description = "Some desc",
        Questions = new List<Question>
        {
            new() { Id = Guid.NewGuid() },
            new() { Id = Guid.NewGuid() }
        }
    };
}