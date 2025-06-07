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

    public void Execute(int playerId, int tournamentId)
    {
        System.Diagnostics.Debug.WriteLine($"Execute - playerId: {playerId}, tournamentId: {tournamentId}");

        var player = _context.Players.Find(playerId);
        var tournament = _context.Tournaments.Find(tournamentId);

        if (player == null || tournament == null)
            return;

        if (player.SkillLevel < tournament.MinSkillRequired)
            return;

        if (player.Money.GetValueOrDefault() < tournament.EntryFee)
            return;

        player.Money = player.Money.GetValueOrDefault() - tournament.EntryFee;

        double winChance = Math.Min(1.0, (double)player.SkillLevel / tournament.MinSkillRequired);

        bool playerWon = _random.NextDouble() <= winChance;

        if (playerWon)
        {
            player.Money = player.Money.GetValueOrDefault() + tournament.PrizePool;
        }

        _context.Entry(player).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        int result = _context.SaveChanges();
        System.Diagnostics.Debug.WriteLine($"SaveChanges zwróciło: {result}");
    }
}