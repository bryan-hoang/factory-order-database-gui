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
        // this is the field stuff
        private string nameofseller;
        private string truckingcompany;
        private string weight;
        private string numberofbags;
        private string shipmentnumber;
        private string dateofarrival;

        public string NameofSeller
        {
            get {return nameofseller; }
            set
            {
                if (value == null)
                    return;
                nameofseller = value;
                OnPropertyChanged("NameofSeller");
            }
        }

        public string TruckingCompany
        {
            get { return truckingcompany; }
            set
            {
                if (value == null)
                    return;
                truckingcompany = value;
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

        public string NumberofBags
        {
            get { return numberofbags; }
            set
            {
                if (value == null)
                    return;
                numberofbags = value;
                OnPropertyChanged("NumberofBags");
            }
        }

        public string ShipmentNumber
        {
            get { return shipmentnumber; }
            set
            {
                if (value == null)
                    return;
                shipmentnumber = value;
                OnPropertyChanged("ShipmentNumber");
            }
        }

        public string DateofArrival
        {
            get { return dateofarrival; }
            set
            {
                if (value == null)
                    return;
                dateofarrival = value;
                OnPropertyChanged("DateofArrival");
            }
        }

        // this is the arithmetic portion
        private string price;
        private string freightCharges;
        
        public string Price
        {
            get { return price; }
            set
            {
                if (value == null)
                    return;
                int number;
                bool res = int.TryParse(value, out number);
                if (res) price = value;
                OnPropertyChanged("Price");
                OnPropertyChanged("Result");
            }
        }

        public string FreightCharges
        {
            get { return freightCharges; }
            set
            {
                if (value == null)
                    return;
                int number;
                bool res = int.TryParse(value, out number);
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
