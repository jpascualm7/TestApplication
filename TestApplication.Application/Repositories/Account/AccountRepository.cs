using Ardalis.GuardClauses;
using TestApplication.Application.Common.Exceptions;
using TestApplication.Application.Common.Interfaces;
using TestApplication.Application.Repositories.User;
using TestApplication.Domain.Entities;

namespace TestApplication.Application.Repositories.Account;

public class AccountRepository : IAccountRepository
{
    private readonly ITestDataDbContext _context;
    private readonly IUserRepository _userRepository;
    
    public AccountRepository(ITestDataDbContext context, IUserRepository userRepository)
    {
        _context = context;
        _userRepository = userRepository;
    }    

    public async Task<AccountEntity> AddAccountAsync(int userId, string publicToken, string accessToken, string createdBy)
    {
        Guard.Against.Default(userId, nameof(userId));
        Guard.Against.NullOrEmpty(publicToken, nameof(publicToken));
        Guard.Against.NullOrEmpty(accessToken, nameof(accessToken));
        Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));

        var user = await _userRepository.GetUserAsync(userId);
        if (user == null)
        {
            throw new NotFoundDetailsException("User not found");
        }

        var account = new AccountEntity
        {
            UserId = userId,
            PublicToken = publicToken,
            AccessToken = accessToken,
            CreatedBy = createdBy,
            CreatedDateTimeUtc = DateTime.UtcNow,
            UpdatedBy = createdBy,
            UpdatedDateTimeUtc = DateTime.UtcNow,
        };

        _context.Accounts.Add(account);
        await _context.SaveChangesAsync(new CancellationToken());
        return account;
    }
}
