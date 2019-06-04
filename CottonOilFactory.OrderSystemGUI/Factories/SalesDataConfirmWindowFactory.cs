using CottonOilFactory.OrderSystemGUI.Models;
using CottonOilFactory.OrderSystemGUI.Models.SalesData;
using CottonOilFactory.OrderSystemGUI.ViewModels.SalesData;
using CottonOilFactory.OrderSystemGUI.Views.SalesData;

namespace CottonOilFactory.OrderSystemGUI.Factories
{
    public class SalesDataConfirmWindowFactory : AbstractWindowFactory
    {
        public override void CreateWindow(ModelBase modelBase)
        {
            var salesDataConfirmView = new SalesDataConfirmView
            {
                DataContext = new SalesDataConfirmViewModel((SalesDataModel)modelBase)
            };
            salesDataConfirmView.ShowDialog();
        }
    }
}
