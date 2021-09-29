using App.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Models.Services.Infrastructure
{
    public partial class FormazioneDbContext : DbContext
    {
        public FormazioneDbContext(DbContextOptions<FormazioneDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Corso> Corsi { get; set; }
        public virtual DbSet<Lezione> Lezioni { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Corso>(entity => 
            {
                entity.ToTable("Corsi");
                entity.HasKey(corso => corso.Id);

                entity.HasMany(corso => corso.Lezioni)
                    .WithOne(lezione => lezione.Corso)
                    .HasForeignKey(lezione => lezione.CorsoId);
            });

            modelBuilder.Entity<Lezione>(entity => 
            {
                entity.ToTable("Lezioni");
                entity.HasKey(lezione => lezione.Id);
            });
        }
    }
}