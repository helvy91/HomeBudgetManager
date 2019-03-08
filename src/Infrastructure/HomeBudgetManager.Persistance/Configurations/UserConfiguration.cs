using HomeBudgetManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeBudgetManager.Persistance.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Login).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(18);
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.Salt).IsRequired();

            builder.HasIndex("Login").IsUnique();
            builder.HasIndex("Email").IsUnique();
        }
    }
}
