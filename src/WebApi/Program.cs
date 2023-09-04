using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sauric.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

builder.Services.AddDbContext<AuthUserDbContext>(
    x => x.UseNpgsql(Environment.GetEnvironmentVariable("PostgresDbConnection")));

builder.Services
    .AddIdentityCore<AuthUser>()
    .AddEntityFrameworkStores<AuthUserDbContext>()
    .AddApiEndpoints();

var app = builder.Build();

app.MapIdentityApi<AuthUser>();


app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x.SetIsOriginAllowed(static _ => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials());

app.Run();
