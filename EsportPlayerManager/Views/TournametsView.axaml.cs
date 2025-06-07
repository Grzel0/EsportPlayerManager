using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using EsportPlayerManager.ViewModels;

namespace EsportPlayerManager.Views;

public partial class TournametsView : UserControl
{
    public TournametsView()
    {
        InitializeComponent();
    }

    private void OnJoinTournamentClicked(object sender, RoutedEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Przycisk został kliknięty!");

        if (DataContext is TournamentViewModel vm)
        {
            if (int.TryParse(PlayerIdTextBox.Text, out int playerId))
                vm.PlayerId = playerId;

            if (int.TryParse(TournamentIdTextBox.Text, out int tournamentId))
                vm.TournamentId = tournamentId;

            if (vm.JoinTournamentCommand.CanExecute(null))
                vm.JoinTournamentCommand.Execute(null);
        }
    }
}