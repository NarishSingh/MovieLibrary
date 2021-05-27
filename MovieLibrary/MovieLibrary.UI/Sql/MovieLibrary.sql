USE master;
GO

IF EXISTS(SELECT *
          FROM sys.databases
          WHERE name = 'MovieLibrary')
    DROP DATABASE MovieLibrary;
GO

CREATE DATABASE MovieLibrary;
GO

USE MovieLibrary;
GO