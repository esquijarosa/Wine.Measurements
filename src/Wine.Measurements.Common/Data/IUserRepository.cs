using Wine.Measurements.Common.Models;

namespace Wine.Measurements.Common.Data;

public interface IUserRepository
{
    IEnumerable<User> GetRegisteredUsers();
    User? GetUser(string username, string passwordHash);
    void RegisterUser(User user);
}
