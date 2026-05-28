using Formaze.Blazor.Mudblazor.EFCore;
using Formaze.Examples.EfCore.Components;
using Formaze.Examples.EfCore.Data;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

// Register your DbContext, then point Formaze at it.
builder.Services.AddDbContext<GalleryDbContext>(o => o.UseSqlite("Data Source=formaze.db"));
builder.Services.AddFormazeEfCore<GalleryDbContext>();

var app = builder.Build();

// Create the database/schema on first run. In production, use EF Core migrations instead.
using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<GalleryDbContext>().Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
