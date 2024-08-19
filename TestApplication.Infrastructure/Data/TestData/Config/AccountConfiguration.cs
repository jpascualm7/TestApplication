using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TestApplication.Domain.Entities;

namespace TestApplication.Infrastructure.Data.TestApplication.Config;

public class AccountConfiguration : IEntityTypeConfiguration<AccountEntity>
{
    public void Configure(EntityTypeBuilder<AccountEntity> builder)
    {
        builder.ToTable("Account");
        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.UserId)
            .IsRequired();

        builder.HasOne(sc => sc.User)
           .WithMany(s => s.Accounts)
           .HasForeignKey(sc => sc.UserId)
           .IsRequired(true);

        builder.HasIndex(ci => ci.UserId)
            .HasDatabaseName("IX_Account_User")
            .IsUnique(false)
            .IsClustered(false);

        builder.Property(ci => ci.PublicToken)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(ci => ci.AccessToken)
            .IsRequired()
            .HasMaxLength(1000);

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
