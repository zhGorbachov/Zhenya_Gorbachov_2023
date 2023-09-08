using Dal;
using Dal.Entities;
using Dal.Repositories;
using Tests;
using Tests.Data;

namespace Tests.DataTests;

public class QuestionRepositoryTests
{
    [TestCase("1969fe97-30b0-4f96-998a-bdc70d88d2cc")]
    [TestCase("a5d6c657-688b-4c0e-a96a-9a66cab342af")]
    public async Task QuestionRepository_GetByIdAsync_ReturnsValue(string id)
    {
        // arrange
        
        using var context = new AppDbContext(UnitTestHelper.GetUnitTestsDbOptions());
        var questionRepository = new QuestionRepository(context);

        var expected = RepositoryData.ExpectedQuestions.FirstOrDefault(x => x.Id.ToString() == id);

        // act

        var result = await questionRepository.GetByIdAsync(Guid.Parse(id));

        // assert
        
        Assert.IsNotNull(result, message: "Expected not null");
        Assert.That(result, Is.EqualTo(expected).Using(new QuestionEqualityComparer()), message: "Result is invalid");
    }

    [Test]
    public async Task QuestionRepository_GetAllAsync_ReturnsAllValues()
    {
        using var context = new AppDbContext(UnitTestHelper.GetUnitTestsDbOptions());
        var questionRepository = new QuestionRepository(context);

        var result = await questionRepository.GetAllAsync();
        
        Assert.That(result, Is.EqualTo(RepositoryData.ExpectedQuestions).Using(new QuestionEqualityComparer()), 
            message: "Results are not equal to expected");
    }

    [Test]
    public async Task QuestionRepository_AddAsync_AddsValueToDatabase()
    {
        using var context = new AppDbContext(UnitTestHelper.GetUnitTestsDbOptions());
        var questionRepository = new QuestionRepository(context);

        var newQuestion = new Question { Text = "New question" };

        await questionRepository.AddAsync(newQuestion);
        await context.SaveChangesAsync();
        
        Assert.That(context.Questions.Count(), !Is.EqualTo(RepositoryData.ExpectedQuestions.Count()), message: "AddAsync works");
    }
    
    [Test]
    public async Task QuestionRepository_UpdateAsync_ValueUpdated()
    {
        using var context = new AppDbContext(UnitTestHelper.GetUnitTestsDbOptions());
        var questionRepository = new QuestionRepository(context);

        var questionId = Guid.Parse("a5d6c657-688b-4c0e-a96a-9a66cab342af");
        var notExpected = RepositoryData.ExpectedQuestions.FirstOrDefault(x => x.Id == questionId);
        var question = new Question
        {
            Id = questionId,
            Text = "Update test"
        };

        await questionRepository.UpdateAsync(question);
        await context.SaveChangesAsync();
        
        Assert.That(question, !Is.EqualTo(notExpected), message: "UpdateAsync works");
    }

    [TestCase("a5d6c657-688b-4c0e-a96a-9a66cab342af")]
    [TestCase("ed20c0a6-dbc7-4f2f-9b4d-e57616f40c78")]
    public async Task QuestionRepository_DeleteAsync_ObjectIsDeleted(string id)
    {
        using var context = new AppDbContext(UnitTestHelper.GetUnitTestsDbOptions());

        var questionRepository = new QuestionRepository(context);

        await questionRepository.DeleteAsync(Guid.Parse(id));
        await context.SaveChangesAsync();

        Assert.That(context.Questions.Count(), !Is.EqualTo(RepositoryData.ExpectedQuestions.Count()), message: "DeleteByIdAsync works incorrect");
    }
}