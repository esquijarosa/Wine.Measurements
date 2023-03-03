namespace Wine.Measurements.Common.Models;

public class User
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public string FullName { get; set; }
}
