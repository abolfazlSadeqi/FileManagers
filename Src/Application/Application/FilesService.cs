using Application.Contracts;
using Domain.Common;
using Domain.Common.Model;
using Domain.Entites.FilePdfManagers;
using Domain.Enums;
using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application;

public class FilesService : IFilesServices
{
    private readonly List<ListClients> _ListClients;

    private readonly List<ListFileSize> _ListFileSize;
    public readonly IFilesRepository _filePdfManager;
    public FilesService(IFilesRepository filePdfManager, List<ListClients> listClients, List<ListFileSize> ListFileSize)
    {
        this._filePdfManager = filePdfManager;
        this._ListClients = listClients;
        this._ListFileSize = ListFileSize;

    }

    public async Task<Guid> Add(FileType fileType, string ClientID, string fileName, byte[] fileContent)
    {
        Check(ClientID, fileName, fileContent);
        //to do :find ClientCode of DB
        int ClientCode = GetClientCode(ClientID);
        CheckSize(FileType.PDF, fileContent);
        return await _filePdfManager.Add(fileType, ClientID, ClientCode, fileName, fileContent);
    }

    public async Task<FilesModel> GetBystream_idandClientId(string ClientID, Guid stream_id)
     => await _filePdfManager.GetBystream_idandClientId(ClientID, stream_id);


    private void Check(string ClientID, string fileName, byte[] fileContent)
    {
        if (string.IsNullOrEmpty(ClientID))
            throw new Exception(string.Format(Resources.DataEmpty, " ClientID "));

        if (string.IsNullOrEmpty(fileName))
            throw new Exception(string.Format(Resources.DataEmpty, " fileName "));

        if (fileContent is null || fileContent.Length == 0)
            throw new Exception(string.Format(Resources.DataEmpty, " fileContent "));
    }

    private void CheckSize(FileType fileType, byte[] fileContent)
    {
        var size = _ListFileSize.FirstOrDefault(d => d.FileType == fileType).Size;
        double sizeInMB = (double)fileContent.Length / (1024 * 1024);

        if (sizeInMB > size)
            throw new Exception(Resources.FileIsLarge);

    }
    protected int GetClientCode(string ClientID)
    {
        if (string.IsNullOrEmpty(ClientID))
            throw new Exception(Resources.ClientIDNotFound);
        var data = _ListClients.FirstOrDefault(d => d.ClientId == ClientID);
        if (data is null)
            throw new Exception(Resources.ClientIDNotFound);

        return data.ClientCode;
    }

}
