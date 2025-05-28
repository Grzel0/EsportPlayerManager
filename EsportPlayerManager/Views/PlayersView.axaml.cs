using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using EsportPlayerManager.ViewModels;

namespace EsportPlayerManager.Views
{
    public partial class PlayersView : UserControl
    {
        public PlayersView()
        {
            AvaloniaXamlLoader.Load(this);

            DataContext = new PlayerViewModel();
        }
    }
}