using Bll.Models;

namespace Bll.Services.Interfaces;

public interface IAnswerService
{
    public Task<IEnumerable<AnswerModel>> GetAnswersByQuestionIdAsync(Guid questionId);
    public Task<bool> CheckAnswerByIdAsync(Guid id);
    
    // todo: Add CRUD functions
    
    public Task AddAnswerAsync(AnswerModel answer);
    public Task UpdateAnswerAsync(AnswerModel answer, Guid id);
    public Task DeleteAnswerAsync(Guid id);
    public IQueryable GetAllAnswers();
    public Task<AnswerModel> GetAnswerById(Guid id);
}