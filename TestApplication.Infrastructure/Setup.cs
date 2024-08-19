using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestApplication.Application.Common.Interfaces;
using TestApplication.Domain.Configuration;
using TestApplication.Infrastructure.Data.TestData;

namespace TestApplication.Infrastructure;

public static class Setup
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		string dbConnectionString = configuration.GetValue<string>("ProjectConfiguration:MintWeaveConnectionString");

		//Getting all providers configuration setting
		services.Configure<PlaidApiConfiguration>(configuration.GetSection("PlaidApiConfiguration"));

		//Setting MintWeave DB Connection and Context
		services.AddDbContext<TestDataDbContext>(options => options.UseSqlServer(dbConnectionString).UseLazyLoadingProxies());

		services.AddScoped<ITestDataDbContext>(provider => provider.GetRequiredService<TestDataDbContext>());


		//Services
		

		return services;
	}
}
