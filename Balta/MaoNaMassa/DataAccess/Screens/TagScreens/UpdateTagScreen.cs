using DataAccess.Models;
using DataAccess.Repositories;

namespace DataAccess.Screens.TagScreens
{
    public static class UpdateTagTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar tag");
            Console.WriteLine("--------------------");

            Console.Write("Id: ");
            var id = Console.ReadLine();
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Update(new Tag
            {
                Id = int.Parse(id),
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        private static void Update(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Update(tag);
                Console.WriteLine("Tag atualizada com sucesso");
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível atualizar a tag");
                Console.WriteLine(e.Message);
            }
        }
    }
}