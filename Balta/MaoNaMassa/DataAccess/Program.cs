using Dapper.Contrib.Extensions;
using DataAccess.Models;
using Microsoft.Data.SqlClient;
using DataAccess.Repositories;
using DataAccess.Screens.TagScreens;
using DataAccess;

const string connectionString = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=Synoihd10@;Trusted_Connection=False; TrustServerCertificate=True;";

Database.Connection = new SqlConnection(connectionString);
Database.Connection.Open();
// // Load();
// VincularUsuarioComPerfil(Database.Connection);
// ReadUsersWithRoles(Database.Connection);
// Console.ReadKey();
ReadUsersWithRoles(Database.Connection);
Database.Connection.Close();

// ReadUsers(connection);
// VincularUsuarioComPerfil(connection);
// CreateCategory(connection);
// CreateTag(connection);
// CreatePost(connection);
// CreateAuthor(connection);
// CreateRole(connection);

// ReadRoles(connection);
// ReadTags(connection);
// ReadRole(connection);
// ReadUser(connection);
// CreateUser(connection);
// UpdateUser(connection);
// DeleteUser();

static void CreateUser(SqlConnection connection)
{
    var repository = new Repository<User>(connection);
    var user = new User()
    {
        Bio = "Dhionys",
        Email = "dhionys@balta.io",
        Image = "https://...",
        Name = "dhionys",
        Slug = "dhionys",
        PasswordHash = "dhionys"
    };
    repository.Create(user);
    Console.WriteLine("Cadastro realizado com sucesso");
}

static void ReadUsers(SqlConnection connection)
{
    var repository = new Repository<User>(connection);
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item.Name);

        foreach (var role in item.Roles)
        {
            Console.WriteLine($" - {role.Name}");
        }
    }
}

static void ReadRoles(SqlConnection connection)
{
    var repository = new Repository<Role>(connection);
    var roles = repository.GetAll();
    foreach (var role in roles)
    {
        Console.WriteLine(role.Name);
    }
}

static void ReadTags(SqlConnection connection)
{
    var repository = new Repository<Tag>(connection);
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item.Name);
    }
}

static void ReadUser(SqlConnection connection)
{
    var repository = new Repository<User>(connection);
    var user = repository.Get(5);
    Console.WriteLine(user.Name);
}

static void UpdateUser(SqlConnection connection)
{
    var repository = new UserRepository(connection);
    var user = repository.Get(5);
    user.Name = "Gabrielle";
    repository.Update(user);
    System.Console.WriteLine("Cadastro atualizado com sucesso");
}

static void DeleteUser()
{

    using (var connection = new SqlConnection(connectionString))
    {
        var user = connection.Get<User>(4);
        var delete = connection.Delete<User>(user);
        Console.WriteLine("Cadastro excluído com sucesso");
    }
}

static void ReadRole(SqlConnection connection)
{
    var repository = new Repository<Role>(connection);
    var role = repository.Get(1);
    Console.WriteLine(role.Name);
}

static void ReadUsersWithRoles(SqlConnection connection)
{
    var repository = new UserRepository(connection);
    var items = repository.GetWithRoles();

    foreach (var item in items)
    {
        Console.WriteLine($" + {item.Name}");

        foreach (var role in item.Roles)
        {
            Console.WriteLine($" - {role.Name}");
        }
    }
}

static void CreateRole(SqlConnection connection)
{
    var role = new Role()
    {
        Name = "Administrador",
        Slug = "adm"
    };

    var repository = new Repository<Role>(connection);
    repository.Create(role);
    Console.WriteLine("Role cadastrada com sucesso");
}

static void VincularUsuarioComPerfil(SqlConnection connection)
{
    var buscaRole = new Repository<Role>(connection);
    var role = buscaRole.Get(2);

    var buscaUser = new Repository<User>(connection);
    var user = buscaUser.Get(2);

    var repository = new UserRepository(connection);
    repository.VincularUserToRole(user, role, connection);
}

static void CreateCategory(SqlConnection connection){
    var category = new Category(){
 Name = "CategoryTest",
 Slug = "categoryteste"
    };
    var repository = new Repository<Category>(connection);
    repository.Create(category);
    Console.WriteLine("Category cadastrada com sucesso");
}

static void CreateTag(SqlConnection connection){
    var tag = new Tag(){
        Name = "TagTest",
        Slug = "tagtest"
    };
    var repository = new Repository<Tag>(connection);
    repository.Create(tag);
    Console.WriteLine("Tag cadastrada com sucesso");
}

static void CreatePost(SqlConnection connection){
var post = new Post(){    
    CategoryId = 1,
    AuthorId = 1,
    Title = "PostTest",
    Summary = "PostTest",
    Body = "PostTest",
    Slug = "posttest",
    CreateDate = DateTime.Now,
    LastUpdateDate = DateTime.Now
};
var repository = new Repository<Post>(connection);
repository.Create(post);
Console.WriteLine("Post cadastrado com sucesso");
}

static void CreateAuthor(SqlConnection connection){
    var author = new Author(){
 Name = "AuthorTest",
 Slug = "authortest"
    };
    var repository = new Repository<Author>(connection);
    repository.Create(author);
    Console.WriteLine("Author cadastrada com sucesso");
}

static void Load(){
    Console.Clear();
    Console.WriteLine("Meu Blog");
    Console.WriteLine("-----------------------");
    Console.WriteLine("O que deseja fazer?");
    Console.WriteLine();
    Console.WriteLine("1 - Gestão de usuário");
    Console.WriteLine("2 - Gestão de perfil");
    Console.WriteLine("3 - Gestão de categoria");
    Console.WriteLine("4 - Gestão de tag");
    Console.WriteLine("5 - Vincular perfil/usuário");
    Console.WriteLine("6 - Vincular post/tag");
    Console.WriteLine("Relatórios");
    Console.WriteLine();
    Console.WriteLine();
    var option = short.Parse(Console.ReadLine()!);

    switch (option)
    {
        case 4: MenuTagScreen.Load();
        break;
        
        default: Load();
        break;
    }
};
