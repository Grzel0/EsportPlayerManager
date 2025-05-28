using EsportPlayerManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EsportPlayerManager.Data;

public class EsportManagerDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql("Host=localhost;Database=EsportManager;Username=postgres;Password=haslo123");
}