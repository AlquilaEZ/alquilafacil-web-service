using AlquilaFacilPlatform.Management.Domain.Model.Entities;
using AlquilaFacilPlatform.Management.Domain.Model.ValueObjects;
using AlquilaFacilPlatform.Management.Domain.Repositories;
using AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AlquilaFacilPlatform.Management.Infrastructure.Persistence.EFC.Repositories;

public class SensorStateRepository(AppDbContext dbContext): BaseRepository<SensorState>(dbContext), ISensorStateRepository
{
    public Task<bool> ExistsSensorState(ESensorStates state)
    {
        return Context.Set<SensorState>().AnyAsync(x => x.State == state.ToString());
    }
}