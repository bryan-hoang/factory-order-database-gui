using System;
using System.Windows.Input;
using Order_System_UI.Views;

namespace Order_System_UI.ViewModels.Commands
{
    /// <summary>
    /// Command class to go to the transportation input window.
    /// </summary>
    public class GoToTransportationInputWindow : ICommand
    {
        /// <summary>
        /// Event handler for button.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// The button is always avaliable for execution.
        /// </summary>
        /// <param name="parameter">The home window.</param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Calls WindowChange when button is clicked.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            WindowChange(parameter);
        }

        /// <summary>
        /// Goes to the transportation input window and exits the home window.
        /// </summary>
        /// <param name="parameter"></param>
        public void WindowChange(object parameter)
        {
            MainWindow home = parameter as MainWindow;
            TransportationDataInputView showInputWin = new TransportationDataInputView();
            showInputWin.Show();
            home.Close();
        }// end method
    }// end class
}// end namespace