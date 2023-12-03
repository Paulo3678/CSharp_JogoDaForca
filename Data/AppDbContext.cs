using JogoDaForca.Data.Configurations;
using JogoDaForca.Models;
using Microsoft.EntityFrameworkCore;

namespace JogoDaForca.Data;

public class AppDbContext : DbContext
{
    public DbSet<Forca> Forcas { get; set; }
    public DbSet<DiscoveryChar> DiscoveryChars { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=forca;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ForcaConf());
        modelBuilder.ApplyConfiguration(new DiscoveryCharConf());
        base.OnModelCreating(modelBuilder);
    }
}
