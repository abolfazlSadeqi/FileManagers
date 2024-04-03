 CREATE TABLE [dbo].[Files]
 AS FILETABLE
 WITH (FILETABLE_DIRECTORY = N'Files', FILETABLE_COLLATE_FILENAME = Latin1_General_CI_AS)

 
 CREATE TABLE dbo.FileMetadata (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StreamId UNIQUEIDENTIFIER NOT NULL,
    ClientId VARCHAR(255),
    -- Add other columns as needed
    FOREIGN KEY (StreamId) REFERENCES dbo.Files(stream_id)
);
