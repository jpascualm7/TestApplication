using TestApplication.Domain.Entities;

namespace TestApplication.Application.Repositories.Account;

public interface IAccountRepository
{
    Task<AccountEntity> AddAccountAsync(int userId, string publicToken, string accessToken, string createdBy);
}
