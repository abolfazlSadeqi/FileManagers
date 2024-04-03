using Domain.Enums;
using FileApi.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FileApi.Controllers;

public class BaseControllerBase : ControllerBase
{
    private readonly IOptions<List<ListClients>> _ListClients;
    private readonly IOptions<List<ListFileSize>> _ListFileSize;

    public BaseControllerBase(IOptions<List<ListClients>> ListClients, IOptions<List<ListFileSize>> listFileSize)
    {
        _ListClients = ListClients;
        _ListFileSize = listFileSize;
    }

    protected void CheckSize(FileType fileType, byte[] fileContent)
    {
        var size = _ListFileSize.Value.FirstOrDefault(d => d.FileType == fileType).Size;
        double sizeInMB = (double)fileContent.Length / (1024 * 1024);

        if(sizeInMB > size)
            throw new Exception(Resources.FileIsLarge);

    }
    protected int GetClientCode(string ClientID)
    {
        if (string.IsNullOrEmpty(ClientID))
            throw new Exception(Resources.ClientIDNotFound);
        var data = _ListClients.Value.FirstOrDefault(d => d.ClientId == ClientID);
        if (data is null)
            throw new Exception(Resources.ClientIDNotFound);

        return data.ClientCode;
    }

}
