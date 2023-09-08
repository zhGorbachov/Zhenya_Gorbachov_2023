using Dal.Entities;
using Dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories;

public class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
{
    public AnswerRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> CheckIsCorrectAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        
        if (entity.IsCorrect)
            return true;

        return false;
    }

    public async Task<IEnumerable<Answer>> GetAllByQuestionIdAsync(Guid questionId)
    {
        return await _dbContext.Set<Answer>().Where(x => x.QuestionId == questionId).ToListAsync();
    }
}