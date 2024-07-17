CREATE OR ALTER PROCEDURE spDeleteStudent (@StudentId UNIQUEIDENTIFIER)

AS

    BEGIN TRANSACTION

    DELETE
        FROM[StudentCourse]
        WHERE [StudentCourse].[StudentId] = @StudentId
    DELETE
        FROM[Student]
        WHERE [Student].[Id] = @StudentId

    COMMIT