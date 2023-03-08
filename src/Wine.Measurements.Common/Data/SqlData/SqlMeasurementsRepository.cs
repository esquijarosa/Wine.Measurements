using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Wine.Measurements.Common.Models;
using Dapper;
using Wine.Measurements.Common.Extesions;

namespace Wine.Measurements.Common.Data.SqlData;

public class SqlMeasurementsRepository : IMeasurementsRepository
{
    private readonly string _connectionId;
    private readonly IConfiguration _configuration;

    public SqlMeasurementsRepository(IConfiguration configuration)
    {
        _connectionId = configuration["ConnectionId"];
        _configuration = configuration;
    }
    public int AddMeasurement(Measurement measurement)
    {
        this.ValidateMeasurement(measurement);

        using IDbConnection conn = new SqlConnection(_configuration.GetConnectionString(_connectionId));
        return conn.ExecuteScalar<int>(
            "[dbo].[sp_add_measurement]",
            new
            {
                measurement.Year,
                measurement.VarietyId,
                measurement.TypeId,
                measurement.Color,
                measurement.Graduation,
                measurement.Temperature,
                measurement.PH,
                measurement.Observations,
                measurement.RecordedAt,
                measurement.RecordedBy
            },
            commandType: CommandType.StoredProcedure);
    }

    public bool DeleteMeasurement(int id)
    {
        using IDbConnection conn = new SqlConnection(_configuration.GetConnectionString(_connectionId));
        return conn.Execute("[dbo].[sp_delete_measurement]", new { Id = id }, commandType: CommandType.StoredProcedure) > 0;
    }

    public IEnumerable<Measurement> GetAllMeasurements()
    {
        using IDbConnection conn = new SqlConnection(_configuration.GetConnectionString(_connectionId));
        return conn.Query<Measurement>("[dbo].[sp_get_all_measurements]", commandType: CommandType.StoredProcedure);
    }

    public Measurement? GetMeasurement(int id)
    {
        using IDbConnection conn = new SqlConnection(_configuration.GetConnectionString(_connectionId));
        return conn.QueryFirstOrDefault<Measurement>("[dbo].[sp_get_measurement]", new { id }, commandType: CommandType.StoredProcedure);
    }

    public IEnumerable<Measurement> GetMeasurementsByUser(string userName)
    {
        using IDbConnection conn = new SqlConnection(_configuration.GetConnectionString(_connectionId));
        return conn.Query<Measurement>("[dbo].[sp_get_measurements_by_user]", new { userName }, commandType: CommandType.StoredProcedure);
    }

    public IEnumerable<CatalogItem> GetWineTypes()
    {
        using IDbConnection conn = new SqlConnection(_configuration.GetConnectionString(_connectionId));
        return conn.Query<CatalogItem>("[dbo].[sp_get_wine_types]", commandType: CommandType.StoredProcedure);
    }

    public IEnumerable<CatalogItem> GetWineVarieties()
    {
        using IDbConnection conn = new SqlConnection(_configuration.GetConnectionString(_connectionId));
        return conn.Query<CatalogItem>("[dbo].[sp_get_wine_varieties]", commandType: CommandType.StoredProcedure);
    }

    public void UpdateMeasurement(Measurement measurement)
    {
        this.ValidateMeasurement(measurement);

        using IDbConnection conn = new SqlConnection(_configuration.GetConnectionString(_connectionId));
        conn.Execute("[dbo].[sp_update_measurement]",
            new
            {
                measurement.Id,
                measurement.Year,
                measurement.VarietyId,
                measurement.TypeId,
                measurement.Color,
                measurement.Graduation,
                measurement.Temperature,
                measurement.PH,
                measurement.Observations,
                measurement.RecordedAt,
                measurement.RecordedBy
            }, commandType: CommandType.StoredProcedure);
    }
}
