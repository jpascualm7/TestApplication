using Microsoft.EntityFrameworkCore;
using TestApplication.Domain.Entities;

namespace TestApplication.Application.Common.Interfaces;

public interface ITestDataDbContext
{
    DbSet<UserEntity> Users { get; }
    DbSet<AccountEntity> Accounts { get; }
    DbSet<ApiRequestLogEntity> ApiRequestLogs { get; }
    DbSet<InstitutionEntity> Institutions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    int SaveChanges();
}
