using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Wine.Measurements.Common.Models;
using Wine.Measurements.Common.Extesions;

namespace Wine.Measurements.Common.Data.SqlData;

public class SqlUserRepository : IUserRepository
{
    private readonly string _connectionId;
    private readonly IConfiguration _configuration;

    public SqlUserRepository(IConfiguration configuration)
    {
        _connectionId = "Default";
        _configuration = configuration;
    }
    public IEnumerable<User> GetRegisteredUsers()
    {
        using IDbConnection conn = new SqlConnection(_configuration.GetConnectionString(_connectionId));
        return conn.Query<User>(
            "[dbo].[sp_get_all_users]",
            commandType: CommandType.StoredProcedure);
    }

    public User? GetUser(string username, string passwordHash)
    {
        this.ValidateLoginData(username, passwordHash);

        using IDbConnection conn = new SqlConnection(_configuration.GetConnectionString(_connectionId));
        return conn.QueryFirstOrDefault<User>(
            "[dbo].[sp_get_user]",
            new { UserName = username, PasswordHash = passwordHash },
            commandType: CommandType.StoredProcedure);
    }

    public void RegisterUser(User user)
    {
        this.ValidateUser(user);

        using IDbConnection conn = new SqlConnection(_configuration.GetConnectionString(_connectionId));

        try
        {
            conn.Execute(
                "[dbo].[sp_register_user]",
                new { user.UserId, user.FullName, user.UserName, user.PasswordHash },
                commandType: CommandType.StoredProcedure);
        }
        catch (SqlException ex)
        {
            throw new ArgumentException("El usuario ya existe");
        }
    }
}
