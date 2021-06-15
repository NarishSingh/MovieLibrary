-- CREATE DB
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

-- DDL
IF EXISTS(SELECT *
          FROM sys.tables
          WHERE name = 'Movie')
    DROP TABLE Movie;
GO

CREATE TABLE Movie
(
    MovieId    INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    MovieTitle NVARCHAR(200)                  NOT NULL,
    Likes      INT                            NOT NULL DEFAULT (0),
    Dislikes   INT                            NOT NULL DEFAULT (0)
);

-- SAMPLE DATA AND DbReset STORED PROCEDURE FOR TESTING
IF EXISTS(
        SELECT *
        FROM INFORMATION_SCHEMA.ROUTINES
        WHERE ROUTINE_NAME = 'DbReset'
    )
    DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset
AS
BEGIN
    -- scrub db
    DELETE FROM Movie;

    -- sample data
    DBCC CHECKIDENT ('Movie', RESEED , 1); -- reseed at 1
    SET IDENTITY_INSERT Movie ON;
    INSERT INTO Movie(MovieId, MovieTitle, Likes, Dislikes)
    VALUES (1, 'Test I', 1, 5),
           (2, 'Test II', 5, 7),
           (3, 'Test III: Test II Part II', 0, 99),
           -- actual movies for service testing
           (4, 'The Matrix', 1, 0),
           (5, 'The Matrix Reloaded', 1, 1),
           (6, 'The Matrix Revolutions', 0, 1);
    SET IDENTITY_INSERT Movie OFF;
END
GO

EXEC DbReset;

-- STORED PROCEDURES
IF EXISTS(
        SELECT *
        FROM INFORMATION_SCHEMA.ROUTINES
        WHERE ROUTINE_NAME = 'MovieInsert'
    )
    DROP PROCEDURE MovieInsert
GO

CREATE PROCEDURE MovieInsert(
    @MovieId INT OUTPUT,
    @MovieTitle NVARCHAR(200),
    @Likes INT,
    @Dislikes INT
) AS
BEGIN
    INSERT INTO Movie(MovieTitle, Likes, Dislikes)
    VALUES (@MovieTitle, @Likes, @Dislikes);

    SET @MovieId = SCOPE_IDENTITY();
END
GO

IF EXISTS(
        SELECT *
        FROM INFORMATION_SCHEMA.ROUTINES
        WHERE ROUTINE_NAME = 'MovieSelectById'
    )
    DROP PROCEDURE MovieSelectById
GO

CREATE PROCEDURE MovieSelectById(
    @MovieId INT
) AS
BEGIN
    SELECT *
    FROM Movie
    WHERE MovieId = @MovieId;
END
GO

IF EXISTS(
        SELECT *
        FROM INFORMATION_SCHEMA.ROUTINES
        WHERE ROUTINE_NAME = 'MoveSelectByTitle'
    )
    DROP PROCEDURE MovieSelectByTitle
GO

CREATE PROCEDURE MovieSelectByTitle(
    @MovieTitle NVARCHAR(200)
) AS
BEGIN
    SELECT *
    FROM Movie
    WHERE MovieTitle = @MovieTitle
END
GO


IF EXISTS(
        SELECT *
        FROM INFORMATION_SCHEMA.ROUTINES
        WHERE ROUTINE_NAME = 'MovieSelectAll'
    )
    DROP PROCEDURE MovieSelectAll
GO

CREATE PROCEDURE MovieSelectAll
AS
BEGIN
    SELECT *
    FROM Movie;
END
GO

IF EXISTS(
        SELECT *
        FROM INFORMATION_SCHEMA.ROUTINES
        WHERE ROUTINE_NAME = 'MovieUpdate'
    )
    DROP PROCEDURE MovieUpdate
GO

CREATE PROCEDURE MovieUpdate(
    @MovieId INT,
    @MovieTitle NVARCHAR(200),
    @Likes INT,
    @Dislikes INT
) AS
BEGIN
    UPDATE Movie
    SET MovieTitle = @MovieTitle,
        Likes      = @Likes,
        Dislikes   = @Dislikes
    WHERE MovieId = @MovieId
END
GO

IF EXISTS(
        SELECT *
        FROM INFORMATION_SCHEMA.ROUTINES
        WHERE ROUTINE_NAME = 'MovieDelete'
    )
    DROP PROCEDURE MovieDelete
GO

CREATE PROCEDURE MovieDelete(
    @MovieId INT
) AS
BEGIN
    DELETE
    FROM Movie
    WHERE MovieId = @MovieId
END
GO