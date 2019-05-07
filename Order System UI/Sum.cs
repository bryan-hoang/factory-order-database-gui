using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Order_System_UI
{
    public class DataCollection : INotifyPropertyChanged
    {

        // This is the radio button portion of the U.I
        private bool badQuality;
        private bool mediumQuality;
        private bool goodQuality = true;

        /// <summary>
        /// Gets the quality from the radio buttons
        /// </summary>
        public string Quality
        {
            get
            {
                if (badQuality == true)
                {
                    return "Bad";
                }// end if
                else if (mediumQuality == true)
                {
                    return "Medium";
                }// end else if
                else
                    return "Good";
            }
        }

        /// <summary>
        /// checks if the quality is bad
        /// </summary>
        public bool BadQuality
        {
            get
            {
                return badQuality;
            }
            set
            {
                badQuality = value;
                OnPropertyChanged("ButtonStatus");
            }
        }

        /// <summary>
        /// checks if the quality is medium
        /// </summary>
        public bool MediumQuality
        {
            get
            {
                return mediumQuality;
            }
            set
            {
                mediumQuality = value;
                OnPropertyChanged("ButtonStatus");
            }
        }

        /// <summary>
        /// checks if the quality is good
        /// </summary>
        public bool GoodQuality
        {
            get
            {
                return goodQuality;
            }
            set
            {
                goodQuality = value;
                OnPropertyChanged("ButtonStatus");
            }
        }

        // This is the string portion of the U.I

        private string nameofseller;
        private string truckingcompany;
        private string weight;
        private string numberofbags;
        private string shipmentnumber;
        private string dateofarrival;
        private string price;
        private string freightCharges;

        /// <summary>
        /// Gets/Sets the name of seller of the cotton seeds
        /// </summary>
        public string NameofSeller
        {
            get { return nameofseller; }
            set
            {
                nameofseller = value;
                OnPropertyChanged("NameofSeller");
                OnPropertyChanged("ButtonStatus");
            }
        }

        /// <summary>
        /// Gets/Sets the name of the trucking company transporting the cotton seeds
        /// </summary>
        public string TruckingCompany
        {
            get { return truckingcompany; }
            set
            {
                truckingcompany = value;
                OnPropertyChanged("TruckingCompany");
                OnPropertyChanged("ButtonStatus");
            }
        }

        /// <summary>
        /// Gets/Sets the total weight per truck
        /// </summary>
        public string Weight
        {
            get { return weight; }
            set
            {
                if (decimal.TryParse(value, out decimal kg) && kg > 0)
                {
                    StatusEvent(true);
                    weight = value;
                    OnPropertyChanged("Weight");
                }// end else if
                else
                {
                    StatusEvent(false);
                    weight = null;
                }
                OnPropertyChanged("ButtonStatus");
            }
        }

        /// <summary>
        /// Gets/Sets the number of bags per truck
        /// </summary>
        public string NumberofBags
        {
            get { return numberofbags; }
            set
            {
                if (int.TryParse(value, out int num) && num > 0)
                {
                    StatusEvent(true);
                    numberofbags = value;
                    OnPropertyChanged("NumberofBags");
                }// end else if
                else
                {
                    StatusEvent(false);
                    numberofbags = null;
                }
                OnPropertyChanged("ButtonStatus");
            }
        }

        /// <summary>
        /// Gets/Sets the shipment number
        /// </summary>
        public string ShipmentNumber
        {
            get { return shipmentnumber; }
            set
            {
                if (int.TryParse(value, out int shipNum) && shipNum > 0)
                {
                    StatusEvent(true);
                    shipmentnumber = value;
                    OnPropertyChanged("ShipmentNumber");
                }// end else if
                else
                { 
                    StatusEvent(false);
                    shipmentnumber = null;
                }// end else
                OnPropertyChanged("ButtonStatus");
            }
        }

        /// <summary>
        /// Gets/Sets the date of arrival of the truck
        /// </summary>
        public string DateofArrival
        {
            get
            {
                if (dateofarrival == null)
                    return null;
                string[] dateData = dateofarrival.Split();
                return dateData[0];
            }
            set
            {
                if (value == null)
                    return;
                dateofarrival = value;
                OnPropertyChanged("DateofArrival");
                OnPropertyChanged("ButtonStatus");
            }
        }

        // This is the arithmetic portion of the U.I

        /// <summary>
        /// Gets/Sets the price of the cotton seeds
        /// </summary>
        public string Price
        {
            get { return price; }
            set
            {
                if (decimal.TryParse(value, out decimal cost) && cost >= 0)
                {
                    price = value;
                    StatusEvent(true);
                    OnPropertyChanged("Price");
                    OnPropertyChanged("Result");
                    OnPropertyChanged("ButtonStatus");
                }// end else if
                else
                {
                    StatusEvent(false);
                    price = null;
                }// end else
                OnPropertyChanged("ButtonStatus");
            }
        }

        /// <summary>
        /// Gets/Sets the cost from the truck company
        /// </summary>
        public string FreightCharges
        {
            get { return freightCharges; }
            set
            {
                if (decimal.TryParse(value, out decimal cost) && cost >= 0)
                {
                    freightCharges = value;
                    StatusEvent(true);
                    OnPropertyChanged("FreightCharges");
                    OnPropertyChanged("Result");
                }// end else if
                else
                {
                    StatusEvent(false);
                    freightCharges = null;
                }// end else
                OnPropertyChanged("ButtonStatus");
            }
        }

        /// <summary>
        /// Gets/Sets the total cost (freight charges + cotton seed cost)
        /// </summary>
        public string Result
        {
            get
            {
                if (FreightCharges == null || Price == null)
                    return null;
                decimal res = decimal.Parse(FreightCharges) + decimal.Parse(Price);
                return res.ToString();
            }
        }

        // This is the status portion of the U.I

        private string status;
        private int count;

        /// <summary>
        /// Sets the text for the status bar in the U.I
        /// </summary>
        public string Status
        {
            get
            {
                if (count == 0)
                    status = "";
                else
                    status = "Invalid input";
                return status;
            }
        }

        /// <summary>
        /// Method to deal with status text
        /// </summary>
        /// <param name="check">bool value to change count number </param>
        void StatusEvent(bool check)
        {
            if (check == true)
            {
                count = 0;
                OnPropertyChanged("Status");
            }// end if
            else
            {
                count = 1;
                OnPropertyChanged("Status");
            }// end else
            OnPropertyChanged("ButtonStatus");
        }

        public bool ButtonStatus
        {
            get
            {
                if (nameofseller == null || truckingcompany == null || weight == null || numberofbags == null || shipmentnumber == null || dateofarrival == null || price == null || freightCharges == null)
                    return false;
                return true;
            }
        }
        
        // This is the event handler portion of the U.I

        public event PropertyChangedEventHandler PropertyChanged;

        
        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }// end class
}// end namespace
