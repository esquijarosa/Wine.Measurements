using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Wine.Measurements.API.DTO;
using Wine.Measurements.Common.Data;
using Wine.Measurements.Common.Models;
using Wine.Measurements.Common.Utilities;

namespace Wine.Measurements.API.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class MeasurementsController : ControllerBase
{
    private readonly IMeasurementsRepository _repository;
    private readonly IMapper _mapper;

    public MeasurementsController(IMeasurementsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<MeasurementDTO>> GetMeasurements([FromQuery] string? user)
    {
        IEnumerable<Measurement> list;

        if (string.IsNullOrEmpty(user))
        {
            list = _repository.GetAllMeasurements();
        }
        else
        {
            list = _repository.GetMeasurementsByUser(user);
        }

        return Ok(_mapper.Map<IEnumerable<MeasurementDTO>>(list));
    }

    [HttpGet("{id}", Name = "GetMeasurement")]
    public ActionResult<MeasurementDTO> GetMeasurement(int id)
    {
        var measurment = _repository.GetMeasurement(id);

        if(measurment == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<MeasurementDTO>(measurment));
    }

    [HttpPost]
    public ActionResult AddMeasurement([FromBody] AddMeasurementDTO measurement)
    {
        var userName = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email, StringComparison.OrdinalIgnoreCase))?.Value;

        var newMeasurement = _mapper.Map<Measurement>(measurement);
        newMeasurement.RecordedAt = DateTimeOffset.UtcNow;
        newMeasurement.RecordedBy = userName ?? "system";

        var id = _repository.AddMeasurement(newMeasurement);
        newMeasurement.Id = id;

        return CreatedAtAction(nameof(GetMeasurement), new { id }, newMeasurement);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateMeasurement(int id, [FromBody] UpdateMeasurementDTO measurement)
    {
        if (id != measurement.Id)
        {
            return BadRequest();
        }

        if (_repository.GetMeasurement(id) == null)
        {
            return NotFound();
        }

        var userName = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email, StringComparison.OrdinalIgnoreCase))?.Value;

        var updateMeasurement = _mapper.Map<Measurement>(measurement);
        updateMeasurement.RecordedAt = DateTimeOffset.UtcNow;
        updateMeasurement.RecordedBy = userName ?? "system";

        _repository.UpdateMeasurement(updateMeasurement);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteMeasurement(int id)
    {
        if (!_repository.DeleteMeasurement(id))
            return NotFound();

        return NoContent();
    }

    [HttpGet("catalogs/varieties")]
    public ActionResult<IEnumerable<CatalogItemDTO>> GetVarietiesCatalog()
    {
        return Ok(_mapper.Map<IEnumerable<CatalogItemDTO>>(_repository.GetWineVarieties()));
    }

    [HttpGet("catalogs/types")]
    public ActionResult<IEnumerable<CatalogItemDTO>> GetTypesCatalog()
    {
        return Ok(_mapper.Map<IEnumerable<CatalogItemDTO>>(_repository.GetWineTypes()));
    }

    [HttpGet("csv")]
    public ActionResult GetCSVExport()
    {
        var csvData = CSVGenerator.GenerateMeasurementsCSV(_repository.GetAllMeasurements());
        return File(csvData, "application/octet-stream", "measurements.csv");
    }
}
