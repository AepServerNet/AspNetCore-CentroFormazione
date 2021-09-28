using Microsoft.EntityFrameworkCore;

namespace App.Models.Services.Infrastructure
{
    public partial class FormazioneDbContext : DbContext
    {
        public FormazioneDbContext(DbContextOptions<FormazioneDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}