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

    public string Execute(int playerId, int tournamentId)
    {
        var player = _context.Players.Find(playerId);
        var tournament = _context.Tournaments.Find(tournamentId);

        if (player == null || tournament == null)
            return "Brak gracza lub turnieju.";

        if (player.SkillLevel < tournament.MinSkillRequired)
            return "Za niski poziom umiejętności, aby wziąć udział.";

        if (player.Money < tournament.EntryFee)
            return "Brak wystarczających środków na wpisowe.";

        player.Money -= tournament.EntryFee;

        int performance = player.SkillLevel + _random.Next(-20, 21);
        bool won = performance >= tournament.MinSkillRequired;

        if (won)
        {
            player.Money += tournament.PrizePool;
            player.RankingPoints += 10;
            player.Experience += 5;
            _context.SaveChanges();
            return "Gracz wygrał turniej!";
        }
        else
        {
            player.Experience += 2;
            _context.SaveChanges();
            return "Gracz przegrał turniej.";
        }
    }
}