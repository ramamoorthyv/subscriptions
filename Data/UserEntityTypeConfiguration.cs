using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Subscription.Data;
using Subscription.Models;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Email)
               .IsRequired();

        // UNIQUE constraint
        builder.HasIndex(x => x.Email)
               .IsUnique();
    }
}