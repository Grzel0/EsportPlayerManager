using System.Collections.ObjectModel;
using EsportPlayerManager.Data;
using EsportPlayerManager.Models;

namespace EsportPlayerManager.ViewModels
{
    public class TournamentViewModel : ViewModelBase
    {
        public ObservableCollection<Tournament> Tournaments { get; }

        public TournamentViewModel()
        {
            using var context = new EsportManagerDbContext();
            Tournaments = new ObservableCollection<Tournament>(context.Tournaments);
        }
    }
}