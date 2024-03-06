using MatchMyTrip.App.Components;
using MatchMyTrip.App.Interfaces;
using MatchMyTrip.App.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCors();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJourney_ActivityService, Journey_ActivityService>();
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<IJourneyService, JourneyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader());
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
