using TestApplication.Application.Providers.Plaid;
using TestApplication.Application.Repositories.Institution;

namespace TestApplication.Application.Services.Institution;

public class InstitutionService: IInstitutionService
{
    private readonly IInstitutionRepository _institutionRepository;
    private readonly IPlaidIntitutionService _plaidIntitutionService;
    public InstitutionService(IInstitutionRepository institutionRepository,IPlaidIntitutionService plaidIntitutionService)
    {
        _institutionRepository = institutionRepository;
        _plaidIntitutionService = plaidIntitutionService;
    }

    public async Task<int> ImportAllInstitutionsAsync(string importedBy)
    {
        int importedRecords =0;
        int count = 500;
        int offset = 0;

        var data = await _plaidIntitutionService.GetInstitutionsInUsAsyn(count, offset);

        while ((offset + 1) * count < data.Total)
        {
            if (offset > 0)
            {
                data = await _plaidIntitutionService.GetInstitutionsInUsAsyn(count, offset);
            }

            foreach (var institution in data.Institutions)
            {
                await _institutionRepository.AddAsync(institution.InstitutionId ?? "", institution.Name ?? "", institution.Oauth, institution.Url, institution.PrimaryColor, institution.Logo, importedBy);
                importedRecords++;
            }

            offset++;
        }
        

        return importedRecords;
    }
}
