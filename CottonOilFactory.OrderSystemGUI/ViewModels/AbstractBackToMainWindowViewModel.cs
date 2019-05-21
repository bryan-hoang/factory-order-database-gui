using CottonOilFactory.OrderSystemGUI.Factories;
using CottonOilFactory.OrderSystemGUI.Interfaces;
using GalaSoft.MvvmLight.CommandWpf;

namespace CottonOilFactory.OrderSystemGUI.ViewModels
{
    public abstract class AbstractBackToMainWindowViewModel : ViewModelBase
    {
        protected readonly AbstractWindowFactory MainWindowFactory;

        protected AbstractBackToMainWindowViewModel(AbstractWindowFactory mainWindowFactory)
        {
            this.MainWindowFactory = mainWindowFactory;
            GoBackToMainWindowCommand = new RelayCommand<IClosableWindow>(GoBackToMainWindow);
        }

        public RelayCommand<IClosableWindow> GoBackToMainWindowCommand { get; }

        public void GoBackToMainWindow(IClosableWindow closableWindow)
        {
            MainWindowFactory?.CreateWindow();
            closableWindow?.Close();
        }
    }
}