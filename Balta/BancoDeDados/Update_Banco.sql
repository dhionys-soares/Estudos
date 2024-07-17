SELECT * FROM[Categoria]

BEGIN TRANSACTION

        UPDATE
            [Categoria]
        SET
            [Nome] = 'Banana'
        WHERE
            [Id] = 3

COMMIT