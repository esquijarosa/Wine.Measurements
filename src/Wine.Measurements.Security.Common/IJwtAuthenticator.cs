namespace Wine.Measurements.Security.Common;

public interface IJwtAuthenticator
{
    public string? Authorize(string userName, string passwordHash);
}
