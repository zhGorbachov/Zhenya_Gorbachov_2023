using AutoMapper;
using Bll.Models;
using Bll.Services.Interfaces;
using Dal.Entities;
using Dal.Repositories.Interfaces;

namespace Bll.Services;

public class AnswerService : IAnswerService
{
    private readonly IMapper _mapper;
    private readonly IAnswerRepository _answerRepository;

    public AnswerService(IAnswerRepository answerRepository, IMapper mapper)
    {
        _mapper = mapper;
        _answerRepository = answerRepository;
    }

    public async Task AddAnswerAsync(AnswerModel answer)
    {
        var entity = _mapper.Map<Answer>(answer);
        await _answerRepository.AddAsync(entity);
    }

    public async Task UpdateAnswerAsync(AnswerModel answer, Guid id)
    {
        var entity = _mapper.Map<Answer>(answer);
        entity.Id = id;
        await _answerRepository.UpdateAsync(entity);
    }

    public async Task DeleteAnswerAsync(Guid id)
    {
        await _answerRepository.DeleteAsync(id);
    }

    public IQueryable GetAllAnswers()
    {
        var entities = _answerRepository.GetAllAsync();
        return _mapper.Map<IQueryable<AnswerModel>>(entities);
    }

    public async Task<AnswerModel> GetAnswerById(Guid id)
    {
        var entity = await _answerRepository.GetByIdAsync(id);
        return _mapper.Map<AnswerModel>(entity);
    }
    
    public async Task<IEnumerable<AnswerModel>> GetAnswersByQuestionIdAsync(Guid questionId)
    {
        var answers = await _answerRepository.GetAllByQuestionIdAsync(questionId);

        return _mapper.Map<IEnumerable<AnswerModel>>(answers);
    }

    public async Task<bool> CheckAnswerByIdAsync(Guid id)
    {
        return await _answerRepository.CheckIsCorrectAsync(id);
    }
}