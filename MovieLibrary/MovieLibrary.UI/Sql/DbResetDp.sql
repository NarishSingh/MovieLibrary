USE MovieLibrary;
GO

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
    --scrub db
    DELETE FROM Movie;

    --sample data
    SET IDENTITY_INSERT Movie ON;
    INSERT INTO Movie(MovieId, MovieTitle, Likes, Dislikes)
    VALUES (1, 'Test I', 1, 5),
           (2, 'Test II', 5, 7),
           (3, 'Test III: Test II Part II', 0, 99);
END
GO

EXEC DbReset;
