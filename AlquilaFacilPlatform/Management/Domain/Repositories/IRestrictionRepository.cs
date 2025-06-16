using AlquilaFacilPlatform.Management.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Shared.Domain.Repositories;

namespace AlquilaFacilPlatform.Management.Domain.Repositories;

public interface IRestrictionRepository: IBaseRepository<Restriction>
{
    Task<Restriction?> FindByLocalId(int localId);
}