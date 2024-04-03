

using Dapper;
using Domain.Entites.FilePdfManagers;
using Domain.Enums;
using Domain.interfaces;
using Infra.Dapper.Common;
using Infra.Dapper.SqlCommandConst;
using Infra.EF;

namespace Infra.Dapper.Repositorys;

public class FilesRepository : IFilesRepository
{

    private readonly DapperDBContext _context;


    public FilesRepository(DapperDBContext context) => _context = context;

    public async Task<Guid> Add(FileType fileType, string ClientID, int ClientCode, string fileName, byte[] fileContent)
    {
        await AdddirectoryWithDateAsync(fileType, ClientID, ClientCode);
        var StreamId = Guid.NewGuid();

        string Date = FilesPath.GetDateFormatPath();

        string _Path = FilesPath.CreatePathWithfileTypeClientCodeDate(fileType, ClientCode);

        fileName = fileName + "." + fileType.ToString();
        using (var db = _context.CreateConnection())
        {

            var dictionary = new Dictionary<string, object>
                    {
                         { "@FileName", fileName }
                        ,{ "@FileContent", fileContent }
                        ,{ "@ClientID", ClientID }
                        ,{ "@StreamId", StreamId }

                    };
            var parameters = new DynamicParameters(dictionary);
            string query = FilesSqlCommand.sqlINSERT.Replace("@Path", _Path);
            await db.ExecuteAsync(query, parameters);

        }
        return StreamId;
    }
    private async Task AdddirectoryWithDateAsync(FileType fileType, string ClientId, int ClientCode)
    {
        await AddFileTypedirectoryAsync(fileType, ClientCode);
        await AddClientdirectoryAsync(fileType, ClientId, ClientCode);
        await AddClientdirectoryWithDateAsync(fileType, ClientId, ClientCode);

    }
    private async Task AddFileTypedirectoryAsync(FileType fileType, int ClientCode)
    {
        string _FileType = "/" + ((int)fileType).ToString() + "/";
        using (var db = _context.CreateConnection())
        {

            var dictionary = new Dictionary<string, object>
                    {
                         { "@FileType", fileType.ToString() }

                    };
            var parameters = new DynamicParameters(dictionary);
            string query = FilesSqlCommand.sqlCreateFileTypedirectory.Replace("@FileTypeId", _FileType);
            await db.ExecuteAsync(query, parameters);

        }
    }



    private async Task AddClientdirectoryAsync(FileType fileType, string ClientId, int ClientCode)
    {

        string _Path = FilesPath.CreatePathWithfileTypeClientCode(fileType, ClientCode);
        using (var db = _context.CreateConnection())
        {

            var dictionary = new Dictionary<string, object>
                    {
                         { "@FileType", fileType.ToString() }
                        ,{ "@ClientId", ClientId }
                    };
            var parameters = new DynamicParameters(dictionary);
            string query = FilesSqlCommand.sqlCreateFileTypeSubdirectory.Replace("@Path", _Path);
            await db.ExecuteAsync(query, parameters);
        }
    }

    private async Task AddClientdirectoryWithDateAsync(FileType fileType, string ClientId, int ClientCode)
    {

        string Date = FilesPath.GetDateFormatPath();

        string _Path = FilesPath.CreatePathWithfileTypeClientCodeDate(fileType, ClientCode);
        using (var db = _context.CreateConnection())
        {

            var dictionary = new Dictionary<string, object>
                    {
                         { "@FileType", fileType.ToString() }
                        ,{ "@Date", Date }

                    };
            var parameters = new DynamicParameters(dictionary);
            string query = FilesSqlCommand.sqlCreateFileTypeSubdirectoryDate.Replace("@Path", _Path);
            await db.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<FilePdfManager>> Getall()
    {
        using (var db = _context.CreateConnection())
        {
            return (await db.QueryAsync<FilePdfManager>(FilesSqlCommand.sqlGetAll)).ToList();
        }

    }

}
