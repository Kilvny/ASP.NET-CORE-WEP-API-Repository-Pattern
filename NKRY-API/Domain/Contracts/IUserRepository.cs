using Microsoft.AspNetCore.Identity;
using NKRY_API.Domain.Entities;
using static NKRY_API.Utilities.Constants;

namespace NKRY_API.Domain.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        void UpdateUserPassword(User user);
        public UserRole GetUserRole(int id);
    }
}
