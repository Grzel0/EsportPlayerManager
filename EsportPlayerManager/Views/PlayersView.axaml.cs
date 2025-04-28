using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using EsportPlayerManager.Models;
using EsportPlayerManager.ViewModels;

namespace EsportPlayerManager.Views;

public partial class PlayersView : UserControl
{
    public PlayersView()
    {
        InitializeComponent();
        _viewModel = new PlayerViewModel();
        this.DataContext = _viewModel;
    }

    private void AddPlayer_Click(object sender, RoutedEventArgs e)
    {
        var newPlayer = new Player
        {
            Name = "Nowy",
            Nickname = "NowyGracz",
            Game = "Gra",
            Aim = 50,
            Strategy = 50,
            StressLevel = 0,
            FatigueLevel = 0,
            //     Experience = 0,
            //     RankingPoints = 0,
            //     Money = 1000
        };
        _viewModel.AddPlayer(newPlayer);
    }
}