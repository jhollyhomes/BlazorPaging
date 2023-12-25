using BlazorPaging.Shared;
using Bogus;

namespace BlazorPaging.Api.Services;

public class CompanyService : ICompanyService
{
    private List<PagedCompany>? _companys;

    public List<PagedCompany> Companys
    {
        get
        {
            if (_companys == null)
            {
                var generator = GetCompanyGenerator();
                _companys = generator.Generate(1342);
            }

            return _companys;
        }
    }

    private Faker<PagedCompany> GetCompanyGenerator()
    {
        return new Faker<PagedCompany>()
            .StrictMode(true)
            .RuleFor(c => c.Id, f => f.IndexFaker)
            .RuleFor(c => c.Suffix, f => f.Company.CompanySuffix())
            .RuleFor(c => c.Name, f => f.Company.CompanyName())
            .RuleFor(c => c.Reference, f => f.Company.Random.String2(10).ToUpper());
    }
}
