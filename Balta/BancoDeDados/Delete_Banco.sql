SELECT * FROM[Categoria]


    DELETE
        [Curso]
    WHERE
        [CategoriaId] = 3
--Não pode deletar um elemento que está relacionado a outro, primeiro apagar a relação, depois o elemento

    DELETE
        [Categoria]
    WHERE
        [Id] = 3
