USE MovieLibraryTest;
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
