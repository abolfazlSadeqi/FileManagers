using Application.Contracts;
using Application;
using Domain.interfaces;
using Infra.Dapper.Repositorys;

namespace FileApi.Common.Helpers;

public static class IOCExtension
{
    public static void AddHelpersIOC(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IFilesServices, FilesService>();
        builder.Services.AddSingleton<IFilesRepository, FilesRepository>();
    }
}