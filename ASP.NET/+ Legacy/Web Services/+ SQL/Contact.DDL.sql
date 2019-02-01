USE [MailGenerator]
GO

IF EXISTS (
       SELECT *
       FROM   INFORMATION_SCHEMA.TABLES
       WHERE  TABLE_NAME = 'Contact'
   )
    DROP TABLE Contact
GO

CREATE TABLE Contact (
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name NVARCHAR(128) NOT NULL,
	Mail VARCHAR(128) NOT NULL,    
	[Text] VARCHAR(1024) NULL,
	Link VARCHAR(1024) NULL,
   BitlyLink VARCHAR(1024) NULL,
   Generated BIT NULL
)

GO

