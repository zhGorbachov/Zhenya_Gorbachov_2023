using Dal.Configurations;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal;

public class AppDbContext : DbContext
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Test> Tests { get; set; }
    public virtual DbSet<Question> Questions { get; set; }
    public virtual DbSet<Answer> Answers { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new TestConfiguration());
        builder.ApplyConfiguration(new QuestionConfiguration());
        builder.ApplyConfiguration(new AnswerConfiguration());
        
        base.OnModelCreating(builder);
    }
}