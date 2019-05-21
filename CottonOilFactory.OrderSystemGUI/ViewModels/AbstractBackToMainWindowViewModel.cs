using CottonOilFactory.OrderSystemGUI.Factories;
using CottonOilFactory.OrderSystemGUI.Interfaces;
using GalaSoft.MvvmLight.CommandWpf;

namespace CottonOilFactory.OrderSystemGUI.ViewModels
{
    public abstract class AbstractBackToMainWindowViewModel : ViewModelBase
    {
        private readonly AbstractWindowFactory _mainWindowFactory;

        protected AbstractBackToMainWindowViewModel(AbstractWindowFactory mainWindowFactory)
        {
            _mainWindowFactory = mainWindowFactory;
            GoBackToMainWindowCommand = new RelayCommand<IClosableWindow>(GoBackToMainWindow);
        }

        public RelayCommand<IClosableWindow> GoBackToMainWindowCommand { get; }

        public void GoBackToMainWindow(IClosableWindow closableWindow)
        {
            _mainWindowFactory?.CreateWindow();
            closableWindow?.Close();
        }
    }
}