Implementation of file Manager service using FileTables sql Server and CleanArchitecture with Dapper 

## The following items have been implemented in this service

File upload for each client

Creating a folder based on the pattern: file type > client code > date

Receive the client list based on the app Setting

Download file based on code and client

Checking the file size (the size of the app Setting )


## Dapper
Dapper is an micro ORM for the Microsoft .NET platform: it provides a framework for mapping an object-oriented domain model to a traditional relational database.


## FileTable

The FileTable feature brings support for the Windows file namespace and compatibility with Windows applications to the file data stored in SQL Server.
FileTable lets an application integrate its storage and data management components, and provides integrated SQL Server services - 
including full-text search and semantic search - over unstructured data and metadata.
you can store files and documents in special tables in SQL Server called FileTables, 
but access them from Windows applications as if they were stored in the file system, without making any changes to your client applications.

## Steps
### 1.Install-Packages ON nugget
 |PackageName|
 |---|
|1.Dapper|
|2.System.Data.SqlClient|


### 2.Config Dapper

https://github.com/abolfazlSadeqi/DotNetCleanArchitectureJwtWithDapper/edit/master/README.md

### 3. Config FileTable in sql server

#### 1.Create DataBase

Add the FILESTREAM using the following config in the path file below
https://github.com/abolfazlSadeqi/FileManagers/blob/master/Script/0.createdb.sql

  ```
WITH FILESTREAM
(
NON_TRANSACTED_ACCESS = FULL,
DIRECTORY_NAME = N'FilesMangerDB'
)

  ```

#### 2.Create Table

create Tables using the following config in the path file below
https://github.com/abolfazlSadeqi/FileManagers/blob/master/Script/3.Create_Table.sql

  ```
 CREATE TABLE [dbo].[Files]
 AS FILETABLE
 WITH (FILETABLE_DIRECTORY = N'Files', FILETABLE_COLLATE_FILENAME = Latin1_General_CI_AS)
  ```

#### 3.Create Table FileMetadata

create Table FileMetadata using the following config in the path file below

To determine which client this file belongs to

https://github.com/abolfazlSadeqi/FileManagers/blob/master/Script/3.Create_Table.sql

  ```
 CREATE TABLE dbo.FileMetadata (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StreamId UNIQUEIDENTIFIER NOT NULL,
    ClientId VARCHAR(255),
    -- Add other columns as needed
    FOREIGN KEY (StreamId) REFERENCES dbo.Files(stream_id)
);
  ```
