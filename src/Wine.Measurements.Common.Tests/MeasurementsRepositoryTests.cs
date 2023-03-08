using Wine.Measurements.Common.Data;
using Wine.Measurements.Common.Data.InMem;
using Wine.Measurements.Common.Models;

namespace Wine.Measurements.Common.Tests;

public class MeasurementsRepositoryTests
{
    [Theory]
    [InlineData(0, 1, 1, "Rojo intenso", 0.15f, 6.5f, "system")]
    [InlineData(2017, 0, 1, "Rojo intenso", 0.15f, 6.5f, "system")]
    [InlineData(2017, 1, 0, "Rojo intenso", 0.15f, 6.5f, "system")]
    [InlineData(2017, 1, 1, "", 0.15f, 6.5f, "system")]
    [InlineData(2017, 1, 1, "Rojo intenso", -1.0f, 6.5f, "system")]
    [InlineData(2017, 1, 1, "Rojo intenso", 0.15f, 0.0f, "system")]
    [InlineData(2017, 1, 1, "Rojo intenso", 0.15f, 6.5f, "")]
    [InlineData(2017, 1, 1, null, 0.15f, 6.5f, "system")]
    [InlineData(2017, 1, 1, "Rojo intenso", 0.15f, 6.5f, null)]
    [InlineData(2017, 1, 1, "   ", 0.15f, 6.5f, "system")]
    [InlineData(2017, 1, 1, "Rojo intenso", 0.15f, 6.5f, "   ")]
    public void AddMeasurement_InvalidDataShouldFail(int year,
                                                     int varietyId,
                                                     int typeId,
                                                     string color,
                                                     float graduation,
                                                     float ph,
                                                     string recordeBy)
    {
        // Arrange
        IMeasurementsRepository repository = new InMemMeasurementsRepository();
        var measurement = new Measurement
        {
            Year = year,
            VarietyId = varietyId,
            TypeId = typeId,
            Color = color,
            Graduation = graduation,
            PH = ph,
            RecordedBy = recordeBy
        };

        // Act
        Assert.Throws<ArgumentException>(() => repository.AddMeasurement(measurement));
    }

    [Fact]
    public void AddMeasurement_NewMeasurementShouldGetId()
    {
        // Arrange
        IMeasurementsRepository repository = new InMemMeasurementsRepository();
        var measurement = new Measurement
        {
            Year = 2017,
            VarietyId = 1,
            TypeId = 1,
            Color = "Rojo intenso",
            Graduation = 0.15f,
            PH = 6.5f,
            RecordedBy = "system"
        };

        // Act
        int actual = repository.AddMeasurement(measurement);

        // Assert
        Assert.True(actual > 0);
    }

    [Fact]
    public void UpdateMeasurement_InexistentIdShouldWork()
    {
        // Arrange
        IMeasurementsRepository repository = new InMemMeasurementsRepository();
        var measurement = new Measurement
        {
            Year = 2017,
            VarietyId = 1,
            TypeId = 1,
            Color = "Rojo intenso",
            Graduation = 0.15f,
            PH = 6.5f,
            RecordedBy = "system"
        };

        // Act
        repository.UpdateMeasurement(measurement);
    }

    [Fact]
    public void GetMeasurements_ShouldGetAList()
    {
        // Arrange
        IMeasurementsRepository repository = new InMemMeasurementsRepository();

        // Act
        var actual = repository.GetAllMeasurements();

        // Assert
        Assert.NotNull(actual);
    }
}
