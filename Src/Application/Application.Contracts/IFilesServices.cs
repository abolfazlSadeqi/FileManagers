using Domain.Entites.FilePdfManagers;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts;

public interface IFilesServices
{
    Task Add(FileType fileType, string ClientID, int ClientCode, string fileName, byte[] fileContent);
    Task<List<FilePdfManager>> Getall();
}
