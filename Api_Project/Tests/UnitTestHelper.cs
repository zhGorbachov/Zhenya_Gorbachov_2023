using Dal;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Tests;

internal static class UnitTestHelper
{
    public static DbContextOptions<AppDbContext> GetUnitTestsDbOptions()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        using (var context = new AppDbContext(options))
        {
            SeedData(context);
        }
        
        return options;
    }

    public static void SeedData(AppDbContext context)
    {
        var users = new List<User>
        {
            new User { Id = Guid.Parse("585dbcf1-2a39-4e24-8b66-2339ab6bdbab"), Name = "Name1", Surname = "Surname1", Password = "Password" },
            new User { Id = Guid.Parse("96865278-eff1-4be5-88a2-6d1272e2feeb"), Name = "Name2", Surname = "Surname2", Password = "drowssaP" }
        };

        var tests = new List<Test>
        {
            new Test { Id = Guid.Parse("f626f7b9-b1c0-4c0c-90c6-4246aced0c22"), Title = "Test1", Description = "This test is definitely not copied", CreatedForUserId = Guid.Parse("585dbcf1-2a39-4e24-8b66-2339ab6bdbab")},
            new Test { Id = Guid.Parse("c9e3368b-601a-4f9a-b4f2-e2e207de3b54"), Title = "Test2", Description = "This test is definitely not copied", CreatedForUserId = Guid.Parse("585dbcf1-2a39-4e24-8b66-2339ab6bdbab")},
            new Test { Id = Guid.Parse("3e7a93a7-d78b-4cb7-b939-c807ae3ac901"), Title = "Test2", Description = "This test is definitely not copied", CreatedForUserId = Guid.Parse("96865278-eff1-4be5-88a2-6d1272e2feeb")},
        };

        var questions = new List<Question>
        {
            new Question { Id = Guid.Parse("aa6cc972-2650-44c3-8a8e-134e4e7cf8df"), TestId = Guid.Parse("f626f7b9-b1c0-4c0c-90c6-4246aced0c22"), Text = "Is this task designed well?"},
            new Question { Id = Guid.Parse("1969fe97-30b0-4f96-998a-bdc70d88d2cc"), TestId = Guid.Parse("f626f7b9-b1c0-4c0c-90c6-4246aced0c22"), Text = "Are you sure, that it is designed well?"},
            new Question { Id = Guid.Parse("3df44dcb-a108-472a-ae6c-78f1e8865301"), TestId = Guid.Parse("f626f7b9-b1c0-4c0c-90c6-4246aced0c22"), Text = "100% sure?"},
            new Question { Id = Guid.Parse("a5d6c657-688b-4c0e-a96a-9a66cab342af"), TestId = Guid.Parse("c9e3368b-601a-4f9a-b4f2-e2e207de3b54"), Text = "Is it necessary to use many-many rel in this task?"},
            new Question { Id = Guid.Parse("ed20c0a6-dbc7-4f2f-9b4d-e57616f40c78"), TestId = Guid.Parse("c9e3368b-601a-4f9a-b4f2-e2e207de3b54"), Text = "Why mentors decided not to use it?"},
            new Question { Id = Guid.Parse("3dee1c1c-2fb0-456a-8444-9a0dbe3ff362"), TestId = Guid.Parse("3e7a93a7-d78b-4cb7-b939-c807ae3ac901"), Text = "Did you like the questions?"},
        };

        var answers = new List<Answer>
        {
            new Answer { Id = Guid.Parse("d8d06d13-6a7e-417c-bbdb-76f9c6a1cfab"), QuestionId = Guid.Parse("aa6cc972-2650-44c3-8a8e-134e4e7cf8df"), Text = "No", IsCorrect = true },
            new Answer { Id = Guid.Parse("6225b805-399f-47eb-8b37-b4ed4c286914"), QuestionId = Guid.Parse("aa6cc972-2650-44c3-8a8e-134e4e7cf8df"), Text = "Sure", IsCorrect = false },
            new Answer { Id = Guid.Parse("c483c714-4953-4448-aa9d-b0f3170ee476"), QuestionId = Guid.Parse("aa6cc972-2650-44c3-8a8e-134e4e7cf8df"), Text = "Definitely not", IsCorrect = true },
            new Answer { Id = Guid.Parse("b1a30461-2173-416b-8281-a227c5cff8f7"), QuestionId = Guid.Parse("1969fe97-30b0-4f96-998a-bdc70d88d2cc"), Text = "Yes", IsCorrect = false },
            new Answer { Id = Guid.Parse("7bbfbd33-d0ce-4834-b8a6-7f96a7d9e9be"), QuestionId = Guid.Parse("1969fe97-30b0-4f96-998a-bdc70d88d2cc"), Text = "No", IsCorrect = true },
            new Answer { Id = Guid.Parse("e96e4440-7155-4af0-93ed-859f0c1cc61a"), QuestionId = Guid.Parse("3df44dcb-a108-472a-ae6c-78f1e8865301"), Text = "Yes", IsCorrect = false },
            new Answer { Id = Guid.Parse("107c6172-36d8-400f-a90b-5c5bfb502935"), QuestionId = Guid.Parse("3df44dcb-a108-472a-ae6c-78f1e8865301"), Text = "No", IsCorrect = true },
            new Answer { Id = Guid.Parse("7a5af56c-58c9-4f57-a761-9705765be869"), QuestionId = Guid.Parse("a5d6c657-688b-4c0e-a96a-9a66cab342af"), Text = "No", IsCorrect = false },
            new Answer { Id = Guid.Parse("3c59d1c5-a5c7-44e9-b755-9bc3418b5a32"), QuestionId = Guid.Parse("a5d6c657-688b-4c0e-a96a-9a66cab342af"), Text = "Yes", IsCorrect = true },
            new Answer { Id = Guid.Parse("82d0e7a4-bec2-4b38-aedc-798ebe70697c"), QuestionId = Guid.Parse("ed20c0a6-dbc7-4f2f-9b4d-e57616f40c78"), Text = "They were bored", IsCorrect = false },
            new Answer { Id = Guid.Parse("9b764919-a531-4793-bba6-78c7c9dead63"), QuestionId = Guid.Parse("ed20c0a6-dbc7-4f2f-9b4d-e57616f40c78"), Text = "They are always right, really(", IsCorrect = true },
            new Answer { Id = Guid.Parse("db3b8086-fbb2-41b9-baf0-456ef3817ebe"), QuestionId = Guid.Parse("ed20c0a6-dbc7-4f2f-9b4d-e57616f40c78"), Text = "They wanted to play LOL", IsCorrect = false },
            new Answer { Id = Guid.Parse("5d225d12-55e3-4cce-a8ec-69956b856e60"), QuestionId = Guid.Parse("3dee1c1c-2fb0-456a-8444-9a0dbe3ff362"), Text = "Yes", IsCorrect = true },
            new Answer { Id = Guid.Parse("53da8b5c-3262-468a-aa48-96dc585a9b03"), QuestionId = Guid.Parse("3dee1c1c-2fb0-456a-8444-9a0dbe3ff362"), Text = "Where questions?", IsCorrect = true }
        };
        
        context.Users.AddRange(users);
        context.Tests.AddRange(tests);
        context.Questions.AddRange(questions);
        context.Answers.AddRange(answers);
        
        context.SaveChanges();
    }
}