using BlazorPaging.Shared;

namespace BlazorPaging.Api.Extensions;

public static class CompanyQueryExtensions
{
    public static IQueryable<PagedCompany> OrderCompanysBy(this IQueryable<PagedCompany> query, string orderBy, string orderDirection)
    {
        return orderBy.ToLower() switch
        {
            "id" => orderDirection.Equals("asc", StringComparison.CurrentCultureIgnoreCase)
                ? query.OrderBy(q => q.Id)
                : query.OrderByDescending(q => q.Id),

            "name" => orderDirection.Equals("asc", StringComparison.CurrentCultureIgnoreCase)
                ? query.OrderBy(q => q.Name)
                : query.OrderByDescending(q => q.Name),

            "reference" => orderDirection.Equals("asc", StringComparison.CurrentCultureIgnoreCase)
                ? query.OrderBy(q => q.Reference)
                : query.OrderByDescending(q => q.Reference),

            "suffix" => orderDirection.Equals("asc", StringComparison.CurrentCultureIgnoreCase)
                ? query.OrderBy(q => q.Suffix)
                : query.OrderByDescending(q => q.Suffix),

            _ => throw new ArgumentException("CompanyQueryExtensions.OrderTasksBy orderby not found."),
        };
    }

}
