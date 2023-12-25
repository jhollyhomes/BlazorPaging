using BlazorPaging.Shared;

namespace BlazorPaging.Api.Services;

public interface ICompanyService
{
    List<PagedCompany> Companys { get; }
}
