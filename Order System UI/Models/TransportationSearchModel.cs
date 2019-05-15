using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order_System_UI.LINQ_SQL_Connection;

namespace Order_System_UI.Models
{
    public class TransportationSearchModel : EventClass
    {
        // declare private fields
        private string truckCompanyName;
        private string sellerName;
        private string dateofArrival;
        private string netCosts;
        private bool tableStatus;
        public TransportationDataLog1 del;

        /// <summary>
        /// Searches the truck company name in the database.
        /// </summary>
        public string TruckCompanyName
        {
            get => truckCompanyName;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    tableStatus = false;
                truckCompanyName = value;
                OnPropertyChanged("TruckCompanyName");
                OnPropertyChanged("DataTable");
            }
        }

        /// <summary>
        /// Searches the seller name in the database.
        /// </summary>
        public string SellerName
        {
            get
            {
                OnPropertyChanged(nameof(DataTable));
                return sellerName;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    tableStatus = false;
                sellerName = value;
                OnPropertyChanged("SellerName");
                OnPropertyChanged("DataTable");
            }
        }

        /// <summary>
        /// Searches the date of arrival in the database.
        /// </summary>
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
                if (!string.IsNullOrWhiteSpace(value))
                    tableStatus = false;
                dateofArrival = value;
                OnPropertyChanged("DateofArrival");
                OnPropertyChanged("DataTable");
            }
        }

        /// <summary>
        /// Gets or Sets the year to display the net costs.
        /// </summary>
        public string NetCosts
        {
            get => netCosts;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    tableStatus = false;
                }
                netCosts = value;
                OnPropertyChanged("NetCosts");
                OnPropertyChanged("DeleteStatus");
                OnPropertyChanged("ButtonStatus");
                OnPropertyChanged("TextStatus");
            }
        }

        /// <summary>
        /// Gets a value indicating whether the NetCost is an integer.
        /// </summary>
        public bool ButtonStatus
        {
            get
            {
                if (int.TryParse(netCosts, out int a))
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Gets the status if an integer was entered in the textbox.
        /// </summary>
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

        /// <summary>
        /// Sets a value indicating whether a row has been selected.
        /// </summary>
        public object TableStatus
        {
            set
            {
                if (value == null)
                {
                    OnPropertyChanged("DeleteStatus");
                    return;
                }// end if
                //del = value;
                tableStatus = true;
                OnPropertyChanged("DeleteStatus");
            }
        }

        /// <summary>
        /// Gets a value indicating whether the button should be enabled.
        /// </summary>
        public bool DeleteStatus
        {
            get => tableStatus;
        }

        /// <summary>
        /// Gets the data from the database into a list being data binded to the data grid also manipluating searches.
        /// </summary>
        public List<TransportationDataLog1> DataTable
        {
            get
            {
                LINQSQLConnection connect = new LINQSQLConnection();
                TransportLinkDataContext datacontext = connect.DataContext;
                List<TransportationDataLog1> tableData = connect.TableData;
                var list = connect.List;

                if (del != null)
                {
                    TransportationDataLog1 tt = (Order_System_UI.TransportationDataLog1)del;
                    datacontext.TransportationDataLog1s.Attach(tt);
                    datacontext.TransportationDataLog1s.DeleteOnSubmit(tt);
                    datacontext.SubmitChanges();
                }// end if

                if (string.IsNullOrWhiteSpace(sellerName) && string.IsNullOrWhiteSpace(truckCompanyName) && string.IsNullOrWhiteSpace(DateofArrival))
                {
                    foreach (TransportationDataLog1 c in list)
                    {
                        if (c != del)
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