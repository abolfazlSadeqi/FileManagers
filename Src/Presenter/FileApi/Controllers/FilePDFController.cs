using Application.Contracts;
using Domain.Enums;
using FileApi.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using System.Runtime.Intrinsics.Arm;

namespace FileApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class FilePDFController : BaseControllerBase
{
    public readonly IFilesServices _filePdfManagerservice;
    private readonly IOptions<List<ListClients>> _ListClients;
    private readonly IOptions<List<ListFileSize>> _ListFileSize;

    public FilePDFController(
          IFilesServices filePdfManagerservice
        , IOptions<List<ListClients>> ListClients
        , IOptions<List<ListFileSize>> listFileSize) : base(ListClients, listFileSize)
    {
        _filePdfManagerservice = filePdfManagerservice;
        _ListClients = ListClients;
        _ListFileSize = listFileSize;
    }



    [Route("UploadFiles")]
    [HttpPost]
    public async Task<IActionResult> UploadFiles(string ClientID, string fileName, byte[] fileContent)
    {
        //to do :find ClientCode of DB
        int ClientCode = GetClientCode(ClientID);
        CheckSize(FileType.PDF, fileContent);
        return Ok(await _filePdfManagerservice.Add(FileType.PDF, ClientID, ClientCode, fileName, fileContent));
      
    }

    [Route("DownloadFiles")]
    [HttpGet]
    public async Task<IActionResult> DownloadFiles(string ClientId, Guid stream_id)
       => Ok(await _filePdfManagerservice.GetBystream_idandClientId(ClientId, stream_id));
  

    
}
