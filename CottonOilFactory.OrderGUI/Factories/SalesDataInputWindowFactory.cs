using CottonOilFactory.OrderGUI.ViewModels.SalesData;
using CottonOilFactory.OrderGUI.Views.SalesData;

namespace CottonOilFactory.OrderGUI.Factories
{
    public class SalesDataInputWindowFactory : AbstractWindowFactory
    {
        public override void CreateWindow()
        {
            SalesDataInputView salesDataInputView = new SalesDataInputView
            {
                DataContext = new SalesDataInputViewModel(new MainWindowFactory(), new SalesDataConfirmWindowFactory())
            };
            salesDataInputView.Show();
        }
    }
}
