
using Infra.EF;
using FileApi.Common.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var DefaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSingleton<DapperDBContext>(provider => new DapperDBContext(DefaultConnection));
builder.AddHelpersOptions();
builder.AddHelpersIOC();

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

