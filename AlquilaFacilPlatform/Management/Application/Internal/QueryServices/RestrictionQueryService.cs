using AlquilaFacilPlatform.Management.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Management.Domain.Model.Queries;
using AlquilaFacilPlatform.Management.Domain.Repositories;
using AlquilaFacilPlatform.Management.Domain.Services;

namespace AlquilaFacilPlatform.Management.Application.Internal.QueryServices;

public class RestrictionQueryService(IRestrictionRepository restrictionRepository): IRestrictionQueryService
{
    public async Task<Restriction?> Handle(GetRestrictionByLocalIdQuery query)
    {
        return await restrictionRepository.FindByLocalId(query.LocalId);
    }
}