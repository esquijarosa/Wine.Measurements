using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System.Globalization;
using Wine.Measurements.Common.Models;

namespace Wine.Measurements.Common.Utilities;

public static class CSVGenerator
{
    private class CSVRecord
    {
        public CSVRecord(Measurement measurement)
        {
            Year = measurement.Year;
            Variety = measurement.Variety;
            Type = measurement.Type;
            Color = measurement.Color;
            Temperature = measurement.Temperature;
            Graduation = measurement.Graduation;
            PH = measurement.PH;
            Observations = measurement.Observations;
            RecordedBy = measurement.RecordedBy;
            RecordedAt = measurement.RecordedAt;
        }

        [Name("Año")]
        public int Year { get; set; }
        [Name("Variedad")]
        public string Variety { get; set; }
        [Name("Tipo")]
        public string Type { get; set; }
        [Name("Color")]
        public string Color { get; set; }
        [Name("Temperatura")]
        public float Temperature { get; set; }
        [Name("Graduación")]
        public float Graduation { get; set; }
        [Name("PH")]
        public float PH { get; set; }
        [Name("Observaciones")]
        public string? Observations { get; set; }
        [Name("Registrado por")]
        public string RecordedBy { get; set; }
        [Name("Registrado en")]
        public DateTimeOffset RecordedAt { get; set; }
    }

    private static byte[] GenerateCSVStream(IEnumerable<object> records)
    {
        using var stream = new MemoryStream();
        using var writeFile = new StreamWriter(stream, leaveOpen: true);
        using var csv = new CsvWriter(writeFile, CultureInfo.InvariantCulture, true);
        csv.WriteRecords(records);
        writeFile.Flush();

        var data = stream.ToArray();

        return data;
    }

    public static byte[] GenerateMeasurementsCSV(IEnumerable<Measurement> measurements)
    {
        var records = measurements.Select(m => new CSVRecord(m));

        return GenerateCSVStream(records);
    }
}
