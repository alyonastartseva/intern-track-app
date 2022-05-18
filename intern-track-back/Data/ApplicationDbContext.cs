using intern_track_back.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace intern_track_back.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {
        }
        
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        
        public DbSet<Company> Companies { get; set; }
        public DbSet<Curator> Curators { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne<ApplicationUser>()
                .WithOne(el => el.User)
                .HasForeignKey<User>(el => el.ApplicationUserId);
            
            builder.Entity<ApplicationUser>()
                .HasOne<User>()
                .WithOne(el => el.ApplicationUser)
                .HasForeignKey<ApplicationUser>(el => el.UserId);
        }
    }
}
