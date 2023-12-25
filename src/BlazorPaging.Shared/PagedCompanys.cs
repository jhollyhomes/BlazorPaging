namespace BlazorPaging.Shared;
public class PagedCompanys(List<PagedCompany> companys, int recordCount)
{
    public List<PagedCompany> Companys { get; init; } = companys;

    public int RecordCount { get; init; } = recordCount;
}