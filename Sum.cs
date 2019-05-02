using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Order_System_UI
{
    public class Sum : INotifyPropertyChanged
    {
        private string num1;
        private string num2;
        private string result;

        public string Num1
        {
            get { return num1; }
            set
            {
                if (value == null)
                    return;
                int number;
                bool res = int.TryParse(value, out number);
                if (res) num1 = value;
                //OnPropertyChanged("Num1");
                OnPropertyChanged("Result");
            }
        }

        public string Num2
        {
            get { return num2; }
            set
            {
                if (value == null)
                    return;
                int number;
                bool res = int.TryParse(value, out number);
                if (res) num2 = value;
                //OnPropertyChanged("Num2");
                OnPropertyChanged("Result");
            }
        }

        public string Result
        {
            get
            {
                if (Num1 == null || Num2 == null)
                    return null;
                int res = int.Parse(Num1) + int.Parse(Num2);
                return res.ToString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}// end namespace
