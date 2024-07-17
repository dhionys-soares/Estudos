using System.Reflection.Metadata;
using Dapper;
using Dapper.Contrib.Extensions;
using DataAccess.Models;
using Microsoft.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection) : base(connection)

          => _connection = connection;

        public List<User> GetWithRoles()
        {
            var query = @"SELECT
    [User].*,
    [Role].*
FROM
    [User]
LEFT JOIN
    [UserRole] ON [UserRole].[UserId] = [User].[Id]
LEFT JOIN
    [Role] ON [Role].[Id] = [UserRole].[RoleId]";

            var users = new List<User>();

            var busca = _connection.Query<User, Role, User>(query, (user, role) =>
            {
                var usr = users.FirstOrDefault(x => x.Id == user.Id);

                if (usr == null)
                {
                    usr = user;

                    if (role != null)
                    {
                        usr.Roles.Add(role);
                    }

                    users.Add(usr);
                }
                else
                {
                    usr.Roles.Add(role);
                }
                return user;
            }, splitOn: "Id");

            return users;
        }

        public void VincularUserToRole(User user, Role role, SqlConnection connection)
        {
            var userrole = new UserRole()
            {
                UserId = user.Id,
                RoleId = role.Id
            };
            var insertSql = @"INSERT INTO [UserRole] VALUES(@UserId, @RoleId)";

            using (var transaction = connection.BeginTransaction())
            {
                var rows = connection.Execute(insertSql, new
                {
                    userrole.UserId,
                    userrole.RoleId
                }, transaction);

                // transaction.Rollback();
                transaction.Commit();
            }


        }
    }
}

