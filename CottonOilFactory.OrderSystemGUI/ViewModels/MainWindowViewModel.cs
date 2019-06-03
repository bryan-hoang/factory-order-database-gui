using CottonOilFactory.OrderSystemGUI.Factories;
using CottonOilFactory.OrderSystemGUI.Interfaces;
using CottonOilFactory.OrderSystemGUI.Views.TransportationData;
using GalaSoft.MvvmLight.CommandWpf;

namespace CottonOilFactory.OrderSystemGUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly AbstractWindowFactory _salesDataInputWindowFactory;
        private readonly AbstractWindowFactory _salesDataSearchWindowFactory;

        public MainWindowViewModel(AbstractWindowFactory salesDataInputWindowFactory, AbstractWindowFactory salesDataSearchWindowFactory)
        {
            _salesDataInputWindowFactory = salesDataInputWindowFactory;
            _salesDataSearchWindowFactory = salesDataSearchWindowFactory;
            GoToTransportationDataInputWindowCommand = new RelayCommand<IClosableWindow>(GoToTransportationDataInputWindow);
            GoToTransportationDataSearchWindowCommand = new RelayCommand<IClosableWindow>(GoToTransportationDataSearchWindow);
            GoToSalesDataInputWindowCommand = new RelayCommand<IClosableWindow>(GoToSalesDataInputWindow);
            GoToSalesDataSearchWindowCommand = new RelayCommand<IClosableWindow>(GoToSalesDataSearchWindow);
        }

        public RelayCommand<IClosableWindow> GoToTransportationDataInputWindowCommand { get; }

        public RelayCommand<IClosableWindow> GoToTransportationDataSearchWindowCommand { get; }

        public RelayCommand<IClosableWindow> GoToSalesDataInputWindowCommand { get; }

        public RelayCommand<IClosableWindow> GoToSalesDataSearchWindowCommand { get; }

        /// <summary>
        /// go to input transportation data.
        /// </summary>
        private void GoToTransportationDataInputWindow(IClosableWindow closableWindow)
        {
            var transportationDataInputView = new TransportationDataInputView();
            transportationDataInputView.Show();
            closableWindow?.Close();
        }

        /// <summary>
        /// go to search transportation data.
        /// </summary>
        private void GoToTransportationDataSearchWindow(IClosableWindow closableWindow)
        {
            var transportationDataSearchView = new TransportationDataSearchView();
            transportationDataSearchView.Show();
            closableWindow?.Close();
        }

        private void GoToSalesDataInputWindow(IClosableWindow closableWindow)
        {
            _salesDataInputWindowFactory?.CreateWindow();
            closableWindow?.Close();
        }

        /// <summary>
        /// Go to search sales data.
        /// </summary>
        private void GoToSalesDataSearchWindow(IClosableWindow closableWindow)
        {
            _salesDataSearchWindowFactory.CreateWindow();
            closableWindow.Close();
        }
    }
}
