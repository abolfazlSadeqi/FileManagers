

using Domain.Entites.FilePdfManagers;
using Domain.Enums;
using System.Data;

namespace Domain.interfaces;

public interface IFilesRepository
{


    Task<Guid> Add(FileType fileType, string ClientID, int ClientCode, string fileName, byte[] fileContent);
    Task<List<FilePdfManager>> Getall();

}
