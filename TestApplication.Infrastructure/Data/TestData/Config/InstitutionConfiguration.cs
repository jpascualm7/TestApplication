using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TestApplication.Domain.Entities;

namespace TestApplication.Infrastructure.Data.TestApplication.Config;

public class InstitutionConfiguration : IEntityTypeConfiguration<InstitutionEntity>
{
    public void Configure(EntityTypeBuilder<InstitutionEntity> builder)
    {
        builder.ToTable("Institution");

        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.InstitutionId)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(ci => ci.InstitutionId)
            .HasDatabaseName("IX_Institution_InstitutionId")
            .IsUnique(false)
            .IsClustered(false);

        builder.Property(ci => ci.Name)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(ci => ci.PrimaryColor)
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
