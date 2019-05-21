using CottonOilFactory.OrderSystemGUI.ViewModels.SalesData;
using CottonOilFactory.OrderSystemGUI.Views.SalesData;

namespace CottonOilFactory.OrderSystemGUI.Factories
{
    public class SalesDataSearchWindowFactory : AbstractWindowFactory
    {
        public override void CreateWindow()
        {
            var salesDataSearchView = new SalesDataSearchView
            {
                DataContext = new SalesDataSearchViewModel(new MainWindowFactory())
            };
            salesDataSearchView.Show();
        }
    }
}
