using Microsoft.EntityFrameworkCore;
using NKRY_API.Domain.Entities;

namespace NKRY_API.DataAccess.EFCore
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> users { get; set; }
    }
}
