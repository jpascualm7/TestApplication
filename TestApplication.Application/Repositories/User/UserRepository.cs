using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using TestApplication.Application.Common.Exceptions;
using TestApplication.Application.Common.Interfaces;
using TestApplication.Domain.Entities;

namespace TestApplication.Application.Repositories.User;

public class UserRepository : IUserRepository
{
    private readonly ITestDataDbContext _context;
    public UserRepository(ITestDataDbContext context)
    {
        _context = context;
    }

    public async Task<UserEntity?> GetUserAsync(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<UserEntity?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(a => a.Email == email);
    }

    public async Task<UserEntity> AddUserAsync(string email, string createdBy)
    {
        Guard.Against.NullOrEmpty(email, nameof(email));
        Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));

        var user = await GetUserByEmailAsync(email);

        if (user == null)
        {
            user = new UserEntity
            {
                Email = email,
                CreatedBy = createdBy,
                CreatedDateTimeUtc = DateTime.UtcNow,
                UpdatedBy = createdBy,
                UpdatedDateTimeUtc = DateTime.UtcNow,
            };

            _context.Users.Add(user);
        }
        else
        {
            user = await UpdateAsync(user.Id, createdBy);
        }

        await _context.SaveChangesAsync(new CancellationToken());
        return user;
    }

    public async Task<UserEntity> UpdateAsync(int id, string updatedBy)
    {
        Guard.Against.NullOrEmpty(updatedBy, nameof(updatedBy));

        var user = await GetUserAsync(id);
        if (user == null)
        {
            throw new NotFoundDetailsException("User not found");
        }

        user.UpdatedBy = updatedBy;
        user.UpdatedDateTimeUtc = DateTime.UtcNow;

        await _context.SaveChangesAsync(new CancellationToken());
        return user;
    }
}
