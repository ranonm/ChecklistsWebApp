using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Checklists.Models
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