using SchoolApp.Core;
using SchoolApp.Core.Filters;
using SchoolApp.DTO;
using SchoolApp.Models;

namespace SchoolApp.Services
{
    public interface IUserService
    {
        Task<User?> VerifyAndGetUserAsync(UserLoginDTO credentials);
        Task<UserReadOnlyDTO?> GetUserByUsername(string username);
        Task<PaginatedResult<UserReadOnlyDTO>> GetPaginatedUsersFilteredAsync(int pageNumber, int pageSize, UserFiltersDTO userFiltersDTO);
    }
}
