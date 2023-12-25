using BlazorPaging.Api;
using BlazorPaging.Api.Endpoints;
using BlazorPaging.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICompanyService, CompanyService>();

builder.Services.AddCors(c => c.AddPolicy(ApiConstants.CorsPolicyName, p => p
                .AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

app.UseCors(ApiConstants.CorsPolicyName);
app.RegisterCompanyEndpoints();

app.Run();
