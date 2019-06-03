using CottonOilFactory.OrderSystemGUI.ViewModels;
using CottonOilFactory.OrderSystemGUI.Views;

namespace CottonOilFactory.OrderSystemGUI.Factories
{
    public class MainWindowFactory : AbstractWindowFactory
    {
        public override void CreateWindow()
        {
            var main = new MainWindow
            {
                DataContext = new MainWindowViewModel(new SalesDataInputWindowFactory(), new SalesDataSearchWindowFactory())
            };
            main.Show();
        }
    }
}
