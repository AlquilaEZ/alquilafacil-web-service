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
public class LocalEdgeNodesController(ILocalEdgeNodeQueryService localEdgeNodeQueryService, 
                                    ILocalEdgeNodeCommandService localEdgeNodeCommandService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateLocalEdgeNode([FromBody] CreateLocalEdgeNodeResource resource)
    {
        var command = CreateLocalEdgeNodeCommandFromResourceAssembler.ToCommandFromResource(resource);
        var localEdgeNode = await localEdgeNodeCommandService.Handle(command);
        if (localEdgeNode is null) return BadRequest();
        var localEdgeNodeResource = LocalEdgeNodeResourceFromEntityAssembler.ToResourceFromEntity(localEdgeNode);
        return StatusCode(201, localEdgeNodeResource);
    }
    
    [HttpGet("local-id/{localId}")]
    public async Task<IActionResult> GetLocalEdgeNodeByLocalId(int localId)
    {
        var query = new GetLocalEdgeNodeByLocalIdQuery(localId);
        var localEdgeNode = await localEdgeNodeQueryService.Handle(query);
        if (localEdgeNode is null) return NotFound();
        var localEdgeNodeResource = LocalEdgeNodeResourceFromEntityAssembler.ToResourceFromEntity(localEdgeNode);
        return Ok(localEdgeNodeResource);
    }
}