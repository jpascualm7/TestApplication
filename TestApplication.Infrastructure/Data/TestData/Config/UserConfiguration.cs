using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApplication.Domain.Entities;

namespace TestApplication.Infrastructure.Data.TestApplication.Config;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("User");
        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Email)
           .IsRequired()
            .HasMaxLength(500);

        builder.HasIndex(ci => ci.Email )
            .HasDatabaseName("IX_User_Email")
            .IsUnique(true)
            .IsClustered(false);

        builder.Property(ci => ci.CreatedDateTimeUtc)
            .IsRequired();

        builder.Property(ci => ci.CreatedBy)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ci => ci.UpdatedDateTimeUtc)
            .IsRequired();

        builder.Property(ci => ci.UpdatedBy)
            .IsRequired()
            .HasMaxLength(100);

    }
}
