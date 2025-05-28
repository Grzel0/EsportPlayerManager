using Avalonia.Controls;
using Avalonia.Interactivity;
using EsportPlayerManager.Models;
using EsportPlayerManager.ViewModels;

namespace EsportPlayerManager.Views
{
    public partial class PlayersView : UserControl
    {
        private PlayerViewModel _viewModel;

        public PlayersView()
        {
            InitializeComponent();
            DataContext = new PlayerViewModel();
            
        }

        private void AddPlayer_Click(object? sender, RoutedEventArgs e)
        {
            var newPlayer = new Player
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

            _viewModel.AddPlayer(newPlayer);
        }
    }
}