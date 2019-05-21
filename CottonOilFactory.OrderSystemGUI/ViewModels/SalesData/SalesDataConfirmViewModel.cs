using System;
using System.Diagnostics;
using System.Windows;
using CottonOilFactory.OrderSystemGUI.Database;
using CottonOilFactory.OrderSystemGUI.Interfaces;
using CottonOilFactory.OrderSystemGUI.Models.SalesData;
using GalaSoft.MvvmLight.CommandWpf;

namespace CottonOilFactory.OrderSystemGUI.ViewModels.SalesData
{
    public class SalesDataConfirmViewModel : ViewModelBase
    {
        public SalesDataConfirmViewModel(SalesDataModel salesDataModel)
        {
            SalesDataModel = salesDataModel;
            GoBackToSalesInputWindowCommand = new RelayCommand<IClosableWindow>(GoBackToSalesInputWindow);
            InsertSalesDataCommand = new RelayCommand(InsertSalesData);
        }

        public SalesDataModel SalesDataModel { get; }

        public string WeightPerBag
        {
            get
            {
                Debug.Assert(SalesDataModel.WeightPerBag != null, "SalesDataModel.WeightPerBag != null");
                return ((int)SalesDataModel.WeightPerBag).ToString();
            }
        }

        public string PaymentMethod => SalesDataModel.PaymentMethod == MethodOfPayment.Cash ? "Cash" : "Debit";

        public RelayCommand<IClosableWindow> GoBackToSalesInputWindowCommand { get; }

        public RelayCommand InsertSalesDataCommand { get; }

        private static void GoBackToSalesInputWindow(IClosableWindow closableWindow)
        {
            closableWindow?.Close();
        }

        private void InsertSalesData()
        {
            var linqToSqlConnection = new LinqToSqlConnection();
            var dataClassesDataContext = linqToSqlConnection.DataClassesDataContext;
            try
            {
                var salesDatum = new SalesDatum()
                {
                    Name_of_Buyer = SalesDataModel.BuyerName,
                    Weight_per_Bag = SalesDataModel.WeightPerBag == BagWeight.Forty ? "40" : "57",
                    Price_per_Bag = SalesDataModel.PricePerBag,
                    Number_of_Bags = SalesDataModel.NumberOfBags,
                    Total_Cost = SalesDataModel.TotalCost,
                    Payment_Method = SalesDataModel.PaymentMethod == MethodOfPayment.Cash ? "Cash" : "Debit",
                    Date_of_Sale = SalesDataModel.DateOfSale?.ToString("yyyy/MM/dd")
                };
                dataClassesDataContext.SalesDatums.InsertOnSubmit(salesDatum);
                dataClassesDataContext.SubmitChanges();
                MessageBox.Show("The sales data has been successfully inserted!");
            }
            catch (Exception e)
            {
                MessageBox.Show("The sales data was unsuccessfully inserted.\nError: " + e.Message);
                throw;
            }
        }
    }
}
