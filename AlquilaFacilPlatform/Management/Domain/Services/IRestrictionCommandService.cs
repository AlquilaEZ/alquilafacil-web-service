using AlquilaFacilPlatform.Management.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Management.Domain.Model.Commands;

namespace AlquilaFacilPlatform.Management.Domain.Services;

public interface IRestrictionCommandService
{
    Task<Restriction?> Handle(CreateRestrictionCommand command);
}