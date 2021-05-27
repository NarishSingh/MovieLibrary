USE MovieLibrary;
GO

IF EXISTS(SELECT *
          FROM sys.tables
          WHERE name = 'MovieDirector')
    DROP TABLE MovieDirector;
GO

IF EXISTS(SELECT *
          FROM sys.tables
          WHERE name = 'MovieGenre')
    DROP TABLE MovieGenre;
GO


IF EXISTS(SELECT *
          FROM sys.tables
          WHERE name = 'Director')
    DROP TABLE Director;
GO

IF EXISTS(SELECT *
          FROM sys.tables
          WHERE name = 'Genre')
    DROP Table Genre;
GO

IF EXISTS(SELECT *
          FROM sys.tables
          WHERE name = 'Movie')
    DROP TABLE Movie;
GO

CREATE TABLE Director
(
    DirectorId   INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    DirectorName NVARCHAR(128)                  NOT NULL
);

CREATE TABLE Genre
(
    GenreId   INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    GenreName NVARCHAR(20)                   NOT NULL
);

CREATE TABLE Movie
(
    MovieId           INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    ImdbId            CHAR(9)                        NOT NULL,
    Title             NVARCHAR(128)                  NOT NULL,
    ReleaseDate       DATE                           NOT NULL,
    Liked             BIT                            NOT NULL DEFAULT (0),
    Description       NVARCHAR(500),
    YoutubeTrailerKey NVARCHAR(20),
);

CREATE TABLE MovieDirector
(
    MovieId    INT NOT NULL,
    DirectorId INT NOT NULL,
    PRIMARY KEY (MovieId, DirectorId),
    CONSTRAINT Fk_Movie_MovieDirector FOREIGN KEY (MovieId)
        REFERENCES Movie (MovieId),
    CONSTRAINT Fk_Director_MovieDirector FOREIGN KEY (DirectorId)
        REFERENCES Director (DirectorId)
);

CREATE TABLE MovieGenre
(
    MovieId INT NOT NULL,
    GenreId INT NOT NULL,
    PRIMARY KEY (MovieId, GenreId),
    CONSTRAINT Fk_Movie_MovieGenre FOREIGN KEY (MovieId)
        REFERENCES Movie (MovieId),
    CONSTRAINT Fk_Genre_MovieGenre FOREIGN KEY (GenreId)
        REFERENCES Genre (GenreId)
);