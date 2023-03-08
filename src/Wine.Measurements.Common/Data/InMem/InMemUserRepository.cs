using Wine.Measurements.Common.Extesions;
using Wine.Measurements.Common.Models;

namespace Wine.Measurements.Common.Data.InMem;

public class InMemUserRepository : IUserRepository
{
    private readonly List<User> _users;

    private readonly static object _syncObj = new object();

    public InMemUserRepository()
    {
        _users = new List<User>();
    }

    public IEnumerable<User> GetRegisteredUsers()
    {
        return _users;
    }

    public User? GetUser(string username, string passwordHash)
    {
        this.ValidateLoginData(username, passwordHash);

        return _users.SingleOrDefault(u => u.UserName == username && u.PasswordHash == passwordHash);
    }

    public void RegisterUser(User user)
    {
        this.ValidateUser(user);

        lock (_syncObj)
        {
            if (_users.SingleOrDefault(u => u.UserName == user.UserName) != null)
                throw new ArgumentException("El usuario ya existe");

            _users.Add(user);
        }
    }
}
