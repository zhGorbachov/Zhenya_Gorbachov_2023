using Dal.Entities;

namespace Dal.Repositories.Interfaces;

public interface IAnswerRepository : IBaseRepository<Answer>
{
    Task<bool> CheckIsCorrectAsync(Guid id);
    Task<IEnumerable<Answer>> GetAllByQuestionIdAsync(Guid questionId);
}