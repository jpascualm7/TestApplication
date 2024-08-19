using TestApplication.Domain.Entities;

namespace TestApplication.Application.Repositories.Institution;

public interface IInstitutionRepository
{
    Task<InstitutionEntity> AddAsync(string institutionId, string name, bool oauth, string? url, string? primaryColor, byte[]? logo, string createdBy);
    Task<InstitutionEntity?> GetByIdAsync(int id);
    Task<InstitutionEntity?> GetByInstitutionIdAsync(string institutionId);
    Task<InstitutionEntity> UpdateAsync(int id, string name, bool oauth, string? url, string? primaryColor, byte[]? logo, string createdBy);
}
