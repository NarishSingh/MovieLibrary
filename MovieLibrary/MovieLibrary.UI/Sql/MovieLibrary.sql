USE master;
GO

-- PRODUCTION
IF EXISTS(SELECT *
          FROM sys.databases
          WHERE name = 'MovieLibrary')
    DROP DATABASE MovieLibrary;
GO

CREATE DATABASE MovieLibrary;
GO

-- TEST
IF EXISTS(SELECT *
          FROM sys.databases
          WHERE name = 'MovieLibraryTest')
    DROP DATABASE MovieLibraryTest;
GO

CREATE DATABASE MovieLibraryTest;
GO

USE MovieLibrary;
GO