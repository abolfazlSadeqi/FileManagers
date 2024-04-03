using Application.Contracts;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;

namespace FileApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilePDFController : ControllerBase
{
    public readonly IFilesServices _filePdfManagerservice;
    public FilePDFController(IFilesServices filePdfManagerservice)
    {
        _filePdfManagerservice = filePdfManagerservice;
    }

    [Route("UploadFiles")]
    [HttpPost]
    public async Task<IActionResult> UploadFiles(string ClientID, string fileName, byte[] fileContent)
    {
        //to do :find ClientCode to DB
        int ClientCode = 1411;
        await _filePdfManagerservice.Add(FileType.PDF, ClientID, ClientCode, fileName, fileContent);
        return Ok();

    }

    [Route("DownloadFiles")]
    [HttpGet]
    public async Task<IActionResult> DownloadFiles(string ClientId, Guid stream_id)
    {
        await _filePdfManagerservice.Getall();
        return Ok();

    }
}
