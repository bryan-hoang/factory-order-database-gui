using CottonOilFactory.OrderGUI.ViewModels;
using CottonOilFactory.OrderGUI.Views;

namespace CottonOilFactory.OrderGUI.Factories
{
    public class MainWindowFactory : AbstractWindowFactory
    {
        public override void CreateWindow()
        {
            Main main = new Main
            {
                DataContext = new MainWindowViewModel(new SalesDataInputWindowFactory(), new SalesDataSearchWindowFactory())
            };
            main.Show();
        }
    }
}
