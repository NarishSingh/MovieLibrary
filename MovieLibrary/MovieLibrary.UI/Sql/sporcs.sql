USE MovieLibrary;
GO

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
        WHERE ROUTINE_NAME = 'MovieSelect'
    )
    DROP PROCEDURE MovieSelect
GO

CREATE PROCEDURE MovieSelect(
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