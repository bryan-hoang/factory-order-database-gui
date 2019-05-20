using System;
using MVVM_Practice.Views;
using System.Windows.Input;

namespace MVVM_Practice.ViewModels.Commands
{
    public class GoToConfirmationWindow : ICommand
    {
        private HomeWindowViewModel hw;

        public GoToConfirmationWindow(HomeWindowViewModel hw)
        {
            this.hw = hw;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            HomeWindowView hmWin = (HomeWindowView)parameter;
            ConfirmationWindowView confirmWin = new ConfirmationWindowView(this.hw);
            confirmWin.Show();
            hmWin.Close();
        }
    }
}
