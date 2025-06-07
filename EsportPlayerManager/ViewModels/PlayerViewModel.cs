using System.Collections.ObjectModel;
using ReactiveUI;
using System.Reactive;
using EsportPlayerManager.Models;
using EsportPlayerManager.Data;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace EsportPlayerManager.ViewModels;

public class PlayerViewModel : ReactiveObject
{
    private readonly EsportManagerDbContext _context;

    public ObservableCollection<Player> Players { get; } = new();

    private Player _newPlayer;
    public Player NewPlayer
    {
        get => _newPlayer;
        set => this.RaiseAndSetIfChanged(ref _newPlayer, value);
    }

    public ReactiveCommand<Unit, Unit> AddPlayerCommand { get; }

    public PlayerViewModel()
    {
        _context = new EsportManagerDbContext();

        foreach (var player in _context.Players)
            Players.Add(player);

        ResetNewPlayer();

        AddPlayerCommand = ReactiveCommand.CreateFromTask(AddPlayerAsync, outputScheduler: RxApp.MainThreadScheduler);
    }

    private async Task AddPlayerAsync()
    {
        var player = NewPlayer;

        _context.Players.Add(player);
        await _context.SaveChangesAsync();

        Players.Add(player);

        ResetNewPlayer();
    }

    private void ResetNewPlayer()
    {
        NewPlayer = new Player
        {
            Name = "",
            Nickname = "",
            Game = "",
            SkillLevel = 0,
            StressLevel = 0,
            FatigueLevel = 0,
        };
    }
}