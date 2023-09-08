using Dal.Entities;
using Dal.Repositories.Interfaces;

namespace Dal.Repositories;

public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
{
    public QuestionRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}