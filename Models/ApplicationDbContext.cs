using Microsoft.EntityFrameworkCore;

namespace ActivityTracker.Models {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions options) : base(options) {

        }

        public DbSet<Activity> Activities { get; set; }
    }
}
