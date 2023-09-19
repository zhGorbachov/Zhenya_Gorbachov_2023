using AutoMapper;
using Bll.Models;
using Bll.Services;
using Dal.Entities;
using Dal.Repositories.Interfaces;
using Moq;

namespace TestsBll.ServiceTests;

public class QuestionServiceTests
{
    private Mock<IQuestionRepository> _questionRepositoryMock = new Mock<IQuestionRepository>();
    private Mock<IMapper> _mapperMock = new Mock<IMapper>();

    [Fact]
    public async Task GetQuestionsByTestIdAsync_Success_RepositoryAndMapperUsed()
    {
        // arrange
        _questionRepositoryMock.Setup(m => m.GetAllByTestIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(new List<Question>());
        _mapperMock.Setup(m => m.Map<IEnumerable<Question>, IEnumerable<QuestionModel>>
            (It.IsAny<IEnumerable<Question>>())).Returns(new List<QuestionModel>());

        var service = new QuestionService(_questionRepositoryMock.Object, _mapperMock.Object);

        // act

        var result = await service.GetQuestionsByTestIdAsync(It.IsAny<Guid>());

        // assert
        _questionRepositoryMock.Verify(x => x.GetAllByTestIdAsync(It.IsAny<Guid>()));
        _mapperMock.Verify(x => x.Map<IEnumerable<QuestionModel>>(It.IsAny<IEnumerable<Question>>()));
    }
}