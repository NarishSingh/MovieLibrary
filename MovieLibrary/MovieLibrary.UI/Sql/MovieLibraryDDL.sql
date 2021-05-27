USE MovieLibrary;
GO

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