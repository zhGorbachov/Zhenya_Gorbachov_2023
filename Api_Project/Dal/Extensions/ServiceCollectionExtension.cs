using Dal.Repositories;
using Dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dal.Extensions;

public static class ServiceCollectionExtension
{
    public static void InjectDatabaseServices(this IServiceCollection services)
    {
        services.AddDatabase();
    }

    private static void AddDatabase(this IServiceCollection services)
    {
    }

    public static void AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<ITestRepository, TestRepository>();
        serviceCollection.AddScoped<IAnswerRepository, AnswerRepository>();
        serviceCollection.AddScoped<IQuestionRepository, QuestionRepository>();
    }
}