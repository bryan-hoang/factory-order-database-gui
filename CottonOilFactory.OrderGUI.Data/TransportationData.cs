using System.ComponentModel;

namespace CottonOilFactory.OrderGUI.Data
{
    public class TransportationData : INotifyPropertyChanged
    {
        private string nameOfSeller;
        private string truckingCompany;
        private string weight;
        private string numberOfBags;
        private string shipmentNumber;
        private string dateOfArrival;

        public string NameofSeller
        {
            get => nameOfSeller;
            set
            {
                if (value == null)
                    return;
                nameOfSeller = value;
                OnPropertyChanged("NameofSeller");
            }
        }

        public string TruckingCompany
        {
            get => truckingCompany;
            set
            {
                if (value == null)
                    return;
                truckingCompany = value;
                OnPropertyChanged("TruckingCompany");
            }
        }

        public string Weight
        {
            get { return weight; }
            set
            {
                if (value == null)
                    return;
                weight = value;
                OnPropertyChanged("Weight");
            }
        }

        public string NumberOfBags
        {
            get => numberOfBags;
            set
            {
                if (value == null)
                    return;
                numberOfBags = value;
                OnPropertyChanged("NumberOfBags");
            }
        }

        public string ShipmentNumber
        {
            get => shipmentNumber;
            set
            {
                if (value == null)
                    return;
                shipmentNumber = value;
                OnPropertyChanged("ShipmentNumber");
            }
        }

        public string DateOfArrival
        {
            get => dateOfArrival;
            set
            {
                if (value == null)
                    return;
                dateOfArrival = value;
                OnPropertyChanged("DateOfArrival");
            }
        }

        // this is the arithmetic portion
        private string price;
        private string freightCharges;
        
        public string Price
        {
            get => price;
            set
            {
                if (value == null)
                    return;
                bool res = int.TryParse(value, out _);
                if (res) price = value;
                OnPropertyChanged("Price");
                OnPropertyChanged("Result");
            }
        }

        public string FreightCharges
        {
            get => freightCharges;
            set
            {
                if (value == null)
                    return;
                bool res = int.TryParse(value, out _);
                if (res) freightCharges = value;
                OnPropertyChanged("FreightCharges");
                OnPropertyChanged("Result");
            }
        }

        public string Result
        {
            get
            {
                if (FreightCharges == null || Price == null)
                    return null;
                int res = int.Parse(FreightCharges) + int.Parse(Price);
                return res.ToString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}// end namespace
