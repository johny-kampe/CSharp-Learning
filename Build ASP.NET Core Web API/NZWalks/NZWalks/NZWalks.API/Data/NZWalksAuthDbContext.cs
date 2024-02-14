using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRuleId = "855583aa-d7df-472e-bbea-9a6e7bd20b41";
            var writerRuleId = "5bed93e7-0af0-4fa1-a52f-cee50ec2e10e";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRuleId,
                    ConcurrencyStamp = readerRuleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRuleId,
                    ConcurrencyStamp = writerRuleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
