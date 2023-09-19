using AutoMapper;
using Bll.Models;
using Bll.Models.AddModels;
using Bll.Models.UpdateModels;
using Bll.Services.Interfaces;
using Dal.Entities;
using Dal.Repositories.Interfaces;

namespace Bll.Services;

public class TestService : ITestService
{
    private readonly ITestRepository _testRepository;
    private readonly IMapper _mapper;

    public TestService(ITestRepository testRepository, IMapper mapper)
    {
        _testRepository = testRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TestModel>> GetTestsByUserIdAsync(Guid userId)
    {
        var entities = await _testRepository.GetTestsByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<TestModel>>(entities);
    }

    public async Task<TestModel> GetTestWithQuestionsAsync(Guid id)
    {
        var entity = await _testRepository.GetByIdWithQuestionsAsync(id);
        return _mapper.Map<TestModel>(entity);
    }

    public async Task<string> GetTestDescriptionAsync(Guid id)
    {
        return await _testRepository.GetDescriptionAsync(id);
    }

    public async Task DeleteTestAsync(Guid id)
    {
        await _testRepository.DeleteAsync(id);
    }

    public async Task AddTestAsync(AddTestModel model)
    {
        var entity = _mapper.Map<Test>(model);
        await _testRepository.AddAsync(entity);
    }

    public async Task UpdateTestAsync(UpdateTestModel model)
    {
        var oldId = Guid.Parse(model.Id);
        var testOld = await _testRepository.GetByIdAsync(oldId);
        _mapper.Map(model, testOld);
        await _testRepository.UpdateAsync(testOld);
    }
}