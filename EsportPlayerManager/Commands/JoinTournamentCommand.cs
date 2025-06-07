using System;
using EsportPlayerManager.Data;

namespace EsportPlayerManager.Commands;

public class JoinTournamentCommand
{
    private readonly EsportManagerDbContext _context;
    private readonly Random _random = new();

    public JoinTournamentCommand(EsportManagerDbContext context)
    {
        _context = context;
    }
}