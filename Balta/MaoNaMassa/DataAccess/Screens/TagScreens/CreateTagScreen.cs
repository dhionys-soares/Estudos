using DataAccess.Models;
using DataAccess.Repositories;

namespace DataAccess.Screens.TagScreens
{
    public static class CreateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Nova tags");
            Console.WriteLine("--------------------");

            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Create(new Tag
            {
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        private static void Create(Tag tag)
        {            
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
            repository.Create(tag);
            System.Console.WriteLine("Tag criada com sucesso");
            }
            catch (Exception e)
            {
             Console.WriteLine("Não foi possível salvar a tag");
             Console.WriteLine(e.Message);
            }
        }
    }
}