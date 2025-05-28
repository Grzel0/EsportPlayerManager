namespace EsportPlayerManager.Models;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Nickname { get; set; }
    public string Game { get; set; }
    public int Aim { get; set; }
    public int Strategy { get; set; }
    public int Reflex { get; set; }

    public int StressLevel { get; set; }
    public int FatigueLevel { get; set; }
    public int Experience { get; set; }
    public int RankingPoints { get; set; }
    public decimal Money { get; set; }

    public int SkillLevel => (Aim + Strategy + Reflex) / 3;
}