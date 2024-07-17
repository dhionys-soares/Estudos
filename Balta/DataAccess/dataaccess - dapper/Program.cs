using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

const string connectionstring = "Server=localhost,1433;Database=balta;User ID=sa;Password=Synoihd10@;Trusted_Connection=False; TrustServerCertificate=True;";

using (var connection = new SqlConnection(connectionstring))
{
    // UpdateCategory(connection);
    // DeleteCategory(connection);
    // CreateManyCategory(connection);
    // ListCategories(connection);
    // CreateCategory(connection);
    // ExecuteReadProcedure(connection);
    // ExecuteProcedure(connection);
    // ReadView(connection);
    // OneToOne(connection);
    // OneToMany(connection);
    // QueryMultiple(connection);
    // SelectIn(connection);
    // Like(connection, "api");
    Transaction(connection);
}

static void ListCategories(SqlConnection connection)
{
    var categories = connection.Query<Category>("SELECT[Id], [Title] FROM [Category]");

    foreach (var item in categories)
    {
        System.Console.WriteLine($"{item.Id} - {item.Title}");
    }
};

static void CreateCategory(SqlConnection connection)
{

    var category = new Category();
    category.Id = Guid.NewGuid();
    category.Title = "Amazon AWS";
    category.Url = "amazon";
    category.Summary = "AWS Summary";
    category.Order = 8;
    category.Description = "Categoria destinada a serviços AWS";
    category.Featured = false;

    var insertSql = @"INSERT INTO [Category] 
VALUES(
    @Id, 
    @Title, 
    @Url, 
    @Summary, 
    @Order, 
    @Description, 
    @Featured)";

    var rows = connection.Execute(insertSql, new
    {
        category.Id,
        category.Title,
        category.Url,
        category.Summary,
        category.Order,
        category.Description,
        category.Featured
    });
    System.Console.WriteLine($"{rows} linhas afetadas");
}

static void UpdateCategory(SqlConnection connection)
{
    var updateQuery = "UPDATE [Category] SET [Title] = @title WHERE [Id] = @id";
    var rows = connection.Execute(updateQuery, new
    {
        id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
        title = "Frontend 2021"
    });
    System.Console.WriteLine($"{rows} registros atualizados");
};

static void CreateManyCategory(SqlConnection connection)
{

    var category = new Category();
    category.Id = Guid.NewGuid();
    category.Title = "Amazon AWS";
    category.Url = "amazon";
    category.Summary = "AWS Summary";
    category.Order = 8;
    category.Description = "Categoria destinada a serviços AWS";
    category.Featured = false;

    var category2 = new Category();
    category2.Id = Guid.NewGuid();
    category2.Title = "Categoria nova";
    category2.Url = "categoria-nova";
    category2.Summary = "categoria";
    category2.Order = 9;
    category2.Description = "Categoria novinha";
    category2.Featured = true;

    var insertSql = @"INSERT INTO [Category] 
VALUES(
    @Id, 
    @Title, 
    @Url, 
    @Summary, 
    @Order, 
    @Description, 
    @Featured)";

    var rows = connection.Execute(insertSql, new[]{
        new
    {
        category.Id,
        category.Title,
        category.Url,
        category.Summary,
        category.Order,
        category.Description,
        category.Featured
    }, new
    {
        category2.Id,
        category2.Title,
        category2.Url,
        category2.Summary,
        category2.Order,
        category2.Description,
        category2.Featured
    }});
}

static void DeleteCategory(SqlConnection connection)
{

    var deleteQuery = "DELETE[Category] WHERE [Id] = @id";

    var rows = connection.Execute(deleteQuery, new
    {
        id = new Guid("c19f78d9-1413-4cd1-a70d-a5604a915ac8")
    });

    Console.WriteLine($"{rows} registros excluídos");
}

static void ExecuteProcedure(SqlConnection connection)
{
    var procedure = "spDeleteStudent";
    var pars = new { StudentId = "55252192-c0ee-4868-9219-29da2d2e979d" };
    var effectedRows = connection.Execute(procedure, pars, commandType: CommandType.StoredProcedure);

    Console.WriteLine($"{effectedRows} linhas afetadas");
}

static void ExecuteReadProcedure(SqlConnection connection)
{
    var procedure = "spGetCoursesByCategory";
    var pars = new { CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142" };
    var courses = connection.Query<Category>(procedure, pars, commandType: CommandType.StoredProcedure);

    foreach (var course in courses)
    {
        Console.WriteLine(course.Title);
    }
}

static void ReadView(SqlConnection connection)
{
    var sql = "SELECT * FROM [vwCourses]";
    var courses = connection.Query(sql);
    foreach (var course in courses)
    {
        Console.WriteLine($"{course.Id} - {course.Title}");
    }
}

static void OneToOne(SqlConnection connection)
{
    var sql = @"
    SELECT *
    FROM [CareerItem]
    INNER JOIN [Course]
    ON [CareerItem].[CourseId] = [Course].[Id]";

    var items = connection.Query<CareerItem, Course, CareerItem>(sql, (careerItem, course) =>
    {
        careerItem.Course = course;
        return careerItem;
    }, splitOn: "Id");
    foreach (var item in items)
    {
        Console.WriteLine($"{item.Title} - Curso: {item.Course.Title}");
    }
}

static void OneToMany(SqlConnection connection)
{
    var sql = @"
    SELECT
    [Career].[Id],
    [Career].[Title],
    [CareerItem].[CareerId],
    [CareerItem].[Title]
FROM
    [Career]
INNER JOIN
    [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
ORDER BY
    [Career].[Title]";

    var careers = new List<Career>();

    var items = connection.Query<Career, CareerItem, Career>(sql, (career, careeritem) =>
    {
        var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();

        if (car == null)
        {
            car = career;
            car.Items.Add(careeritem);
            careers.Add(car);
        }
        else
        {
            car.Items.Add(careeritem);
        }

        career.Items.Add(careeritem);
        return career;
    }, splitOn: "CareerId");
    foreach (var career in careers)
    {
        Console.WriteLine($"{career.Title}");
        foreach (var item in career.Items)
        {
            Console.WriteLine($" - {item.Title}");
        }
    }
}

static void QueryMultiple(SqlConnection connection)
{

    var query = "SELECT * FROM[Category]; SELECT * FROM [Course]";

    using (var multi = connection.QueryMultiple(query))
    {
        var categories = multi.Read<Category>();
        var courses = multi.Read<Course>();

        foreach (var category in categories)
        {
            System.Console.WriteLine(category.Title);
        }
        System.Console.WriteLine("----------------------------------------");
        foreach (var course in courses)
        {
            System.Console.WriteLine(course.Title);
        }
    }
}

static void SelectIn(SqlConnection connection)
{
    var query = @"
    SELECT * FROM[Career] WHERE[Id] IN @Id";

    var items = connection.Query<Career>(query, new
    {
        Id = new[]{
    "4327ac7e-963b-4893-9f31-9a3b28a4e72b",
    "e6730d1c-6870-4df3-ae68-438624e04c72"
}
    });

    foreach (var item in items)
    {
        System.Console.WriteLine(item.Title);
    }
}

static void Like(SqlConnection connection, string term)
{

    var query = "SELECT * FROM [Course] WHERE [Title] LIKE @exp";

    var items = connection.Query<Course>(query, new
    {
        exp = $"%{term}%"
    });
    foreach (var item in items)
    {
        System.Console.WriteLine(item.Title);
    }
}

static void Transaction(SqlConnection connection)
{

    var category = new Category();
    category.Id = Guid.NewGuid();
    category.Title = "Category not";
    category.Url = "amazon";
    category.Summary = "AWS Summary";
    category.Order = 8;
    category.Description = "Categoria destinada a serviços AWS";
    category.Featured = false;

    var insertSql = @"
    INSERT INTO 
        [Category] 
    VALUES(
        @Id, 
        @Title, 
        @Url, 
        @Summary, 
        @Order, 
        @Description, 
        @Featured)";

    connection.Open();
    using (var transaction = connection.BeginTransaction())
    {
        var rows = connection.Execute(insertSql, new
        {
            category.Id,
            category.Title,
            category.Url,
            category.Summary,
            category.Order,
            category.Description,
            category.Featured
        }, transaction);

        transaction.Rollback();
        // transaction.Commit();

        Console.WriteLine($"{rows} linhas afetadas");
    }
}