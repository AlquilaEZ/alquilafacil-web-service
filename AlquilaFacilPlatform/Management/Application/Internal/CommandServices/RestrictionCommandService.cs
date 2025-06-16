using AlquilaFacilPlatform.Management.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Management.Domain.Model.Commands;
using AlquilaFacilPlatform.Management.Domain.Repositories;
using AlquilaFacilPlatform.Management.Domain.Services;
using AlquilaFacilPlatform.Shared.Application.Internal.OutboundServices;
using AlquilaFacilPlatform.Shared.Domain.Repositories;

namespace AlquilaFacilPlatform.Management.Application.Internal.CommandServices;

public class RestrictionCommandService(
    IRestrictionRepository restrictionRepository,
    ILocalExternalService localExternalService,
    IUnitOfWork unitOfWork
    ): IRestrictionCommandService
{
    public async Task<Restriction?> Handle(CreateRestrictionCommand command)
    {
        var localExists = await localExternalService.LocalExists(command.LocalId);
        if (!localExists)
        {
            throw new Exception("Local does not exist");
        }
        var restriction = new Restriction(command);
        await restrictionRepository.AddAsync(restriction);
        await unitOfWork.CompleteAsync();
        return restriction;
    }
}