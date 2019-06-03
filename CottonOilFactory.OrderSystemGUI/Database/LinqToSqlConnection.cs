using System;
using System.Configuration;
using System.Data.Linq;

namespace CottonOilFactory.OrderSystemGUI.Database
{
    public class LinqToSqlConnection : IDisposable
    {
        public LinqToSqlConnection()
        {
            string connectionString = ConfigurationManager
                .ConnectionStrings["CottonOilFactory.OrderSystemGUI.Properties.Settings.CottonFactoryOrderInformationConnectionString1"]
                .ConnectionString;
            DataClassesDataContext = new DataClassesDataContext(connectionString);
            TransportationDatumTable = DataClassesDataContext.TransportationDatums;
            SalesDatumTable = DataClassesDataContext.SalesDatums;
        }

        public DataClassesDataContext DataClassesDataContext { get; }

        public Table<TransportationDatum> TransportationDatumTable { get; }

        public Table<SalesDatum> SalesDatumTable { get; }

        public void Dispose()
        {
            DataClassesDataContext.Dispose();
        }
    }
}
