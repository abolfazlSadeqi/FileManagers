using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.EF.Migrations;


public partial class FileTablePDFAdded : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"
                            CREATE TABLE [dbo].[FilePdfManager]
                            AS FILETABLE
                            WITH (FILETABLE_DIRECTORY = N'FilePdfManager', FILETABLE_COLLATE_FILENAME = Latin1_General_CI_AS)
            ");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "FilePdfManager");
    }
}
