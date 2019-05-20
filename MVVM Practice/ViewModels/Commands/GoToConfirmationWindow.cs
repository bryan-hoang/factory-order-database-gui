using System;
using MVVM_Practice.Views;
using MVVM_Practice.PropertyChanged;
using System.Windows.Input;

namespace MVVM_Practice.ViewModels.Commands
{
    public class GoToConfirmationWindow : ICommand 
    {
        private readonly ProjectViewModel viewmd;

        public GoToConfirmationWindow(ProjectViewModel viewmd)
        {
            this.viewmd = viewmd;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return viewmd.Status;
        }

        public void Execute(object parameter)
        {
            HomeWindowView hmWin = (HomeWindowView)parameter;
            ConfirmationWindowView confirmWin = new ConfirmationWindowView(this.viewmd);
            confirmWin.ShowDialog();
        }
    }
}