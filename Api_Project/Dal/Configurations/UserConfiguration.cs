using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Surname).IsRequired().HasMaxLength(30);
        builder.Property(x => x.Password).IsRequired().HasMaxLength(20);

        builder
            .HasMany(x => x.Tests)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.CreatedForUserId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}