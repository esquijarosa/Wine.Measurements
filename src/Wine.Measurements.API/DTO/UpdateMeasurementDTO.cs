using System.ComponentModel.DataAnnotations;

namespace Wine.Measurements.API.DTO;

public class UpdateMeasurementDTO : AddMeasurementDTO
{
    [Required]
    public int? Id { get; init; }
}
