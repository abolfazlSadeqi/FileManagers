﻿using Application.Contracts;
using Domain.Entites.FilePdfManagers;
using Domain.Enums;
using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application;

public class FilesService : IFilesServices
{
    public readonly IFilesRepository _filePdfManager;
    public FilesService(IFilesRepository filePdfManager)
    {
        this._filePdfManager = filePdfManager;
    }

    public async Task Add(FileType fileType, string ClientID, int ClientCode, string fileName, byte[] fileContent)
       => await _filePdfManager.Add( fileType,  ClientID,  ClientCode,  fileName, fileContent);

    public async Task<List<FilePdfManager>> Getall()
     => await _filePdfManager.Getall();
}