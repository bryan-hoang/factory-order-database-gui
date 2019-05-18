using System;
using System.Windows.Input;
using Order_System_UI.Views;

namespace Order_System_UI.ViewModels.Commands
{
    public class GoToHomeWindow : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            WindowChange(parameter);
        }

        public void WindowChange(object parameter)
        {
            TransportationDataInputView confirmWin = parameter as TransportationDataInputView;
            MainWindow mainWin = new MainWindow();
            mainWin.Show();
            confirmWin.Close();
        }// end method
    }// end class
}// end namespace