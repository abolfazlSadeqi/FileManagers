using Application.Contracts;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FileApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileDocController : BaseControllerBase
{
    public readonly IFilesServices _filePdfManagerservice;

    public FileDocController(
          IFilesServices filePdfManagerservice) : base()
    {
        _filePdfManagerservice = filePdfManagerservice;
    }

    [Route("UploadFiles")]
    [HttpPost]
    public async Task<IActionResult> UploadFiles(string ClientID, string fileName, byte[] fileContent)
       => Ok(await _filePdfManagerservice.Add(FileType.Docx, ClientID, fileName, fileContent));

    [Route("DownloadFiles")]
    [HttpGet]
    public async Task<IActionResult> DownloadFiles(string ClientId, Guid stream_id)
       => Ok(await _filePdfManagerservice.GetBystream_idandClientId(ClientId, stream_id));

}
