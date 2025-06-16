using System.Net.Mime;
using AlquilaFacilPlatform.Management.Domain.Model.Queries;
using AlquilaFacilPlatform.Management.Domain.Services;
using AlquilaFacilPlatform.Management.Interfaces.REST.Resources;
using AlquilaFacilPlatform.Management.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace AlquilaFacilPlatform.Management.Interfaces.REST;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class RestrictionsController(IRestrictionCommandService commandService, IRestrictionQueryService queryService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateRestriction([FromBody] CreateRestrictionResource resource)
    {
        var createRestrictionCommand = CreateRestrictionCommandFromResourceAssembler.ToCommandFromResource(resource);
        var restriction = await commandService.Handle(createRestrictionCommand);
        if (restriction is null) return BadRequest();
        var restrictionResource = RestrictionResourceFromEntityAssembler.ToResourceFromEntity(restriction);
        return StatusCode(201, restrictionResource);
    }
    
    [HttpGet("get-by-local-id/{localId}")]
    public async Task<IActionResult> GetRestrictionByLocalId(int localId)
    {
        var getRestrictionByLocalIdQuery = new GetRestrictionByLocalIdQuery(localId);
        var restriction = await queryService.Handle(getRestrictionByLocalIdQuery);
        if (restriction is null) return NotFound();
        var restrictionResource = RestrictionResourceFromEntityAssembler.ToResourceFromEntity(restriction);
        return Ok(restrictionResource);
    }
}