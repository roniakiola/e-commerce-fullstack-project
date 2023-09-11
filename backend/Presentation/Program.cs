using System.Text;
using Application.Service.Abstraction;
using Application.Service.Implementation;
using Application.Service.Implementation.Shared;
using Domain.Abstraction.Repository;
using Infrastructure.Database;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Presentation.AuthRequirement;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// DBContext
builder.Services.AddDbContext<DatabaseContext>();

// Services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IAuthorizationHandler, OwnerOrAdminAuthHandler>();

// Add services to the container.
builder.Services.AddControllers();

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
  o.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
  {
    Description = "Bearer token authentication",
    Name = "Authentication",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.Http,
    Scheme = "bearer"
  });
  o.OperationFilter<SecurityRequirementsOperationFilter>();
});

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Configure routes
builder.Services.Configure<RouteOptions>(o => { o.LowercaseUrls = true; });

builder.Services.AddAuthorization(o =>
{
  o.AddPolicy("OwnerOrAdmin", policy => policy.Requirements.Add(new OwnerOrAdminReq()));
});

// Configure authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(o =>
  {
    var jwtConfig = builder.Configuration.GetSection("JwtConfig");

    o.TokenValidationParameters = new TokenValidationParameters
    {
      ValidateIssuer = true,
      ValidIssuer = jwtConfig["Issuer"],
      ValidateAudience = false,
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["SecretKey"])),
      ValidateIssuerSigningKey = true
    };
  });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
