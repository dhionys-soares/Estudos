USE [Curso]
CREATE TABLE[Aluno](
    [Id] INT,
    [Nome] NVARCHAR(80) NOT NULL,
    [Nascimento] DATETIME NULL,
    [Active] BIT NOT NULL DEFAULT(0),
    [Email] NVARCHAR(180) NOT NULL,

CONSTRAINT [PK_Aluno] PRIMARY KEY([Id]),
CONSTRAINT [UQ_Email] UNIQUE([Email])
)

DROP TABLE[Aluno]

ALTER TABLE[Aluno]
ADD [Email] NVARCHAR(180) NOT NULL

ALTER TABLE[Aluno]
ADD CONSTRAINT[UQ_Aluno_Email] UNIQUE([Email])

-- CREATE TABLE[Curso](
--     [Id] INT NOT NULL,
--     [Nome] NVARCHAR(80) NOT NULL,
--     [CategoriaId] INT NOT NULL,

-- CONSTRAINT [PK_Curso] PRIMARY KEY([Id]),
-- CONSTRAINT [FK_Curso_Categoria] FOREIGN KEY([CategoriaId])
-- REFERENCES[Categoria]([Id])
-- )

DROP TABLE[Curso]

-- CREATE TABLE[ProgressoCurso](
--     [AlunoId] INT NOT NULL,
--     [CursoId] INT NOT NULL,
--     [Progresso] INT NOT NULL,
--     [UltimaAtualizacao] DATETIME NOT NULL DEFAULT(Getdate()),

--     CONSTRAINT[PK_ProgressoCurso] PRIMARY KEY([AlunoId], [CursoId])
-- )

DROP TABLE[ProgressoCurso]

-- CREATE TABLE[Categoria](
--     [Id] INT NOT NULL,
--     [Nome] NVARCHAR(80) NOT NULL,
    

--     CONSTRAINT[PK_Categoria] PRIMARY KEY([Id])
-- )

CREATE INDEX[IX_Aluno_Email] ON [Aluno]([Email])

DROP INDEX [IX_Aluno_Email] ON [Aluno]