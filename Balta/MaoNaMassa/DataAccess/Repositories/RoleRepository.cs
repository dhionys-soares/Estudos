using Microsoft.Data.SqlClient;
using DataAccess.Models;
using Dapper.Contrib.Extensions;

namespace DataAccess.Repositories
{
    public class RoleRepository
    {
        private readonly SqlConnection _connection;

        public RoleRepository(SqlConnection connection)
        
           => _connection = connection;
        
        
    }
}