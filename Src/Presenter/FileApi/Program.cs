
using Application;
using Application.Contracts;
using Domain.interfaces;
using Infra.Dapper.Repositorys;
using Infra.EF;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Normal AddLogging
builder.Services.AddLogging();
builder.Services.AddSingleton(s => s.GetRequiredService<ILoggerFactory>().CreateLogger(""));
// Call UseServiceProviderFactory on the Host sub property 

builder.Services.AddMemoryCache();
//// Call ConfigureContainer on the Host sub property 
//.. <PersonRepository>().As<IPersonRepository>();
//// Register your services
//builder.RegisterType<PersonApp>().As<IPersonApp>();

var DefaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSingleton<DapperDBContext>(provider => new DapperDBContext(DefaultConnection));
builder.Services.AddScoped<IFilesServices, FilesService>();
builder.Services.AddScoped<IFilesRepository, FilesRepository>();

//AddIOC(builder);
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

