using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using EsportPlayerManager.Data;
using EsportPlayerManager.Models;
using MyRelayCommand = EsportPlayerManager.Commands.RelayCommand;

namespace EsportPlayerManager.ViewModels
{
    public class TrainingViewModel : ViewModelBase
    {
        private int _playerId;
        private int _trainingId;
        public ObservableCollection<Training> Trainings { get; }

        public int PlayerId
        {
            get => _playerId;
            set
            {
                if (_playerId != value)
                {
                    _playerId = value;
                    OnPropertyChanged();
                    _trainPlayerCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public int TrainingId
        {
            get => _trainingId;
            set
            {
                if (_trainingId != value)
                {
                    _trainingId = value;
                    OnPropertyChanged();
                    _trainPlayerCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private MyRelayCommand _trainPlayerCommand;
        public ICommand TrainPlayerCommand => _trainPlayerCommand;

        public TrainingViewModel()
        {
            using var context = new EsportManagerDbContext();
            Trainings = new ObservableCollection<Training>(context.Trainings);

            _trainPlayerCommand = new MyRelayCommand(TrainPlayer, CanTrainPlayer);
        }

        private bool CanTrainPlayer(object parameter)
        {
            return PlayerId > 0 && TrainingId > 0;
        }

        private void TrainPlayer(object parameter)
        {
            using var context = new EsportManagerDbContext();

            var player = context.Players.Find(PlayerId);
            var training = context.Trainings.Find(TrainingId);

            if (player == null || training == null)
                return;

            player.SkillLevel += training.SkillIncrease;
            player.FatigueLevel += training.FatigueIncrease;

            var result = context.SaveChanges();
            System.Diagnostics.Debug.WriteLine($"SaveChanges result: {result}");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
