using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using TestApplication.Application.Common.Exceptions;
using TestApplication.Application.Common.Interfaces;
using TestApplication.Domain.Entities;

namespace TestApplication.Application.Repositories.Institution;

public class InstitutionRepository : IInstitutionRepository
{
    private readonly ITestDataDbContext _context;
    public InstitutionRepository(ITestDataDbContext context)
    {
        _context = context;
    }

    public async Task<InstitutionEntity?> GetByIdAsync(int id)
    {
        return await _context.Institutions.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<InstitutionEntity?> GetByInstitutionIdAsync(string institutionId)
    {
        return await _context.Institutions.FirstOrDefaultAsync(a => a.InstitutionId == institutionId);
    }

    public async Task<InstitutionEntity> AddAsync(string institutionId, string name, bool oauth, string? url, string? primaryColor, byte[]? logo, string createdBy)
    {
        Guard.Against.NullOrEmpty(institutionId, nameof(institutionId));
        Guard.Against.NullOrEmpty(name, nameof(name));
        Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));

        var institution = await GetByInstitutionIdAsync(institutionId);

        if (institution == null)
        {
            institution = new InstitutionEntity
            {
                InstitutionId = institutionId,
                Name = name,
                Oauth = oauth,
                Url = url,
                PrimaryColor = primaryColor,
                Logo = logo,
                CreatedBy = createdBy,
                CreatedDateTimeUtc = DateTime.UtcNow,
                UpdatedBy = createdBy,
                UpdatedDateTimeUtc = DateTime.UtcNow,
            };

            _context.Institutions.Add(institution);
        }
        else
        {
            institution = await UpdateAsync(institution.Id, name, oauth, url, primaryColor, logo, createdBy);
        }

        await _context.SaveChangesAsync(new CancellationToken());
        return institution;
    }

    public async Task<InstitutionEntity> UpdateAsync(int id, string name, bool oauth, string? url, string? primaryColor, byte[]? logo, string createdBy)
    {
        Guard.Against.Default(id, nameof(id));
        Guard.Against.NullOrEmpty(name, nameof(name));
        Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));

        var institution = await GetByIdAsync(id);

        if (institution == null)
        {
            throw new NotFoundDetailsException("Institution not found");
        }

        institution.Name = name;
        institution.Oauth = oauth;
        institution.Url = url;
        institution.PrimaryColor = primaryColor;
        institution.Logo = logo;
        institution.UpdatedBy = createdBy;
        institution.UpdatedDateTimeUtc = DateTime.UtcNow;

        await _context.SaveChangesAsync(new CancellationToken());
        return institution;
    }
}
