using System.Configuration;
using System.Data.Linq;

namespace CottonOilFactory.OrderSystemGUI.Database
{
    public class LinqToSqlConnection
    {
        public LinqToSqlConnection()
        {
            string connectionString = ConfigurationManager
                .ConnectionStrings["CottonOilFactory.OrderGUI.Properties.Settings.CottonFactoryOrderInformationConnectionString"]
                .ConnectionString;
            DataClassesDataContext = new DataClassesDataContext(connectionString);
            TransportationDatumTable = DataClassesDataContext.TransportationDatums;
            SalesDatumTable = DataClassesDataContext.SalesDatums;
        }

        public DataClassesDataContext DataClassesDataContext { get; }

        public Table<TransportationDatum> TransportationDatumTable { get; }

        public Table<SalesDatum> SalesDatumTable { get; }

    }
}
