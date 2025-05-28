using System.Collections.ObjectModel;
using EsportPlayerManager.Data;
using EsportPlayerManager.Models;

namespace EsportPlayerManager.ViewModels
{
    public class TrainingViewModel : ViewModelBase
    {
        public ObservableCollection<Training> Trainings { get; }

        public TrainingViewModel()
        {
            using var context = new EsportManagerDbContext();
            Trainings = new ObservableCollection<Training>(context.Trainings);
        }
    }
}