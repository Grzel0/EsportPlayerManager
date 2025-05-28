namespace EsportPlayerManager.Models;

public class Tournament
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal EntryFee { get; set; }
    public decimal PrizePool { get; set; }
    public int MinSkillRequired { get; set; }
}