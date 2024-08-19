using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TestApplication.Application.Repositories.Account;
using TestApplication.Application.Repositories.ApiRequestLog;
using TestApplication.Application.Repositories.Institution;
using TestApplication.Application.Repositories.User;
using TestApplication.Application.Services.Institution;

namespace TestApplication.Application;

public static class Setup
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddAutoMapper(Assembly.GetExecutingAssembly());

		//Adding Services
		services.AddTransient<IInstitutionService, InstitutionService>();

		//Adding Repositories
		services.AddTransient<IAccountRepository, AccountRepository>();
		services.AddTransient<IUserRepository, UserRepository>();
		services.AddTransient<IApiRequestLogRepository, ApiRequestLogRepository>();
		services.AddTransient<IInstitutionRepository, InstitutionRepository>();

		return services;
	}
}
