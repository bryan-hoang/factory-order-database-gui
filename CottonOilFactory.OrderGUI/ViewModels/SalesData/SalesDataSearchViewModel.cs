using System;
using CottonOilFactory.OrderGUI.BaseClasses;
using CottonOilFactory.OrderGUI.Factories;
using GalaSoft.MvvmLight.CommandWpf;

namespace CottonOilFactory.OrderGUI.ViewModels.SalesData
{
    public class SalesDataSearchViewModel : AbstractBackToMainWindowViewModel
    {
        private string buyerName;

        public SalesDataSearchViewModel(AbstractWindowFactory mainWindowFactory)
            : base(mainWindowFactory)
        {
            DisplayTheSelectedYearsDataCommand = new RelayCommand(DisplayTheSelectedYearsData);
        }

        public RelayCommand DisplayTheSelectedYearsDataCommand { get; set; }

        public string BuyerName
        {
            get => buyerName;
            set => buyerName = string.IsNullOrWhiteSpace(value) ? string.Empty : value;
        }

        public DateTime? DateOfSale { get; set; }

        public DateTime? YearOfDataToDisplay { get; set; }

        private void DisplayTheSelectedYearsData()
        {
            throw new NotImplementedException();
        }

    }
}
