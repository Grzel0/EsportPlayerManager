using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using EsportPlayerManager.Data;
using EsportPlayerManager.Models;
using EsportPlayerManager.Commands;

namespace EsportPlayerManager.ViewModels
{
    public class TournamentViewModel : INotifyPropertyChanged
    {
        private int _playerId;
        private int _tournamentId;

        public ObservableCollection<Tournament> Tournaments { get; }

        public int PlayerId
        {
            get => _playerId;
            set
            {
                if (_playerId != value)
                {
                    _playerId = value;
                    OnPropertyChanged();
                    _joinTournamentCommand?.RaiseCanExecuteChanged();
                }
            }
        }

        public int TournamentId
        {
            get => _tournamentId;
            set
            {
                if (_tournamentId != value)
                {
                    _tournamentId = value;
                    OnPropertyChanged();
                    _joinTournamentCommand?.RaiseCanExecuteChanged();
                }
            }
        }

        private RelayCommand _joinTournamentCommand;
        public ICommand JoinTournamentCommand => _joinTournamentCommand;

        public TournamentViewModel()
        {
            using var context = new EsportManagerDbContext();
            Tournaments = new ObservableCollection<Tournament>(context.Tournaments);

            _joinTournamentCommand = new RelayCommand(
                _ => JoinTournament(),
                _ => PlayerId > 0 && TournamentId > 0);
        }

        private void JoinTournament()
        {
            using var context = new EsportManagerDbContext();
            var command = new JoinTournamentCommand(context);
            command.Execute(PlayerId, TournamentId);

            // Odśwież listę po zmianach w bazie
            Tournaments.Clear();
            foreach (var t in context.Tournaments)
            {
                Tournaments.Add(t);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
