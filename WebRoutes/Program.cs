using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebRoutes.Infrastructure;
using WebRoutes.Mappers;
using WebRoutes.Models;
using WebRoutes.Repositories;
using WebRoutes.Repositories.implementation;
using WebRoutes.Services;
using WebRoutes.Services.implementation;
using WebRoutes.Infrastructure.TestDataConfiguration;
using WebRoutes.Services.Routes;
using WebRoutes.Services.Routes.Implementation;
using WebRoutes.Services.Subscriptions;
using WebRoutes.Services.Subscriptions.Implementation;
using WebRoutes.Services.Users;
using WebRoutes.Services.Users.Implementation;
using Route = WebRoutes.Models.Route;
using WebRoutes.Services.Marks;
using WebRoutes.Services.Marks.Implementation;
using WebRoutes.Services.Reviews;
using WebRoutes.Services.Reviews.Implementation;
using IRouteBuilder = WebRoutes.Services.Routes.IRouteBuilder;
using RouteBuilder = WebRoutes.Services.Routes.Implementation.RouteBuilder;

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
        Title = "ByWays API",
    });
});

builder.Services.Configure<DefaultPhotoSettings>(
    builder.Configuration.GetSection("DefaultPhotos"));

builder.Services.AddScoped<IRepository<Route>, Repository<Route>>();
builder.Services.AddScoped<IRepository<Place>, Repository<Place>>();

builder.Services.AddScoped<ILocationRepository<Place>, LocationRepository<Place>>();
builder.Services.AddScoped<ILocationRepository<AdditionalPlace>, LocationRepository<AdditionalPlace>>();

builder.Services.AddScoped<IMarkRepository, MarkRepository>();
builder.Services.AddScoped<IMarkDataService, MarkDataService>();
builder.Services.AddScoped<IMarkService, MarkService>();
builder.Services.AddScoped<IMarkValidationService, MarkValidationService>();

builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewDataService, ReviewDataService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IReviewValidationService, ReviewValidationService>();

builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionDataService, SubscriptionDataService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<ISubscriptionValidationService, SubscriptionValidationService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserDataService, UserDataService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserCreatingService, UserCreatingService>();

builder.Services.AddScoped<IRouteRepository, RouteRepository>();
builder.Services.AddScoped<IRouteService, RouteService>();
builder.Services.AddScoped<IRouteDataService, RouteDataService>();
builder.Services.AddScoped<IRouteCreatingService, RouteCreatingService>();
builder.Services.AddScoped<IRouteMapper, RouteMapper>();
builder.Services.AddScoped<IRouteValidationService, RouteValidationService>();

builder.Services.AddScoped<IImageStorageService, ImageStorageService>();

builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddScoped<IRouteBuilder, RouteBuilder>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
            )
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Please input the JWT Bearer token"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "ByWays API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
