using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_System_UI.Models
{
    public class TransportationSearchModel : EventClass
    {
        // declare LINQ attribute
        private TransportLinkDataContext datacontext;

        // declare private fields
        private string truckCompanyName;
        private string sellerName;
        private string dateofArrival;
        private string netCosts;

        public string TruckCompanyName
        {
            get => truckCompanyName;
            set
            {
                truckCompanyName = value;
                OnPropertyChanged("TruckCompanyName");
                OnPropertyChanged("DataTable");
            }
        }

        public string SellerName
        {
            get => sellerName;
            set
            {
                sellerName = value;
                OnPropertyChanged("SellerName");
                OnPropertyChanged("DataTable");
            }
        }

        public string DateofArrival
        {
            get
            {
                if (dateofArrival == null)
                    return null;
                string[] spiltDate = dateofArrival.Split();
                return spiltDate[0];
            }

            set
            {
                dateofArrival = value;
                OnPropertyChanged("DateofArrival");
                OnPropertyChanged("DataTable");
            }
        }

        public string NetCosts
        {
            get => netCosts;
            set
            {
                netCosts = value;
                OnPropertyChanged("NetCosts");
                OnPropertyChanged("ButtonStatus");
                OnPropertyChanged("TextStatus");
            }
        }

        public bool ButtonStatus
        {
            get
            {
                if (int.TryParse(netCosts, out int a))
                    return true;
                return false;
            }
        }

        public string TextStatus
        {
            get
            {
                if (netCosts == null)
                    return null;
                else if (int.TryParse(netCosts, out int a))
                    return null;
                return "Invalid Input";
            }
        }

        public List<TransportationDataLog1> DataTable
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Order_System_UI.Properties.Settings.modelConnectionString"].ConnectionString;
                datacontext = new TransportLinkDataContext(connectionString);
                List<TransportationDataLog1> tableData = new List<TransportationDataLog1>();
                var list = datacontext.TransportationDataLog1s;

                if (string.IsNullOrWhiteSpace(sellerName) && string.IsNullOrWhiteSpace(truckCompanyName) && string.IsNullOrWhiteSpace(DateofArrival))
                {
                    foreach (TransportationDataLog1 c in list)
                    {
                        tableData.Add(c);
                    }
                    return tableData;
                }// end if
                else if (string.IsNullOrWhiteSpace(truckCompanyName) && string.IsNullOrWhiteSpace(DateofArrival))
                {
                    foreach (TransportationDataLog1 c in list)
                    {
                        if (string.Equals(c.Name_of_Seller, sellerName, StringComparison.OrdinalIgnoreCase))
                            tableData.Add(c);
                    }
                    return tableData;
                }// end else if
                else if (string.IsNullOrWhiteSpace(sellerName) && string.IsNullOrWhiteSpace(DateofArrival))
                {
                    foreach (TransportationDataLog1 c in list)
                    {
                        if (string.Equals(c.Truck_Company, truckCompanyName, StringComparison.OrdinalIgnoreCase))
                            tableData.Add(c);
                    }
                    return tableData;
                }// end else if
                else if (string.IsNullOrWhiteSpace(sellerName) && string.IsNullOrWhiteSpace(truckCompanyName))
                {
                    foreach (TransportationDataLog1 c in list)
                    {
                        if (string.Equals(c.Date_of_Arrival, DateofArrival, StringComparison.OrdinalIgnoreCase))
                            tableData.Add(c);
                    }
                    return tableData;
                }// end else if
                else if (string.IsNullOrWhiteSpace(DateofArrival))
                {
                    foreach (TransportationDataLog1 c in list)
                    {
                        if (string.Equals(c.Name_of_Seller, sellerName, StringComparison.OrdinalIgnoreCase) && string.Equals(c.Truck_Company, truckCompanyName, StringComparison.OrdinalIgnoreCase))
                            tableData.Add(c);
                    }
                    return tableData;
                }// end else if
                else if (string.IsNullOrWhiteSpace(sellerName))
                {
                    foreach (TransportationDataLog1 c in list)
                    {
                        if (string.Equals(c.Truck_Company, truckCompanyName, StringComparison.OrdinalIgnoreCase) && string.Equals(c.Date_of_Arrival, DateofArrival, StringComparison.OrdinalIgnoreCase))
                            tableData.Add(c);
                    }
                    return tableData;
                }// end else if
                else if (string.IsNullOrWhiteSpace(truckCompanyName))
                {
                    foreach (TransportationDataLog1 c in list)
                    {
                        if (string.Equals(c.Name_of_Seller, sellerName, StringComparison.OrdinalIgnoreCase) && string.Equals(c.Date_of_Arrival, DateofArrival, StringComparison.OrdinalIgnoreCase))
                            tableData.Add(c);
                    }
                    return tableData;
                }// end else if
                else
                {
                    foreach (TransportationDataLog1 c in list)
                    {
                        if (string.Equals(c.Name_of_Seller, sellerName, StringComparison.OrdinalIgnoreCase) && string.Equals(c.Truck_Company, truckCompanyName, StringComparison.OrdinalIgnoreCase) && string.Equals(c.Date_of_Arrival, DateofArrival, StringComparison.OrdinalIgnoreCase))
                            tableData.Add(c);
                    }
                    return tableData;
                }// end else
            }
        }
    }// end class
}// end namespace