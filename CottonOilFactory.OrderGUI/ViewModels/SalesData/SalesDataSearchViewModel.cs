using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using CottonOilFactory.OrderGUI.BaseClasses;
using CottonOilFactory.OrderGUI.Database;
using CottonOilFactory.OrderGUI.Factories;
using CottonOilFactory.OrderGUI.Models;
using CottonOilFactory.OrderGUI.Views.SalesData;
using GalaSoft.MvvmLight.CommandWpf;

namespace CottonOilFactory.OrderGUI.ViewModels.SalesData
{
    public class SalesDataSearchViewModel : AbstractBackToMainWindowViewModel
    {
        private string yearOfDataToDisplay;
        private string dateOfSale;

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
                dateOfSale = value?.ToString("yyyy-MM-dd");
                OnPropertyChanged(nameof(SalesDatumsToDisplay));
            }
        }

        public IEnumerable<SalesDatum> SalesDatumsToDisplay
        {
            get
            {
                LinqToSqlConnection linqToSqlConnection = new LinqToSqlConnection();

                IEnumerable<SalesDatum> salesDatumsToDisplay =

                    from salesDatum in linqToSqlConnection.SalesDatumTable
                    where (salesDatum.Name_of_Buyer.Contains(BuyerName) || string.IsNullOrEmpty(BuyerName))
                          &&
                          (salesDatum.Date_of_Sale.Equals(dateOfSale) || dateOfSale == null)
                    select salesDatum;

                return salesDatumsToDisplay;
            }
        }

        public string YearOfDataToDisplay
        {
            get => yearOfDataToDisplay;
            set
            {
                if (value == string.Empty || int.TryParse(value, out _))
                {
                    yearOfDataToDisplay = value;
                }
            }
        }

        public SalesDatum SelectedSalesDatum { get; set; }

        public RelayCommand DisplayTheSelectedYearsDataCommand { get; }

        public RelayCommand DeleteSelectedRowCommand { get; }

        private void DisplayTheSelectedYearsData()
        {
            if (string.IsNullOrEmpty(yearOfDataToDisplay))
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
                MessageBox.Show("No data with the selected year of " + yearOfDataToDisplay + " was found.");
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
            LinqToSqlConnection linqToSqlConnection = new LinqToSqlConnection();
            linqToSqlConnection.DataClassesDataContext.SalesDatums.Attach(SelectedSalesDatum);
            linqToSqlConnection.DataClassesDataContext.SalesDatums.DeleteOnSubmit(SelectedSalesDatum);
            linqToSqlConnection.DataClassesDataContext.SubmitChanges();
            OnPropertyChanged(nameof(SalesDatumsToDisplay));
        }

    }
}
