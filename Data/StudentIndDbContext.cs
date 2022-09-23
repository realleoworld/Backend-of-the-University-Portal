using Microsoft.EntityFrameworkCore;
using RealleoschoolindAPI.Models;

namespace RealleoschoolindAPI.Data
{
    public class StudentIndDbContext : DbContext
    {
        public StudentIndDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student>  Student { get; set; }
        public DbSet<course> course { get; set; }


    }
}
