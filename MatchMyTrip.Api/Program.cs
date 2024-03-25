using MatchMyTrip.Api.Controllers;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.mapper;
using MatchMyTrip.Persistence.context;
using MatchMyTrip.Persistence.repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MatchMyTripDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MatchMyTripConnectionString"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

var domain = "https://dev-c4fngek5.us.auth0.com";
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = domain;
    options.Audience = "https://localhost:7249";
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IJourney_ActivityRepository, Journey_ActivityRepository>();
builder.Services.AddScoped<ISearchRepository, SearchRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddHttpContextAccessor();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var serviceProvider = builder.Services.BuildServiceProvider();
var logger = serviceProvider.GetService<ILogger<UserController>>();
builder.Services.AddSingleton(typeof(ILogger), logger);


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
