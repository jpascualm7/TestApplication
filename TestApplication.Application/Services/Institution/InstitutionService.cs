using TestApplication.Application.Repositories.Institution;

namespace TestApplication.Application.Services.Institution;

public class InstitutionService: IInstitutionService
{
    private readonly IInstitutionRepository _institutionRepository;
    public InstitutionService(IInstitutionRepository institutionRepository)
    {
        _institutionRepository = institutionRepository;
    }

}
