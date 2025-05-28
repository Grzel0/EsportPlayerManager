using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Threading;
using ReactiveUI;
using EsportPlayerManager.Models;
using EsportPlayerManager.Data;
using System.Reactive;

namespace EsportPlayerManager.ViewModels
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        private readonly EsportManagerDbContext _context;
        private ObservableCollection<Player> _players;
        private Player _newPlayer;

        public ObservableCollection<Player> Players
        {
            get => _players;
            set { _players = value; OnPropertyChanged(); }
        }

        public Player NewPlayer
        {
            get => _newPlayer;
            set { _newPlayer = value; OnPropertyChanged(); }
        }

        public ReactiveCommand<Unit, Unit> AddPlayerCommand { get; }

        public PlayerViewModel()
        {
            _context = new EsportManagerDbContext();
            Players = new ObservableCollection<Player>(_context.Players);
            
            ResetNewPlayer();

            AddPlayerCommand = ReactiveCommand.Create(AddPlayer);
        }

        private void ResetNewPlayer()
        {
            NewPlayer = new Player
            {
                Name = string.Empty,
                Nickname = string.Empty,
                Game = string.Empty,
                Aim = 0,
                Strategy = 0,
                Reflex = 0,
                StressLevel = 0,
                FatigueLevel = 0,
                Experience = 0,
                RankingPoints = 0,
                Money = 0
            };
        }

        private void AddPlayer()
        {
            _context.Players.Add(NewPlayer);
            _context.SaveChanges();

            Dispatcher.UIThread.Post(() => Players.Add(NewPlayer));

            ResetNewPlayer();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
