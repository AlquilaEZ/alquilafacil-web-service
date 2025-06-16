using AlquilaFacilPlatform.Management.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Management.Domain.Model.Queries;

namespace AlquilaFacilPlatform.Management.Domain.Services;

public interface IRestrictionQueryService
{
    Task<Restriction?> Handle(GetRestrictionByLocalIdQuery query);
}