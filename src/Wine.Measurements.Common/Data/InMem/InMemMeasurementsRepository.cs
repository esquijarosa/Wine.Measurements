using Wine.Measurements.Common.Models;

namespace Wine.Measurements.Common.Data.InMem;

public class InMemMeasurementsRepository : IMeasurementsRepository
{
    private readonly List<CatalogItem> _wineVarieties = new List<CatalogItem>
    {
        new CatalogItem{ Id = 1, Value = "Cabernet" },
        new CatalogItem{ Id = 2, Value = "Shiraz" },
        new CatalogItem{ Id = 3, Value = "Tempranillo" }
    };

    private readonly List<CatalogItem> _wineTypes = new List<CatalogItem>
    {
        new CatalogItem(){ Id = 1, Value = "Tinto" },
        new CatalogItem(){ Id = 2, Value = "Rosado" },
        new CatalogItem(){ Id = 3, Value = "Blanco" }
    };

    private readonly Dictionary<int, Measurement> _measurements;

    private static int _nextMeasurementId = 1;
    private static readonly object _syncObj = new object();

    public InMemMeasurementsRepository()
    {
        _measurements = new Dictionary<int, Measurement>();
    }

    private static int GetMeasurementNextId()
    {
        lock (_syncObj)
        {
            int id = _nextMeasurementId;
            _nextMeasurementId += 1;
            return id;
        }
    }

    public int AddMeasurement(Measurement measurement)
    {
        measurement.Id = GetMeasurementNextId();
        _measurements.Add(measurement.Id, measurement);
        return measurement.Id;
    }

    public void UpdateMeasurement(Measurement measurement)
    {
        _measurements[measurement.Id] = measurement;
    }

    public bool DeleteMeasurement(int id)
    {
        return _measurements.Remove(id);
    }

    public IEnumerable<Measurement> GetAllMeasurements()
    {
        return _measurements.Values.OrderByDescending(m => m.RecordedAt);
    }

    public Measurement? GetMeasurement(int id)
    {
        try
        {
            return _measurements[id];
        }
        catch
        {
            return null;
        }
    }

    public IEnumerable<Measurement> GetMeasurementsByUser(string userName)
    {
        return _measurements.Values.Where(m => m.RecordedBy == userName);
    }

    public IEnumerable<CatalogItem> GetWineTypes()
    {
        return _wineTypes;
    }

    public IEnumerable<CatalogItem> GetWineVarieties()
    {
        return _wineVarieties;
    }
}
