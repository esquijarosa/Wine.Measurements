using System.ComponentModel.DataAnnotations;

namespace Wine.Measurements.API.DTO;

public class RegisterUserDTO
{
    [Required]
    public string UserId { get; init; }
    [Required]
    [MaxLength(100)]
    public string UserName { get; init; }
    [Required]
    [MaxLength(250)]
    public string PasswordHash { get; init; }
    [Required]
    [MaxLength(100)]
    public string FullName { get; init; }
}
