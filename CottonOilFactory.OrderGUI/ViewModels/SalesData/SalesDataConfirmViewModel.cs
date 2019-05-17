using System;
using CottonOilFactory.OrderGUI.BaseClasses;
using CottonOilFactory.OrderGUI.Interfaces;
using CottonOilFactory.OrderGUI.Models;
using GalaSoft.MvvmLight.CommandWpf;

namespace CottonOilFactory.OrderGUI.ViewModels.SalesData
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

        public RelayCommand<IClosableWindow> GoBackToSalesInputWindowCommand { get; }

        public RelayCommand InsertSalesDataCommand { get; }

        public string WeightPerBag => ((int)SalesDataModel.WeightPerBag).ToString();

        public string PaymentMethod => SalesDataModel.PaymentMethod == Models.MethodOfPayment.Cash ? "Cash" : "Debit";

        private void GoBackToSalesInputWindow(IClosableWindow closableWindow)
        {
            closableWindow?.Close();
        }

        private void InsertSalesData()
        {
            throw new NotImplementedException();
        }
    }
}
