using Dal.Entities;

namespace Dal.Repositories.Interfaces;

public interface IQuestionRepository : IBaseRepository<Question>
{
    public Task<IEnumerable<Question>> GetAllByTestIdAsync(Guid testId);
}