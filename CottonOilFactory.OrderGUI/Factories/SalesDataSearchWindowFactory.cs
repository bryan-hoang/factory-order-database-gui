using System.Windows.Controls;
using CottonOilFactory.OrderGUI.ViewModels.SalesData;
using CottonOilFactory.OrderGUI.Views.SalesData;

namespace CottonOilFactory.OrderGUI.Factories
{
    public class SalesDataSearchWindowFactory : AbstractWindowFactory
    {
        public override void CreateWindow()
        {
            SalesDataSearchView salesDataSearchView = new SalesDataSearchView
            {
                DataContext = new SalesDataSearchViewModel(new MainWindowFactory())
            };
            salesDataSearchView.Show();
        }
    }
}
