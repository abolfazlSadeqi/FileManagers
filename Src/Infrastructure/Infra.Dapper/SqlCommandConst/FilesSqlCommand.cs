using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infra.Dapper.SqlCommandConst;

public class FilesSqlCommand
{
    private const string _tablename = "Files";
    private const string _tableFileMetadataname = "FileMetadata";

    public const string sqlGetCountNew = "SELECT COUNT(*) FROM " + _tablename + " where cast( Created as date)= cast(Getdate() as date)";
    public const string sqlGetFirst = " SELECT id,firstname + ' ' + lastName as FullName  ,Email +' | ' + PhoneNumber Email_PhoneNumber ,BankAccountNumber " +
        "FROM " + _tablename + " where cast( Created as date)= cast(Getdate() as date)";

    public const string sqlGetAll =
       @" SELECT * " + "FROM " + _tablename;


    public const string sqlINSERT = @"BEGIN TRANSACTION; BEGIN TRY " +
                  @"declare @newid varchar(100)=newid() 
                  declare @path_locator varchar(100)=''
                  SELECT @path_locator = ISNULL('@Path', '/')  + " +
                  @" convert(varchar(20), convert(bigint, substring(convert(binary(16), @newid), 1, 6))) + '.' + " +
                  @" convert(varchar(20), convert(bigint, substring(convert(binary(16), @newid), 7, 6))) + '.' + " +
                  @" convert(varchar(20), convert(bigint, substring(convert(binary(16), @newid), 13, 4))) + '/'  " +
                  @" INSERT INTO " + _tablename + "  (stream_id,name, file_stream,path_locator) " +
                                    "  VALUES (@StreamId,@FileName, @FileContent,@path_locator)" +
                                    " INSERT INTO " + _tableFileMetadataname + "([StreamId],[ClientId]) VALUES(@StreamId,@ClientId)" +
                                     "COMMIT TRANSACTION; END TRY   BEGIN CATCH  ROLLBACK TRANSACTION;END CATCH;";


    public const string
        sqlCreateFileTypedirectory
                                = @"if(( select count(*) from " + _tablename + @" where path_locator='@FileTypeId')=0)
                                Begin
                                    INSERT " + _tablename + @" ([name], path_locator, is_directory) VALUES(@FileType, '@FileTypeId', 1)
                                end";

    public const string
        sqlCreateFileTypeSubdirectory
                                = @"if(( select count(*) from " + _tablename + @" where path_locator='@Path')=0)
                                    Begin
                                        INSERT " + _tablename + @" ([name], path_locator, is_directory) 
                                        VALUES(@ClientId, '@Path', 1)
                                    end";


    public const string
       sqlCreateFileTypeSubdirectoryDate
                               = @"if(( select count(*) from " + _tablename + @" where path_locator='@Path')=0)
                                    Begin
                                        INSERT " + _tablename + @" ([name], path_locator, is_directory) 
                                        VALUES(@Date, '@Path', 1)
                                    end";
}
