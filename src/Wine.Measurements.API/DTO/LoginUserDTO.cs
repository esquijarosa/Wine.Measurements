using System.ComponentModel.DataAnnotations;

namespace Wine.Measurements.API.DTO;

public class LoginUserDTO
{
    [Required]
    [MaxLength(100)]
    public string UserName { get; init; }
    [Required]
    [MaxLength(250)]
    public string PasswordHash { get; init; }
}
