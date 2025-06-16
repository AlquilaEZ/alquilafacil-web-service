using AlquilaFacilPlatform.Management.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Management.Domain.Repositories;
using AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AlquilaFacilPlatform.Management.Infrastructure.Persistence.EFC.Repositories;

public class SensorRepository(AppDbContext context): BaseRepository<Sensor>(context), ISensorRepository
{
    public async Task<IEnumerable<Sensor>> FindAllByLocalId(int localId)
    {
        return await Context.Set<Sensor>()
            .Where(sensor => sensor.LocalId == localId)
            .ToListAsync();
    }
}