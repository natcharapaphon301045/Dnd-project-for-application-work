using Dnd_project_for_application_work.Domain_Layer;
using Microsoft.EntityFrameworkCore;

namespace Dnd_project_for_application_work.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Character> Characters { get; set; } = null!;
        public DbSet<Race> Races { get; set; } = null!;
        public DbSet<Class> Classes { get; set; } = null!;
        public DbSet<Alignment> Alignments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Character -> Alignment (Many to One)
            modelBuilder.Entity<Character>()
                .HasOne(c => c.Alignment)
                .WithMany(a => a.Characters)
                .HasForeignKey(c => c.AlignmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Character -> Class (Many to One)
            modelBuilder.Entity<Character>()
                .HasOne(c => c.Class)
                .WithMany(cl => cl.Characters)
                .HasForeignKey(c => c.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            // Character -> Race (Many to One)
            modelBuilder.Entity<Character>()
                .HasOne(c => c.Race)
                .WithMany(r => r.Characters)
                .HasForeignKey(c => c.RaceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
