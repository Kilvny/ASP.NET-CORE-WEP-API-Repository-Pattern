using Microsoft.AspNetCore.Identity;
using NKRY_API.Domain.Entities;
using static NKRY_API.Utilities.Constants;

namespace NKRY_API.Domain.Contracts
{
    public interface IUserRepository
    {
        public User GetUserById(Guid id);
        IEnumerable<User> GetAllUsers(Guid id);

        void AddUser(User user);

        void UpdateUserPassword(User user);
        public UserRole GetUserRole(Guid id);
    }
}
