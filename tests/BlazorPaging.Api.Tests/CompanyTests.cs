using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net;
using BlazorPaging.Api.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using BlazorPaging.Api.Endpoints;
using BlazorPaging.Shared;
using Shouldly;

namespace BlazorPaging.Api.Tests;

public class CompanyTests
{
    [Fact]
    public async Task GivenValidRequest_WhenEndpointCalled_OkReturned()
    {
        using var host = await new HostBuilder()
            .ConfigureWebHost(webBuilder =>
            {
                webBuilder
                    .UseTestServer()
                    .ConfigureServices(services =>
                    {
                        services.AddRouting();
                        services.AddSingleton<ICompanyService, CompanyService>();
                    })
                    .Configure(app =>
                    {
                        app.UseRouting();
                        app.UseEndpoints(e =>
                        {
                            e.RegisterCompanyEndpoints();
                        });
                    });
            })
            .StartAsync();

        var client = host.GetTestClient();
        var response = await client.GetAsync("/api/company/?pn=1&ps=10&sf=name&so=asc");

        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GivenValidRequest_WhenPageSizeIs20_20RecordsReturned()
    {
        using var host = await new HostBuilder()
            .ConfigureWebHost(webBuilder =>
            {
                webBuilder
                    .UseTestServer()
                    .ConfigureServices(services =>
                    {
                        services.AddRouting();
                        services.AddSingleton<ICompanyService, CompanyService>();
                    })
                    .Configure(app =>
                    {
                        app.UseRouting();
                        app.UseEndpoints(e =>
                        {
                            e.RegisterCompanyEndpoints();
                        });
                    });
            })
            .StartAsync();

        var client = host.GetTestClient();
        var response = await client.GetAsync("/api/company/?pn=1&ps=20&sf=name&so=asc");
        var content = await response.Content.ReadAsStringAsync();
        var pagedCompanys = JsonConvert.DeserializeObject<PagedCompanys>(content);

        pagedCompanys.Companys.Count.ShouldBe(20);
    }
}