using CottonOilFactory.OrderGUI.ViewModels;
using CottonOilFactory.OrderGUI.Views;

namespace CottonOilFactory.OrderGUI.Factories
{
    public class MainWindowFactory : AbstractWindowFactory
    {
        public override void CreateWindow()
        {
            MainWindow mainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(new SalesDataInputWindowFactory(), new SalesDataSearchWindowFactory())
            };
            mainWindow.Show();
        }
    }
}
