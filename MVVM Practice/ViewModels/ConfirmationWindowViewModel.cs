using System;
using MVVM_Practice.ViewModels.Commands;

namespace MVVM_Practice.ViewModels
{
    public class ConfirmationWindowViewModel
    {
        public GoToHomeScreen GoToHomeScreen { get; set; }

        public ConfirmationWindowViewModel()
        {
            this.GoToHomeScreen = new GoToHomeScreen();
        }
    }
}