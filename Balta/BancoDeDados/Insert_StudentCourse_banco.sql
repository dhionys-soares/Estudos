DECLARE @StudentId UNIQUEIDENTIFIER = (SELECT NEWID())

    INSERT INTO [Student](
        [Id],
        [Name],
        [Email],
        [Document],
        [Phone],
        [BirthDate],
        [CreateDate])
    VALUES(
        @StudentId,
        'Dhionys Soares',
        'dhi.soares#hotmail.com',
        '9086228559',
        '51984587995',
        '1991-11-18',
        GETDATE())

    SELECT * FROM [Student]
    SELECT * FROM [Course] WHERE [Course].[Id] = '5f5a33f8-4ff3-7e10-cc6e-3fa000000000'

    INSERT INTO [StudentCourse](
        [CourseId],
        [StudentId],
        [Progress],
        [Favorite],
        [StartDate],
        [LastUpdateDate]
    )
    VALUES(
        '5f5a33f8-4ff3-7e10-cc6e-3fa000000000',
        '4102d295-f412-4812-afb0-bfbbc1cab74b',
        50,
        0,
        '2023-11-23 21:05',
        GETDATE()
    )

    SELECT * FROM [StudentCourse]
