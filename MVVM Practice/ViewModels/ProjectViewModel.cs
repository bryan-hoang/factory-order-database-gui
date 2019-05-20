using System;
using MVVM_Practice.ViewModels.Commands;
using MVVM_Practice.Models;
using MVVM_Practice.PropertyChanged;

namespace MVVM_Practice.ViewModels
{
    public class ProjectViewModel : PropertyInterface 
    {
        private string decimaltext;

        public GoToConfirmationWindow GoToConfirmationWindow { set; get; }

        public DateTime DateText { get; set; }

        public string NameText { get; set; }


        public bool Status
        {
            get
            {
                if (string.IsNullOrEmpty(decimaltext))
                {
                    return false;
                }
                return true;
            }
        }

        public string DecimalText
        {
            get => decimaltext;
            set
            {
                if (!decimal.TryParse(value, out decimal c))
                {
                    decimaltext = null;
                }
                else
                {
                     decimaltext = value;
                }
                OnPropertyChanged("Status");
                OnPropertyChanged("GoToConfirmationWindow");
            }
        }

        public ProjectViewModel()
        {
            this.GoToConfirmationWindow = new GoToConfirmationWindow(this);
        }
    }
}