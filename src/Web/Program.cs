using System.Net;
using DotnetBlogApi.Application.Common.Exceptions;
using DotnetBlogApi.Infrastructure.Data;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddKeyVaultIfConfigured(builder.Configuration);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSwaggerUi(settings =>
{
    settings.Path = "/api";
    settings.DocumentPath = "/api/specification.json";
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapRazorPages();

app.MapFallbackToFile("index.html");

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

        if (contextFeature?.Error is NotFoundException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        }
        if (contextFeature?.Error is ForbiddenAccessException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
        }

        await context.Response.WriteAsJsonAsync(new { contextFeature?.Error?.Message });
        await context.Response.CompleteAsync();
    });
}); 

app.Map("/", () => Results.Redirect("/api"));

app.MapEndpoints();

app.Run();

public partial class Program { }
