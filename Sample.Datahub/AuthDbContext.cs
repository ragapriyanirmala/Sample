using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sample.Datahub.Models.Domain;
using System.Reflection;
using System.Xml;

namespace Sample.Datahub
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "902fa31b-2be9-4f95-b280-761b5627e7dc";
            var writerRoleId = "fc5a63fc-b35b-4604-9362-f8c973560054";

            var roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    
                }
            };


            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
