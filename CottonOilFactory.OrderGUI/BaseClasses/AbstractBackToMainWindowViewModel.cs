using CottonOilFactory.OrderGUI.Factories;
using CottonOilFactory.OrderGUI.Interfaces;
using GalaSoft.MvvmLight.CommandWpf;

namespace CottonOilFactory.OrderGUI.BaseClasses
{
    public abstract class AbstractBackToMainWindowViewModel : ViewModelBase
    {
        protected readonly AbstractWindowFactory mainWindowFactory;

        protected AbstractBackToMainWindowViewModel(AbstractWindowFactory mainWindowFactory)
        {
            this.mainWindowFactory = mainWindowFactory;
            GoBackToMainWindowCommand = new RelayCommand<IClosableWindow>(GoBackToMainWindow);
        }

        public RelayCommand<IClosableWindow> GoBackToMainWindowCommand { get; }

        public void GoBackToMainWindow(IClosableWindow closableWindow)
        {
            mainWindowFactory?.CreateWindow();
            closableWindow?.Close();
        }
    }
}