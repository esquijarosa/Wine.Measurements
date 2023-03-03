using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using Wine.Measurements.Common.Data;
using Wine.Measurements.Common.Data.InMem;
using Wine.Measurements.Common.Data.SqlData;
using Wine.Measurements.Security.Common;

var builder = WebApplication.CreateBuilder(args);

if (builder.Configuration["ConnectionId"] == null)
{
    builder.Services.AddSingleton<IUserRepository, InMemUserRepository>();
    builder.Services.AddSingleton<IMeasurementsRepository, InMemMeasurementsRepository>();
}
else
{
    builder.Services.AddSingleton<IUserRepository, SqlUserRepository>();
    builder.Services.AddSingleton<IMeasurementsRepository, SqlMeasurementsRepository>();
}

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var apiKey = builder.Configuration["API-KEY"];

builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(apiKey)),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

builder.Services.AddSingleton<IJwtAuthenticator, JwtAuthenticationManager>();

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
