using Bll.Models;
using Bll.Models.AddModels;
using Bll.Models.UpdateModels;

namespace Bll.Services.Interfaces;

public interface ITestService
{
    public Task<IEnumerable<TestModel>> GetTestsByUserIdAsync(Guid userId);
    public Task<TestModel> GetTestWithQuestionsAsync(Guid id);
    public Task<string> GetTestDescriptionAsync(Guid id);

    public Task DeleteTestAsync(Guid id);
    public Task AddTestAsync(AddTestModel model);
    public Task UpdateTestAsync(UpdateTestModel model);
}