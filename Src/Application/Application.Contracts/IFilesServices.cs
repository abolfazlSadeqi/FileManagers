﻿using Domain.Common.Model;
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
    Task<Guid> Add(FileType fileType, string ClientID,  string fileName, byte[] fileContent);
    Task<FilesModel> GetBystream_idandClientId(string ClientID, Guid stream_id);
}
