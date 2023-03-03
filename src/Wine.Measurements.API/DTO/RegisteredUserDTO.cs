namespace Wine.Measurements.API.DTO;

public class RegisteredUserDTO
{
    public Guid UserId { get; init; }
    public string UserName { get; init; }
    public string FullName { get; init; }
}
