using Domain.Common.Model;
using Microsoft.Extensions.Options;

namespace FileApi.Common.Helpers;

public static class OptionsExtension
{
    public static void AddHelpersOptions(this WebApplicationBuilder builder)
    {

        var _ListClients = new List<ListClients>();
        new ConfigureFromConfigurationOptions<List<ListClients>>(builder.Configuration.GetSection("ListClients"))
            .Configure(_ListClients);
        builder.Services.AddSingleton(_ListClients);

        var ListFileSizes = new List<ListFileSize>();
        new ConfigureFromConfigurationOptions<List<ListFileSize>>(builder.Configuration.GetSection("ListFileSize"))
            .Configure(ListFileSizes);
        builder.Services.AddSingleton(ListFileSizes);
    }
}
