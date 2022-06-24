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
        
        public DbSet<User> UsersCustom { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Curator> Curators { get; set; }
        public DbSet<Deanery> Deaneries { get; set; }
        public DbSet<Student> Students { get; set; }
        
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<StackForInterviewPlan> StackForInterviewPlans { get; set; }
        public DbSet<StudentPlanForInterview> StudentPlanForInterviews { get; set; }
        public DbSet<UserChat> UserChats { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Связь 1-к-1 User-ApplicationUser

            builder.Entity<User>()
                .HasOne<ApplicationUser>()
                .WithOne(el => el.User)
                .HasForeignKey<User>(el => el.ApplicationUserId);
            
            builder.Entity<ApplicationUser>()
                .HasOne<User>()
                .WithOne(el => el.ApplicationUser)
                .HasForeignKey<ApplicationUser>(el => el.UserId);

            #endregion
            
            #region Предотвращение петли через Student-Grades-Deanery
            
            builder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<Grade>()
                .HasOne(g => g.Deanery)
                .WithMany(d => d.Grades)
                .HasForeignKey(g => g.DeaneryId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Deanery>()
                .HasMany(d => d.Grades)
                .WithOne(g => g.Deanery)
                .HasForeignKey(g => g.DeaneryId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<Student>()
                .HasMany(s => s.Grades)
                .WithOne(g => g.Student)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            
            #endregion

            #region Предотвращение петли через Company-Interview-Student

            builder.Entity<Interview>()
                .HasOne(i => i.Company)
                .WithMany(c => c.Interviews)
                .HasForeignKey(i => i.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<Interview>()
                .HasOne(i => i.Student)
                .WithMany(s => s.Interviews)
                .HasForeignKey(i => i.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Company>()
                .HasMany(c => c.Interviews)
                .WithOne(i => i.Company)
                .HasForeignKey(i => i.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<Student>()
                .HasMany(c => c.Interviews)
                .WithOne(i => i.Student)
                .HasForeignKey(i => i.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Предотвращение петли через Company-Note-Student

            builder.Entity<Note>()
                .HasOne(n => n.Company)
                .WithMany(c => c.Notes)
                .HasForeignKey(n => n.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<Note>()
                .HasOne(n => n.Student)
                .WithMany(s => s.Notes)
                .HasForeignKey(n => n.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<Company>()
                .HasMany(c => c.Notes)
                .WithOne(n => n.Company)
                .HasForeignKey(n => n.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<Student>()
                .HasMany(s => s.Notes)
                .WithOne(n => n.Student)
                .HasForeignKey(n => n.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Предотвращение петли через Company-StudentPlanForInterview-Student

            builder.Entity<StudentPlanForInterview>()
                .HasOne(p => p.Company)
                .WithMany(c => c.StudentPlanForInterviews)
                .HasForeignKey(n => n.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<StudentPlanForInterview>()
                .HasOne(p => p.Student)
                .WithMany(s => s.StudentPlanForInterviews)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<Company>()
                .HasMany(c => c.StudentPlanForInterviews)
                .WithOne(p => p.Company)
                .HasForeignKey(p => p.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<Student>()
                .HasMany(s => s.StudentPlanForInterviews)
                .WithOne(p => p.Student)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
            
            //мн-ко-мн User-Chat
            builder.Entity<UserChat>()
                .HasKey(x => new { x.UserId, x.ChatId });

            base.OnModelCreating(builder);
        }
    }
}
