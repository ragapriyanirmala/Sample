using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Sample.Datahub.Models.Domain;

namespace Sample.Datahub
{
    public class SampleDbContext:DbContext
    {
        public SampleDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
                
        }
        public DbSet<Branch> Branches { get; set; } 
        public DbSet<Team> Teams { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
