using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebRoutes.Infrastructure;
using WebRoutes.Mappers;
using WebRoutes.Models;
using WebRoutes.Repositories;
using WebRoutes.Repositories.implementation;
using WebRoutes.Services;
using WebRoutes.Services.implementation;
using WebRoutes.Infrastructure.TestDataConfig;
using WebRoutes.Services.Routes;
using WebRoutes.Services.Routes.Implementation;
using WebRoutes.Services.Subscriptions;
using WebRoutes.Services.Subscriptions.Implementation;
using WebRoutes.Services.Users;
using WebRoutes.Services.Users.Implementation;
using Route = WebRoutes.Models.Route;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;
using WebRoutes.Services.AdditionalPlaces;
using WebRoutes.Services.AdditionalPlaces.Implementation;
using WebRoutes.Services.Places;
using WebRoutes.Services.Places.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseSeeding((context, _) =>
        {
            if (context is ApplicationDbContext dbContext)
            {
                FakeDataSeeder.SeedSync(dbContext);
            }
        })
        .UseAsyncSeeding(async (context, _, cancellationToken) =>
        {
            if (context is ApplicationDbContext dbContext)
            {
                await FakeDataSeeder.SeedAsync(dbContext, cancellationToken);
            }
        });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "WebRoutes API",
    });
});

builder.Services.AddScoped<IRepository<Route>, Repository<Route>>();
builder.Services.AddScoped<IRepository<Place>, Repository<Place>>();

builder.Services.AddScoped<ITripRepository, RouteRepository>();
builder.Services.AddScoped<IRouteDataService, RouteDataService>();

builder.Services.AddScoped<ILocationRepository<Place>, LocationRepository<Place>>();

builder.Services.AddScoped<ILocationRepository<AdditionalPlace>, LocationRepository<AdditionalPlace>>();

builder.Services.AddScoped<IMarkRepository, MarkRepository>();
builder.Services.AddScoped<IMarkService, MarkService>();

builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionDataService, SubscriptionDataService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<ISubscriptionValidationService, SubscriptionValidationService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserDataService, UserDataService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IPlaceService, PlaceService>();
builder.Services.AddScoped<IPlaceDataService, PlaceDataService>();

builder.Services.AddScoped<IAdditionalPlaceService, AdditionalPlaceService>();
builder.Services.AddScoped<IAdditionalPlaceDataService, AdditionalPlaceDataService>();

builder.Services.AddScoped<IRouteService, RouteService>();
builder.Services.AddScoped<IRouteDataService, RouteDataService>();

builder.Services.AddScoped<IImageStorageService, ImageStorageService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebRoutes API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
