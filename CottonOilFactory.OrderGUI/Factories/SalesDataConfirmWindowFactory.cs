using CottonOilFactory.OrderGUI.BaseClasses;
using CottonOilFactory.OrderGUI.Models;
using CottonOilFactory.OrderGUI.ViewModels.SalesData;
using CottonOilFactory.OrderGUI.Views.SalesData;

namespace CottonOilFactory.OrderGUI.Factories
{
    public class SalesDataConfirmWindowFactory : AbstractWindowFactory
    {
        public override void CreateWindow(ModelBase modelBase)
        {
            SalesDataConfirmView salesDataConfirmView = new SalesDataConfirmView
            {
                DataContext = new SalesDataConfirmViewModel((SalesDataModel)modelBase)
            };
            salesDataConfirmView.ShowDialog();
        }
    }
}
