namespace Wine.Measurements.API.DTO;

public class MeasurementDTO
{
    public int Id { get; init; }
    public int Year { get; init; }
    public string Variety { get; init; }
    public string Type { get; init; }
    public string Color { get; init; }
    public float Temperature { get; init; }
    public float Graduation { get; init; }
    public float PH { get; init; }
    public string? Observations { get; init; }
    public string RecordedBy { get; init; }
    public DateTimeOffset RecordedAt { get; init; }

}
