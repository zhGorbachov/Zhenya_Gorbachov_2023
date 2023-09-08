using Dal.Entities;

namespace Dal.Repositories.Interfaces;

public interface ITestRepository : IBaseRepository<Test>
{
    Task<IEnumerable<Test>> GetTestsByUserIdAsync(Guid userId);
    Task<Test> GetByIdWithQuestionsAsync(Guid id);
    Task<string> GetDescriptionAsync(Guid id);
}