using CottonOilFactory.OrderSystemGUI.Factories;
using CottonOilFactory.OrderSystemGUI.Models.SalesData;
using GalaSoft.MvvmLight.CommandWpf;

namespace CottonOilFactory.OrderSystemGUI.ViewModels.SalesData
{
    public class SalesDataInputViewModel : AbstractBackToMainWindowViewModel
    {
        private readonly AbstractWindowFactory _saleDataConfirmWindowFactory;

        public SalesDataInputViewModel(AbstractWindowFactory mainWindowFactory, AbstractWindowFactory saleDataConfirmWindowFactory) 
            : base(mainWindowFactory)
        {
            _saleDataConfirmWindowFactory = saleDataConfirmWindowFactory;
            SalesDataModel = new SalesDataModel();
            ConfirmSalesDataCommand = new RelayCommand(ConfirmSalesData, canExecute: () => SalesDataModel.IsValidData);
        }

        public SalesDataModel SalesDataModel { get; }

        public RelayCommand ConfirmSalesDataCommand { get; }

        private void ConfirmSalesData()
        {
            _saleDataConfirmWindowFactory?.CreateWindow(SalesDataModel);
        }
    }
}
