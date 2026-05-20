using System.Text;
using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Domain.Constants;
using HassanAdly.Infrastructure.Authentication;
using HassanAdly.Domain.Entities;
using HassanAdly.Persistence.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddApplicationServices();
builder.AddPersistenceServices();
builder.AddInfrastructureServices();

builder.Services.AddControllers();

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler(options => options.AllowStatusCode404Response = true);
builder.Services.AddExceptionHandler<HassanAdly.Api.Infrastructure.ProblemDetailsExceptionHandler>();

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer<HassanAdly.Api.Infrastructure.BearerSecuritySchemeTransformer>();
});

builder.Services.AddCors();

var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>() ?? new JwtOptions();
if (string.IsNullOrWhiteSpace(jwtOptions.SigningKey))
{
    if (!builder.Environment.IsDevelopment())
    {
        throw new InvalidOperationException("Jwt:SigningKey must be configured.");
    }

    jwtOptions = new JwtOptions
    {
        Issuer = jwtOptions.Issuer,
        Audience = jwtOptions.Audience,
        SigningKey = "dev-only-signing-key-change-me",
        AccessTokenLifetimeMinutes = jwtOptions.AccessTokenLifetimeMinutes
    };
}

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SigningKey)),
            ClockSkew = TimeSpan.FromMinutes(1)
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var dbInitialiser = scope.ServiceProvider.GetRequiredService<AppDbContextInitialiser>();
    await dbInitialiser.InitialiseAsync(app.Lifetime.ApplicationStopping);

    var adminSeedEmail = Environment.GetEnvironmentVariable("ADMIN_SEED_EMAIL");
    var adminSeedPassword = Environment.GetEnvironmentVariable("ADMIN_SEED_PASSWORD");
    if (!string.IsNullOrWhiteSpace(adminSeedEmail) && !string.IsNullOrWhiteSpace(adminSeedPassword))
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();

        var existing = await dbContext.AdminUsers.FirstOrDefaultAsync(x => x.Email == adminSeedEmail, app.Lifetime.ApplicationStopping);
        if (existing is null)
        {
            dbContext.AdminUsers.Add(new AdminUser
            {
                Id = 0,
                Email = adminSeedEmail.Trim(),
                PasswordHash = passwordHasher.Hash(adminSeedPassword),
                DisplayName = "Super Admin",
                Role = Roles.SuperAdmin,
                IsActive = true
            });
            await dbContext.SaveChangesAsync(app.Lifetime.ApplicationStopping);
        }
    }
}

app.UseHttpsRedirection();

app.UseCors(cors => cors
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowAnyOrigin());

app.UseExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

app.MapOpenApi();
app.MapScalarApiReference();

app.MapControllers();

app.Map("/", () => Results.Redirect("/scalar"));

app.Run();
