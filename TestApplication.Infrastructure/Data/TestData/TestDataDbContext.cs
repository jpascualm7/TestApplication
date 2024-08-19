using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Application.Common.Interfaces;
using TestApplication.Domain.Entities;

namespace TestApplication.Infrastructure.Data.TestData;

public class TestDataDbContext : DbContext, ITestDataDbContext
{
    public TestDataDbContext(DbContextOptions<TestDataDbContext> options)
		: base(options)
{
}
public DbSet<UserEntity> Users => Set<UserEntity>();

public DbSet<AccountEntity> Accounts => Set<AccountEntity>();

public DbSet<ApiRequestLogEntity> ApiRequestLogs => Set<ApiRequestLogEntity>();

public DbSet<InstitutionEntity> Institutions => Set<InstitutionEntity>();

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
	base.OnModelCreating(modelBuilder);
	modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
{
	int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

	return result;
}
public override int SaveChanges()
{
	return SaveChangesAsync().GetAwaiter().GetResult();
}

}
