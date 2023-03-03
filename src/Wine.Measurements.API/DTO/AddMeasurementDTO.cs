using System.ComponentModel.DataAnnotations;

namespace Wine.Measurements.API.DTO;

public class AddMeasurementDTO
{
    [Required]
    public int Year { get; init; }
    [Required]
    public int VarietyId { get; init; }
    [Required]
    public int TypeId { get; init; }
    [Required]
    [MaxLength(50)]
    public string Color { get; init; }
    [Required]
    public float Temperature { get; init; }
    [Required]
    public float Graduation { get; init; }
    [Required]
    public float PH { get; init; }
    [MaxLength(250)]
    public string? Observations { get; init; }
}
