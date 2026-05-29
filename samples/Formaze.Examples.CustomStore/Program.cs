using Formaze.Blazor.Mudblazor.Tools;
using Formaze.Examples.CustomStore.Components;
using Formaze.Examples.CustomStore.Stores;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

// Register Formaze with a custom IFormazeStore. The store is resolved from DI, so it can
// take constructor dependencies (here, an ILogger). Swap in any backend the same way.
builder.Services.AddFormaze<InMemoryLoggingStore>();

var app = builder.Build();

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
