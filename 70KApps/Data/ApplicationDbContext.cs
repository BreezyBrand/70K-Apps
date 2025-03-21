using _70KApps.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using _70KApps.Areas.OiNao.Models;

namespace _70KApps.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<OiNaoContact> OiNaoContacts { get; set; }
        public DbSet<OiNaoEmail> OiNaoEmails { get; set; }
        public DbSet<OiNaoAddress> OiNaoAddresses { get; set; }
        public DbSet<OiNaoContactNumber> OiNaoContactNumbers { get; set; }
        public DbSet<OiNaoRelationship> OiNaoRelationships { get; set; }


    }

}