using Dnd_project_for_application_work.Domain_Layer;
using Microsoft.EntityFrameworkCore;

namespace Dnd_project_for_application_work.Infrastructure_Layer.Persistence_DbContext

{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
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

            modelBuilder.Entity<Character>()
                .HasOne(c => c.Alignment)
                .WithMany(a => a.Characters)
                .HasForeignKey(c => c.AlignmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Character>()
                .HasOne(c => c.Class)
                .WithMany(cl => cl.Characters)
                .HasForeignKey(c => c.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Character>()
                .HasOne(c => c.Race)
                .WithMany(r => r.Characters)
                .HasForeignKey(c => c.RaceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
