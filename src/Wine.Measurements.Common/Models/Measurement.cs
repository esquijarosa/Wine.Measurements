namespace Wine.Measurements.Common.Models;

public class Measurement
{
    public int Id { get; set; }
    public int Year { get; set; }
    public int VarietyId { get; set; }
    public string? Variety { get; set; }
    public int TypeId { get; set; }
    public string? Type { get; set; }
    public string Color { get; set; }
    public float Temperature { get; set; }
    public float Graduation { get; set; }
    public float PH { get; set; }
    public string Observations { get; set; }
    public string RecordedBy { get; set; }
    public DateTimeOffset RecordedAt { get; set; } = DateTimeOffset.UtcNow;
}
