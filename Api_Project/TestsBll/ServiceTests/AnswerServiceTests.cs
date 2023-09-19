using AutoMapper;
using Bll.Models;
using Bll.Services;
using Dal.Entities;
using Dal.Repositories.Interfaces;
using Moq;

namespace TestsBll.ServiceTests;

public class AnswerServiceTests
{
    private Mock<IAnswerRepository> _answerRepositoryMock = new Mock<IAnswerRepository>();
    private Mock<IMapper> _mapperMock = new Mock<IMapper>();

    [Fact]
    public async Task GetAnswersByQuestionIdAsync_RepositoryAndMappingUsed()
    {
        // arrange
        _answerRepositoryMock.Setup(m => m.GetAllByQuestionIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(new List<Answer>());
        _mapperMock.Setup(m => m.Map<IEnumerable<Answer>, IEnumerable<AnswerModel>>
            (It.IsAny<IEnumerable<Answer>>())).Returns(new List<AnswerModel>());

        var service = new AnswerService(_answerRepositoryMock.Object, _mapperMock.Object);

        // act 
        await service.GetAnswersByQuestionIdAsync(It.IsAny<Guid>());

        // assert
        _answerRepositoryMock.Verify(x => x.GetAllByQuestionIdAsync(It.IsAny<Guid>()));
        _mapperMock.Verify(x => x.Map<IEnumerable<AnswerModel>>(It.IsAny<IEnumerable<Answer>>()));
    }

    [Fact]
    public async Task CheckAnswerByIdAsync_RepositoryIsUsed()
    {
        // arrange
        _answerRepositoryMock.Setup(m => m.CheckIsCorrectAsync(It.IsAny<Guid>()))
            .ReturnsAsync(It.IsAny<bool>());

        var service = new AnswerService(_answerRepositoryMock.Object, _mapperMock.Object);
        
        // act
        await service.CheckAnswerByIdAsync(It.IsAny<Guid>());
        
        // assert
        _answerRepositoryMock.Verify(x => x.CheckIsCorrectAsync(It.IsAny<Guid>()));
    }
}