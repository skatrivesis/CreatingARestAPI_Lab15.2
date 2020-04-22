USE [master]
DROP DATABASE IF EXISTS [MovieDB]
CREATE DATABASE [MovieDB]
GO
USE [MovieDB]
GO
CREATE TABLE [Movies](
    [Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [Name] [nvarchar](50) NOT NULL,
    [Category] [nvarchar](50) NOT NULL
	);

INSERT INTO [Movies] ([Name], [Category]) VALUES 
('Die Hard', 'Action'),
('Ratatouille', 'Family'),
('Knives Out', 'Drama'),
('The Shawshank Redemption', 'Drama'),
('Interstellar', 'Adventure')
go
