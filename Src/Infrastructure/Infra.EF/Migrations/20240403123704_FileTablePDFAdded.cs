//using System;
//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace Infra.EF.Migrations
//{
//    /// <inheritdoc />
//    public partial class FileTablePDFAdded : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "FilePdfManager",
//                columns: table => new
//                {
//                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    FileStream = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
//                    Name = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
//                    File_type = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
//                    CachedFileSize = table.Column<long>(type: "bigint", nullable: true),
//                    Creation_time = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
//                    Last_write_time = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
//                    Last_access_time = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
//                    Isdirectory = table.Column<bool>(type: "bit", nullable: false),
//                    Isoffline = table.Column<bool>(type: "bit", nullable: false),
//                    Ishidden = table.Column<bool>(type: "bit", nullable: false),
//                    Isreadonly = table.Column<bool>(type: "bit", nullable: false),
//                    Isarchive = table.Column<bool>(type: "bit", nullable: false),
//                    Issystem = table.Column<bool>(type: "bit", nullable: false),
//                    Istemporary = table.Column<bool>(type: "bit", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_FilePdfManager", x => x.Id);
//                });
//        }

//        /// <inheritdoc />
//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "FilePdfManager");
//        }
//    }
//}
