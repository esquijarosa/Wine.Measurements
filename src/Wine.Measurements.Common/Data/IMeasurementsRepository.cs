using Wine.Measurements.Common.Models;

namespace Wine.Measurements.Common.Data;

public interface IMeasurementsRepository
{
    IEnumerable<Measurement> GetAllMeasurements();
    IEnumerable<Measurement> GetMeasurementsByUser(string userName);
    Measurement? GetMeasurement(int id);
    int AddMeasurement(Measurement measurement);
    void UpdateMeasurement(Measurement measurement);
    bool DeleteMeasurement(int id);
    IEnumerable<CatalogItem> GetWineVarieties();
    IEnumerable<CatalogItem> GetWineTypes();
}
