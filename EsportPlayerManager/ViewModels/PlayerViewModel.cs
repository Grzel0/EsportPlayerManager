using System.Collections.ObjectModel;
using System.Reactive;
using EsportPlayerManager.Data;
using EsportPlayerManager.Models;
using ReactiveUI;

namespace EsportPlayerManager.ViewModels
{
    public class PlayerViewModel : ViewModelBase
    {
        private readonly EsportManagerDbContext _context;

        public ObservableCollection<Player> Players { get; }
        public ReactiveCommand<Unit, Unit> AddPlayerCommand { get; }

        public PlayerViewModel()
        {
            _context = new EsportManagerDbContext();
            Players = new ObservableCollection<Player>(_context.Players);

            AddPlayerCommand = ReactiveCommand.Create(AddDefaultPlayer);
        }

        private void AddDefaultPlayer()
        {
            var player = new Player
            {
                Name = "Nowy",
                Nickname = "NowyGracz",
                Game = "CS:GO",
                Aim = 50,
                Strategy = 50,
                Reflex = 50,
                StressLevel = 0,
                FatigueLevel = 0,
                Experience = 0,
                RankingPoints = 0,
                Money = 1000
            };

            _context.Players.Add(player);
            _context.SaveChanges();
            Players.Add(player);
        }
    }
}