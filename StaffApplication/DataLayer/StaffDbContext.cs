using Microsoft.EntityFrameworkCore;
using StaffApplication.Models;

namespace StaffApplication.DataLayer
{
    public class StaffDbContext : DbContext
    {
       

        public StaffDbContext(DbContextOptions<StaffDbContext> options) : base(options)
        {

        }
        public DbSet<Staff> Staff { get; set; }
            
        public DbSet<Staff> staffLists { get; set; }
    }
}
