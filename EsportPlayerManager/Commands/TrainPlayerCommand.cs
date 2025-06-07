using EsportPlayerManager.Data;

namespace EsportPlayerManager.Commands;

public class TrainPlayerCommand
{
    private readonly EsportManagerDbContext _context;

    public TrainPlayerCommand(EsportManagerDbContext context)
    {
        _context = context;
    }

    public void Execute(int playerId, int trainingId)
    {
        var player = _context.Players.Find(playerId);
        var training = _context.Trainings.Find(trainingId);

        if (player == null || training == null)
            return;

        player.SkillLevel += training.SkillIncrease;
        player.FatigueLevel += training.FatigueIncrease;
        player.StressLevel += training.StressIncrease;

        _context.SaveChanges();
    }
}