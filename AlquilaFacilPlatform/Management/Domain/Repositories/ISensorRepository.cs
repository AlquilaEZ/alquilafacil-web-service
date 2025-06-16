using AlquilaFacilPlatform.Management.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Shared.Domain.Repositories;

namespace AlquilaFacilPlatform.Management.Domain.Repositories;

public interface ISensorRepository: IBaseRepository<Sensor>
{
    Task<IEnumerable<Sensor>> FindAllByLocalId(int localId);
}