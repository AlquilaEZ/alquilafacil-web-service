using System.Net.Mime;
using AlquilaFacilPlatform.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using AlquilaFacilPlatform.Management.Domain.Model.Queries;
using AlquilaFacilPlatform.Management.Domain.Services;
using AlquilaFacilPlatform.Management.Interfaces.REST.Resources;
using AlquilaFacilPlatform.Management.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace AlquilaFacilPlatform.Management.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SensorsController(ISensorQueryService sensorQueryService, ISensorCommandService sensorCommandService): ControllerBase
{
     [HttpPost]
     public async Task<IActionResult> CreateSensor([FromBody] CreateSensorResource resource)
     {
         var createSensorCommand = CreateSensorCommandFromResourceAssembler.ToCommandFromResource(resource);
         var sensor = await sensorCommandService.Handle(createSensorCommand);
         if (sensor is null) return BadRequest();
         var sensorResource = SensorResourceFromEntityAssembler.ToResourceFromEntity(sensor);
         return StatusCode(201, sensorResource);
     }

     [HttpPost("readings")]
     [AllowAnonymous]
     public async Task<IActionResult> CreateReading([FromBody] CreateReadingResource resource)
     {
         var createReadingCommand = CreateReadingCommandFromResourceAssembler.ToCommandFromResource(resource);
         var reading = await sensorCommandService.Handle(createReadingCommand);
         if (reading is null) return BadRequest();
         var readingResource = ReadingResourceFromEntityAssembler.ToResourceFromEntity(reading);
         return StatusCode(201, readingResource);
     }

     [HttpPut]
     public async Task<IActionResult> UpdateSensor([FromBody] UpdateSensorResource resource)
     {
         var updateReadingCommand = UpdateSensorCommandFromResourceAssembler.ToCommandFromResource(resource);
         var sensor = await sensorCommandService.Handle(updateReadingCommand);
         if (sensor is null) return BadRequest();
         var sensorResource = SensorResourceFromEntityAssembler.ToResourceFromEntity(sensor);
         return Ok(sensorResource);
     }
     
     [HttpGet("get-by-local-id/{localId}")]
     public async Task<IActionResult> GetAllSensorsByLocalId(int localId)
     {
        var getAllSensorsByLocalIdQuery = new GetAllSensorsByLocalIdQuery(localId);
        var sensors = await sensorQueryService.Handle(getAllSensorsByLocalIdQuery);
        var sensorResources = sensors.Select(SensorResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(sensorResources);
     }
     
     [HttpGet("get-by-id/{sensorId}")]
     public async Task<IActionResult> GetSensorById(int sensorId)
     {
         var getSensorByIdQuery = new GetSensorByIdQuery(sensorId);
         var sensor = await sensorQueryService.Handle(getSensorByIdQuery);
         if (sensor is null) return NotFound();
         var sensorResource = SensorResourceFromEntityAssembler.ToResourceFromEntity(sensor);
         return Ok(sensorResource);
     }

     [HttpGet("readings/get-by-sensor-id/{sensorId}")]
     public async Task<IActionResult> GetReadingsBySensorId(int sensorId)
     {
         var getReadingsBySensorIdQuery = new GetAllReadingsBySensorIdQuery(sensorId);
         var readings = await sensorQueryService.Handle(getReadingsBySensorIdQuery);
         var readingResources = readings.Select(ReadingResourceFromEntityAssembler.ToResourceFromEntity);
         return Ok(readingResources);
     }
}