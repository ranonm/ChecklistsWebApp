using System.Data.Entity;
using Checklists.Core.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Checklists.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}