using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApplication.Domain.Entities;

namespace TestApplication.Infrastructure.Data.TestApplication.Config;

public class ApiRequestLogConfiguration : IEntityTypeConfiguration<ApiRequestLogEntity>
{
    public void Configure(EntityTypeBuilder<ApiRequestLogEntity> builder)
    {
        builder.ToTable("ApiRequestLog");
        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.RequestDateTimeUtc).IsRequired();

        builder.Property(ci => ci.RequestMethod)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(ci => ci.RequestMethod)
            .HasDatabaseName("IX_ApiRequestLog_RequestMethod")
            .IsUnique(false)
            .IsClustered(false);

        builder.Property(ci => ci.RequestPath)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ci => ci.RequestQuery)
            .HasMaxLength(1000);

        builder.Property(ci => ci.RequestScheme)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(ci => ci.RequestHost)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasIndex(ci => ci.RequestHost)
            .HasDatabaseName("IX_ApiRequestLog_RequestHost")
            .IsUnique(false)
            .IsClustered(false);

        builder.Property(ci => ci.RequestContentType)
            .HasMaxLength(500);

        builder.Property(ci => ci.ResponseContentType)
            .HasMaxLength(500);

        builder.Property(ci => ci.ResponseStatus)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(ci => ci.ResponseStatus)
            .HasDatabaseName("IX_ApiRequestLog_ResponseStatus")
            .IsUnique(false)
            .IsClustered(false);

        builder.Property(ci => ci.ResponseDateTimeUtc)
            .IsRequired();

        builder.HasIndex(ci => ci.ResponseDateTimeUtc)
            .HasDatabaseName("IX_ApiRequestLog_ResponseDateTimeUtc")
            .IsUnique(false)
            .IsClustered(false);

    }
}
