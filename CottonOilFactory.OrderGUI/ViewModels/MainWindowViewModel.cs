using CottonOilFactory.OrderGUI.BaseClasses;
using CottonOilFactory.OrderGUI.Factories;
using CottonOilFactory.OrderGUI.Interfaces;
using CottonOilFactory.OrderGUI.Views.TransportationData;
using GalaSoft.MvvmLight.CommandWpf;

namespace CottonOilFactory.OrderGUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly AbstractWindowFactory salesDataInputWindowFactory;
        private readonly AbstractWindowFactory salesDataSearchWindowFactory;

        public MainWindowViewModel(AbstractWindowFactory salesDataInputWindowFactory, AbstractWindowFactory salesDataSearchWindowFactory)
        {
            this.salesDataInputWindowFactory = salesDataInputWindowFactory;
            this.salesDataSearchWindowFactory = salesDataSearchWindowFactory;
            GoToTransportationDataInputWindowCommand = new RelayCommand<IClosableWindow>(this.GoToTransportationDataInputWindow);
            GoToTransportationDataSearchWindowCommand = new RelayCommand<IClosableWindow>(this.GoToTransportationDataSearchWindow);
            GoToSalesDataInputWindowCommand = new RelayCommand<IClosableWindow>(this.GoToSalesDataInputWindow);
            GoToSalesDataSearchWindowCommand = new RelayCommand<IClosableWindow>(this.GoToSalesDataSearchWindow);
        }

        public RelayCommand<IClosableWindow> GoToTransportationDataInputWindowCommand { get; }

        public RelayCommand<IClosableWindow> GoToTransportationDataSearchWindowCommand { get; }

        public RelayCommand<IClosableWindow> GoToSalesDataInputWindowCommand { get; }

        public RelayCommand<IClosableWindow> GoToSalesDataSearchWindowCommand { get; }

        /// <summary>
        /// go to input transportation data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GoToTransportationDataInputWindow(IClosableWindow closableWindow)
        {
            var transportationDataInputView = new TransportationDataInputView();
            transportationDataInputView.Show();
            closableWindow?.Close();
        }

        /// <summary>
        /// go to search transportation data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GoToTransportationDataSearchWindow(IClosableWindow closableWindow)
        {
            var transportationDataSearchView = new TransportationDataSearchView();
            transportationDataSearchView.Show();
            closableWindow?.Close();
        }

        public void GoToSalesDataInputWindow(IClosableWindow closableWindow)
        {
            salesDataInputWindowFactory?.CreateWindow();
            closableWindow?.Close();
        }

        /// <summary>
        /// Go to search sales data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GoToSalesDataSearchWindow(IClosableWindow closableWindow)
        {
            salesDataSearchWindowFactory?.CreateWindow();
            closableWindow?.Close();
        }

    }
}
