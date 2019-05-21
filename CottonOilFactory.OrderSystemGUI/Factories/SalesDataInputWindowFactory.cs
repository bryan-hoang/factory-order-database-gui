using CottonOilFactory.OrderSystemGUI.ViewModels.SalesData;
using CottonOilFactory.OrderSystemGUI.Views.SalesData;

namespace CottonOilFactory.OrderSystemGUI.Factories
{
    public class SalesDataInputWindowFactory : AbstractWindowFactory
    {
        public override void CreateWindow()
        {
            var salesDataInputView = new SalesDataInputView
            {
                DataContext = new SalesDataInputViewModel(new MainWindowFactory(), new SalesDataConfirmWindowFactory())
            };
            salesDataInputView.Show();
        }
    }
}
