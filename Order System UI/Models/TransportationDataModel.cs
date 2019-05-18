using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace Order_System_UI.Models
{
    /// <inheritdoc />
    public class TransportationDataModel : EventClass
    {
        // This is the string portion of the U.I
        private string seller;
        private string truckingCompany;
        private bool isIsBadQuality;
        private bool isMediumQuality = true;
        private bool isGoodQuality;
        private string weight;
        private string price;
        private string numberOfBags;
        private string freightCharges;
        private string shipmentNumber;
        private string dateOfArrival;
        // This is the status portion of the U.I
        private string status;
        private int count;

        /// <summary>
        /// Gets or sets the name of seller of the cotton seeds.
        /// </summary>
        public string Seller
        {
            get => seller;
            set
            {
                seller = value;
                OnPropertyChanged("ButtonStatus");
            }
        }

        /// <summary>
        /// Gets or sets the name of the trucking company transporting the cotton seeds.
        /// </summary>
        public string TruckingCompany
        {
            get => truckingCompany;
            set
            {
                truckingCompany = value;
                OnPropertyChanged("TruckingCompany");
                OnPropertyChanged("ButtonStatus");
            }
        }

        /// <summary>
        /// Gets the quality from the radio buttons.
        /// </summary>
        public string Quality
        {
            get
            {
                if (isIsBadQuality)
                {
                    return "Bad";
                }
                return isMediumQuality ? "Medium" : "Good";
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether checks if the quality is bad.
        /// </summary>
        public bool IsBadQuality
        {
            get => isIsBadQuality;
            set
            {
                isIsBadQuality = value;
                OnPropertyChanged("ButtonStatus");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether checks if the quality is medium.
        /// </summary>
        public bool IsMediumQuality
        {
            get => isMediumQuality;
            set
            {
                isMediumQuality = value;
                OnPropertyChanged("ButtonStatus");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether checks if the quality is good.
        /// </summary>
        public bool IsGoodQuality
        {
            get => isGoodQuality;
            set
            {
                isGoodQuality = value;
                OnPropertyChanged("ButtonStatus");
            }
        }

        /// <summary>
        /// Gets or sets the total weight per truck.
        /// </summary>
        public string Weight
        {
            get => weight;
            set
            {
                if (decimal.TryParse(value, result: out decimal kg) && kg > 0.0M)
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
        /// Gets or sets the number of bags per truck.
        /// </summary>
        public string NumberOfBags
        {
            get => numberOfBags;
            set
            {
                if (int.TryParse(value, out int num) && num > 0)
                {
                    StatusEvent(true);
                    numberOfBags = value;
                    OnPropertyChanged("NumberOfBags");
                }// end else if
                else
                {
                    StatusEvent(false);
                    numberOfBags = null;
                }

                OnPropertyChanged("ButtonStatus");
            }
        }

        /// <summary>
        /// Gets or sets the shipment number.
        /// </summary>
        public string ShipmentNumber
        {
            get => shipmentNumber;
            set
            {
                if (int.TryParse(value, out int shipNum) && shipNum > 0)
                {
                    StatusEvent(true);
                    shipmentNumber = value;
                    OnPropertyChanged("ShipmentNumber");
                }// end else if
                else
                {
                    StatusEvent(false);
                    shipmentNumber = null;
                }// end else

                OnPropertyChanged("ButtonStatus");
            }
        }

        /// <summary>
        /// Gets or sets the date of arrival of the truck.
        /// </summary>
        public string DateOfArrival
        {
            get
            {
                if (dateOfArrival == null)
                {
                    return null;
                }// end if
                string[] spiltDate = dateOfArrival.Split();
                return spiltDate[0];
            }

            set
            {
                dateOfArrival = value;
                OnPropertyChanged("ButtonStatus");
            }
        }

        // This is the arithmetic portion of the U.I

        /// <summary>
        /// Gets or sets the price of the cotton seeds.
        /// </summary>
        public string Price
        {
            get => price;
            set
            {
                if (decimal.TryParse(value, out decimal cost) && cost >= 0)
                {
                    price = value;
                    StatusEvent(true);
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
        /// Gets or sets the cost from the truck company.
        /// </summary>
        public string FreightCharges
        {
            get => freightCharges;
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
        /// Gets the total cost (freight charges + cotton seed cost).
        /// </summary>
        public string Result
        {
            get
            {
                if (FreightCharges == null || Price == null)
                {
                    return null;
                }
                var res = decimal.Parse(FreightCharges) + decimal.Parse(Price);
                return res.ToString();
            }
        }

        /// <summary>
        /// Gets the text for the status bar in the U.I.
        /// </summary>
        public string Status
        {
            get
            {
                status = count == 0 ? string.Empty : "Invalid input";

                return status;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the confirm button is enabled.
        /// </summary>
        public bool ButtonStatus => !string.IsNullOrWhiteSpace(seller)
                                    && !string.IsNullOrWhiteSpace(truckingCompany)
                                    && !string.IsNullOrWhiteSpace(weight)
                                    && !string.IsNullOrWhiteSpace(price)
                                    && !string.IsNullOrWhiteSpace(numberOfBags)
                                    && !string.IsNullOrWhiteSpace(shipmentNumber)
                                    && !string.IsNullOrWhiteSpace(freightCharges)
                                    && !string.IsNullOrWhiteSpace(dateOfArrival);

        /// <summary>
        /// Method to deal with status text.
        /// </summary>
        /// <param name="check">bool value to change count number. </param>
        private void StatusEvent(bool check)
        {
            if (check)
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
        }// end property
    }// end class
}// end namespace
