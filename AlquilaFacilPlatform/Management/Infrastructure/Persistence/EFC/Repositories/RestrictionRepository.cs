using AlquilaFacilPlatform.Management.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Management.Domain.Repositories;
using AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AlquilaFacilPlatform.Management.Infrastructure.Persistence.EFC.Repositories;

public class RestrictionRepository(AppDbContext context) : BaseRepository<Restriction>(context), IRestrictionRepository
{
    public async Task<Restriction?> FindByLocalId(int localId)
    {
        return await Context.Set<Restriction>()
            .FirstOrDefaultAsync(restriction => restriction.LocalId == localId);
    }
}