using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksAuthDbContext: DbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var readerRuleId = Guid.NewGuid().ToString();
            var writerRuleId = Guid.NewGuid().ToString();

            var roles = new List<IdentityRole> 
            { 
                new IdentityRole
                {
                    Id = readerRuleId,
                    ConcurrencyStamp = readerRuleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },new IdentityRole
                {
                    Id = writerRuleId,
                    ConcurrencyStamp = writerRuleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };
        }
    }
}
