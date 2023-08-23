using NKRY_API.DataAccess.EFCore;
using NKRY_API.Domain.Contracts;
using NKRY_API.Domain.Entities;
using static NKRY_API.Utilities.Constants;

namespace NKRY_API.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext applicationContext) 
            : base(applicationContext)
        {

        }

        public void UpdateUserPassword(User user)
        {

        }
        public UserRole GetUserRole(int id)
        {
            User user = _applicationContext.users.Find(id);
            return user.Role;
        }
    }
}
