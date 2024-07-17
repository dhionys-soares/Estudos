DECLARE @Id INT
SET @Id = 1

SELECT * FROM Curso WHERE Id = @Id

-----------------------------------------------------

DECLARE @CategoryId INT
SET @CategoryId = (
    SELECT TOP 1
        [Id]
    FROM
        Categoria
    WHERE
        Nome = 'Backend'
    )

    SELECT * FROM Curso WHERE CategoriaId = @CategoryId