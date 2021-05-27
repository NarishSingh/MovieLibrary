USE MovieLibrary;
GO

IF EXISTS(SELECT *
          FROM sys.tables
          WHERE name = 'Movie')
    DROP TABLE Movie;
GO

CREATE TABLE Movie
(
    MovieId           INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    ImdbId            CHAR(9)                        NOT NULL,
    Title             NVARCHAR(128)                  NOT NULL,
    Director          NVARCHAR(128)                  NOT NULL,
    ReleaseDate       DATE                           NOT NULL,
    Liked             BIT                            NOT NULL DEFAULT (0),
    Description       NVARCHAR(500),
    YoutubeTrailerKey NVARCHAR(20)
);