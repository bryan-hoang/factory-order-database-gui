using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using CottonOilFactory.OrderSystemGUI.Database;
using CottonOilFactory.OrderSystemGUI.Factories;
using CottonOilFactory.OrderSystemGUI.Models.SalesData;
using GalaSoft.MvvmLight.CommandWpf;

namespace CottonOilFactory.OrderSystemGUI.ViewModels.SalesData
{
    public class SalesDataSearchViewModel : AbstractBackToMainWindowViewModel
    {
        private string _yearOfDataToDisplay;
        private string _dateOfSale;

        public SalesDataSearchViewModel(AbstractWindowFactory mainWindowFactory)
            : base(mainWindowFactory)
        {
            SalesDataModel = new SalesDataModel();
            DisplayTheSelectedYearsDataCommand = new RelayCommand(DisplayTheSelectedYearsData);
            DeleteSelectedRowCommand = new RelayCommand(DeleteSelectedSalesDatum);
        }

        public SalesDataModel SalesDataModel { get; }

        public string BuyerName
        {
            get => SalesDataModel.BuyerName;
            set
            {
                SalesDataModel.BuyerName = value;
                OnPropertyChanged(nameof(SalesDatumsToDisplay));
            }
        }

        public DateTime? DateOfSale
        {
            get => SalesDataModel.DateOfSale;
            set
            {
                SalesDataModel.DateOfSale = value;
                _dateOfSale = value?.ToString("yyyy-MM-dd");
                OnPropertyChanged(nameof(SalesDatumsToDisplay));
            }
        }

        public IEnumerable<SalesDatum> SalesDatumsToDisplay
        {
            get
            {
                var linqToSqlConnection = new LinqToSqlConnection();

                IEnumerable<SalesDatum> salesDatumsToDisplay =

                    from salesDatum in linqToSqlConnection.SalesDatumTable
                    where (salesDatum.Name_of_Buyer.Contains(BuyerName) || string.IsNullOrEmpty(BuyerName))
                          &&
                          (salesDatum.Date_of_Sale.Equals(_dateOfSale) || _dateOfSale == null)
                    select salesDatum;

                return salesDatumsToDisplay;
            }
        }

        public string YearOfDataToDisplay
        {
            get => _yearOfDataToDisplay;
            set
            {
                if (value == string.Empty || int.TryParse(value, out _))
                {
                    _yearOfDataToDisplay = value;
                }
            }
        }

        public SalesDatum SelectedSalesDatum { get; set; }

        public RelayCommand DisplayTheSelectedYearsDataCommand { get; }

        public RelayCommand DeleteSelectedRowCommand { get; }

        private void DisplayTheSelectedYearsData()
        {
            if (string.IsNullOrEmpty(_yearOfDataToDisplay))
            {
                MessageBox.Show("No year has been selected yet!");
                return;
            }

            var linqToSqlConnection = new LinqToSqlConnection();
            var selectedYearsData =
                from salesDatum in linqToSqlConnection.SalesDatumTable
                where salesDatum.Date_of_Sale.Substring(0, 4) == YearOfDataToDisplay
                select salesDatum;

            if (!selectedYearsData.Any())
            {
                MessageBox.Show("No data with the selected year of " + _yearOfDataToDisplay + " was found.");
                return;
            }

            decimal totalNumberOfBagsForSelectedYear = 0;
            decimal totalCostForSelectedYear = 0;
            foreach (var salesDatum in selectedYearsData)
            {
                totalNumberOfBagsForSelectedYear += decimal.Parse(salesDatum.Number_of_Bags);
                totalCostForSelectedYear += decimal.Parse(salesDatum.Total_Cost);
            }
            MessageBox.Show("Summary of " + YearOfDataToDisplay + " Sales Data:\n"
                            + "Total Number of Bags sold = " + totalNumberOfBagsForSelectedYear + "\n"
                            + "Total Cost = " + totalCostForSelectedYear);
        }

        private void DeleteSelectedSalesDatum()
        {
            if (SelectedSalesDatum == null)
            {
                MessageBox.Show("No row to delete has been selected!");
                return;
            }
            var linqToSqlConnection = new LinqToSqlConnection();
            linqToSqlConnection.DataClassesDataContext.SalesDatums.Attach(SelectedSalesDatum);
            linqToSqlConnection.DataClassesDataContext.SalesDatums.DeleteOnSubmit(SelectedSalesDatum);
            linqToSqlConnection.DataClassesDataContext.SubmitChanges();
            OnPropertyChanged(nameof(SalesDatumsToDisplay));
        }
    }
}
