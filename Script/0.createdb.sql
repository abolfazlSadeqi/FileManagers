IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'FilesMangerDB') BEGIN
ALTER DATABASE FilesMangerDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE FilesMangerDB;
END;

CREATE DATABASE FilesMangerDB 
ON
PRIMARY ( 
      NAME = FilesMangerDB, 
      FILENAME = 'E:\doc\DB\FilesMangerDB.mdf'
), FILEGROUP FilesMangerFS CONTAINS FILESTREAM( 
      NAME = FilesMangerFS,
    FILENAME = 'E:\doc\DB\FilesMangerDB')
LOG ON (                         
      NAME = FilesMangerLOG,
    FILENAME = 'E:\doc\DB\FilesMangerDB.ldf')
WITH FILESTREAM
( 
NON_TRANSACTED_ACCESS = FULL,
DIRECTORY_NAME = N'FilesMangerDB'
);
GO


