using System.Collections.ObjectModel;
using EsportPlayerManager.Data;
using EsportPlayerManager.Models;

namespace EsportPlayerManager.Commands;

public class AddPlayerCommand
{
    private readonly EsportManagerDbContext _context;
    private readonly ObservableCollection<Player> _players;

    public AddPlayerCommand(EsportManagerDbContext context, ObservableCollection<Player> players)
    {
        _context = context;
        _players = players;
    }

    public void Execute(Player player)
    {
        _context.Players.Add(player);
        _context.SaveChanges();
        _players.Add(player);
    }
}