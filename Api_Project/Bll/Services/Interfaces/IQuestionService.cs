using Bll.Models;

namespace Bll.Services.Interfaces;

public interface IQuestionService
{
    public Task<IEnumerable<QuestionModel>> GetQuestionsByTestIdAsync(Guid testId);
    
    // todo: add CRUD functions
    
    public Task AddQuestionAsync(QuestionModel question);
    public Task UpdateQuestionAsync(QuestionModel question, Guid id);
    public Task DeleteQuestionAsync(Guid id);
    public IQueryable GetAllQuestions();
    public Task<QuestionModel> GetQuestionById(Guid id);
}