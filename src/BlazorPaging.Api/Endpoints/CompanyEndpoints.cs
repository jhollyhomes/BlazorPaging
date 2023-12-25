using BlazorPaging.Api.Extensions;
using BlazorPaging.Api.Services;
using BlazorPaging.Shared;

namespace BlazorPaging.Api.Endpoints;

public static class CompanyEndpoints
{
    public static void RegisterCompanyEndpoints(this IEndpointRouteBuilder builder)
    {
        var mapGroup = builder.MapGroup("/api/company");
        mapGroup.MapGet("/", GetCompanys);
    }

    static PagedCompanys GetCompanys(ICompanyService companyService, int pn, int ps, string sf, string so)
    {
        var query = companyService.Companys.AsQueryable();
        query = query.OrderCompanysBy(sf, so);

        var skip = (pn - 1) * ps;
        if (skip < 0) skip = 0;

        var result = query.Skip(skip)
                         .Take(ps)
                         .ToList();

        return new PagedCompanys(result, companyService.Companys.Count);
    }
}