using BlazorPaging.Web;
using BlazorPaging.Web.Settings;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.Configure<BlazorPagingApiSettings>(builder.Configuration.GetSection(WebConstants.BlazorPagingApiName));

var blazorPagingApiSettings = builder.Configuration.GetSection(WebConstants.BlazorPagingApiName).Get<BlazorPagingApiSettings>()
                        ?? throw new NullReferenceException("BlazorPagingApiSettings");

builder.Services.AddHttpClient(WebConstants.BlazorPagingApiName, c => c.BaseAddress = new Uri(blazorPagingApiSettings.BaseAddress));

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
                .CreateClient(WebConstants.BlazorPagingApiName));

await builder.Build().RunAsync();
