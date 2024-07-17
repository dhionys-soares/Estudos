USE[Cursos]

INSERT INTO[Categoria]([Nome]) VALUES('Backend')
INSERT INTO[Categoria]([Nome]) VALUES('Frontend')
INSERT INTO[Categoria]([Nome]) VALUES('Mobile')

INSERT into [Curso]([Nome], [CategoriaId]) VALUES('Fundamentos de C#', 1)
INSERT into [Curso]([Nome], [CategoriaId]) VALUES('Fundamentos de OOP', 1)
INSERT into [Curso]([Nome], [CategoriaId]) VALUES('Angular', 2)
INSERT into [Curso]([Nome], [CategoriaId]) VALUES('Flutter', 3)
INSERT into [Curso]([Nome], [CategoriaId]) VALUES('Flutter e SQLite', 3)