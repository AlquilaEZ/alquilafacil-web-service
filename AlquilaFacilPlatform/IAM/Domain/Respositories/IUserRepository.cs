using AlquilaFacilPlatform.IAM.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Shared.Domain.Repositories;

namespace AlquilaFacilPlatform.IAM.Domain.Respositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByEmailAsync (string email);
    Task<bool> ExistsByUsername(string username);
    Task<string?> GetUsernameByIdAsync(int userId);
    bool ExistsById(int userId);
}