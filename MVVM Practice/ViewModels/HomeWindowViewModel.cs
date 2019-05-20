using System;
using MVVM_Practice.ViewModels.Commands;
using MVVM_Practice.Models;
using MVVM_Practice.PropertyChanged;

namespace MVVM_Practice.ViewModels
{
    public class HomeWindowViewModel : PropertyInterface 
    {
        public ProjectDataModel pj;

        public GoToConfirmationWindow NextWindow { get; set; }

        public Boolean GoToConfirmationWindow
        {
            get => pj.Status;
        }

        public string NameText
        {
            get
            {
                return pj.NameText;
            }
            set
            {
                pj.NameText = value;
            }
        }

        public string DecimalText
        {
            get
            {
                return pj.DecimalText;
            }
            set
            {
                pj.DecimalText = value;
                OnPropertyChanged("GoToConfirmationWindow");
            }
        }

        public DateTime DateText
        {
            get
            {
                return pj.DateText;
            }
            set
            {
                pj.DateText = value;
            }
        }

        public HomeWindowViewModel()
        {
            this.pj = new ProjectDataModel();
            this.NextWindow = new GoToConfirmationWindow(this);
        }
    }
}