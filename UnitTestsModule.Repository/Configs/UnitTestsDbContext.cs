using Microsoft.EntityFrameworkCore;
using UnitTestsModule.Domain;
using UnitTestsModule.Repository.Mappings;

namespace UnitTestsModule.Repository.Configs
{
    public class UnitTestsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.ApplyConfiguration(new StudentMap());
        }

        //entities
        public DbSet<Student> Students { get; set; }
    }
}
