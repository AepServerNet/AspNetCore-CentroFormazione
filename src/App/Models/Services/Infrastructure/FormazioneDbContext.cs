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
        public virtual DbSet<Edificio> Edifici { get; set; }
        public virtual DbSet<Docente> Docenti { get; set; }

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

            modelBuilder.Entity<Docente>(entity =>
            {
                entity.ToTable("Docenti");
                entity.HasKey(docente => docente.Id);

                entity.OwnsOne(docente => docente.CostoOrario, builder => {
                    builder.Property(money => money.Currency)
                        .HasConversion<string>()
                        .HasColumnName("CostoOrario_Currency");
                    builder.Property(money => money.Amount)
                        .HasColumnName("CostoOrario_Amount")
                        .HasConversion<float>();
                });

                entity.HasMany(docente => docente.Lezioni)
                    .WithOne(lezione => lezione.Docente)
                    .HasForeignKey(lezione => lezione.DocenteId);
            });

            modelBuilder.Entity<Edificio>(entity => 
            {
                entity.ToTable("Edifici");
                entity.HasKey(edificio => edificio.Id);
            });
        }
    }
}