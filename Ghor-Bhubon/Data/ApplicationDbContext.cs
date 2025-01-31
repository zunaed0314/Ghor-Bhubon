using Microsoft.EntityFrameworkCore;
using Ghor_Bhubon.Models;

namespace Ghor_Bhubon.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } 
    }
}
