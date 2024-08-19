using TestApplication.Domain.Entities;

namespace TestApplication.Application.Repositories.User;

public interface IUserRepository
{
    Task<UserEntity> AddUserAsync(string email, string createdBy);
    Task<UserEntity?> GetUserAsync(int id);
    Task<UserEntity?> GetUserByEmailAsync(string email);
    Task<UserEntity> UpdateAsync(int id, string updatedBy);
}
