using Dapper.Contrib.Extensions;

namespace DataAccess.Models
{
    [Table("[Author]")]
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}