using AutoMapper;
using Bll.Models;
using Bll.Services.Interfaces;
using Dal.Entities;
using Dal.Repositories.Interfaces;

namespace Bll.Services;

public class QuestionService : IQuestionService
{
    private readonly IMapper _mapper;
    private readonly IQuestionRepository _questionRepository;

    public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
    {
        _mapper = mapper;
        _questionRepository = questionRepository;
    }

    public async Task<IEnumerable<QuestionModel>> GetQuestionsByTestIdAsync(Guid testId)
    {
        var entities = await _questionRepository.GetAllByTestIdAsync(testId);
        return _mapper.Map<IEnumerable<QuestionModel>>(entities);
    }

    public async Task AddQuestionAsync(QuestionModel question)
    {
        var entity = _mapper.Map<Question>(question);
        await _questionRepository.AddAsync(entity);
    }

    public async Task UpdateQuestionAsync(QuestionModel question, Guid id)
    {
        var entity = _mapper.Map<Question>(question);
        entity.Id = id;
        await _questionRepository.UpdateAsync(entity);
    }

    public async Task DeleteQuestionAsync(Guid id)
    {
        await _questionRepository.DeleteAsync(id);
    }

    public IQueryable GetAllQuestions()
    {
        var entities = _questionRepository.GetAllAsync();
        return _mapper.Map<IQueryable<QuestionModel>>(entities);
    }

    public async Task<QuestionModel> GetQuestionById(Guid id)
    {
        var entity = await _questionRepository.GetByIdAsync(id);
        return _mapper.Map<QuestionModel>(entity);
    }
}