
using Application;
using Application.Contracts;
using Domain.interfaces;
using FileApi.Common;
using Infra.Dapper.Repositorys;
using Infra.EF;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Runtime.Intrinsics.Arm;

var builder = WebApplication.CreateBuilder(args);

// Normal AddLogging
builder.Services.AddLogging();
builder.Services.AddSingleton(s => s.GetRequiredService<ILoggerFactory>().CreateLogger(""));
builder.Services.AddMemoryCache();

var DefaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSingleton<DapperDBContext>(provider => new DapperDBContext(DefaultConnection));
builder.Services.AddScoped<IFilesServices, FilesService>();
builder.Services.AddScoped<IFilesRepository, FilesRepository>();

builder.Services.Configure<List<ListClients>>(builder.Configuration.GetSection("ListClients"));
builder.Services.Configure<List<ListFileSize>>(builder.Configuration.GetSection("ListFileSize"));

builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddControllersAsServices();
var app = builder.Build();



app.MapControllers();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

// Ensure UseRouting is called before UseAuthorization and UseAuthentication
app.UseRouting();

app.Run();

