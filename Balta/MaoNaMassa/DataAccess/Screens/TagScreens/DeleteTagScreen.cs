using DataAccess.Models;
using DataAccess.Repositories;

namespace DataAccess.Screens.TagScreens
{
    public static class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Deletar tag");
            Console.WriteLine("--------------------");

            Console.Write("Id: ");
            var id = int.Parse(Console.ReadLine());           

            Delete(id);
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        private static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Tag deletada com sucesso");
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível deletar a tag");
                Console.WriteLine(e.Message);
            }
        }
}}