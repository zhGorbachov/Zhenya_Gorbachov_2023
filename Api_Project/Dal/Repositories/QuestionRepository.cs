using Dal.Entities;
using Dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories;

public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
{
    public QuestionRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<IEnumerable<Question>> GetAllByTestIdAsync(Guid testId)
    {
        return await _dbContext.Set<Question>().Where(x => x.TestId == testId).ToListAsync();
    }
}