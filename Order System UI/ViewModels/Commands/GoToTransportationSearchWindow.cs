using System;
using Order_System_UI.Views;
using System.Windows.Input;

namespace Order_System_UI.ViewModels.Commands
{
    /// <summary>
    /// Command class for executing the transportation search window.
    /// </summary>
    public class GoToTransportationSearchWindow : ICommand
    {
        /// <summary>
        /// Event handler for button call the transportation search window.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Button will always execute.
        /// </summary>
        /// <param name="parameter">The home Window.</param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Calls WindowChange when button is clicked.
        /// </summary>
        /// <param name="parameter">The home window.</param>
        public void Execute(object parameter)
        {
            WindowChange(parameter);
        }

        /// <summary>
        /// Calls the transportation window and exits the home window.
        /// </summary>
        /// <param name="parameter">The home window.</param>
        public void WindowChange(object parameter)
        {
            MainWindow home = parameter as MainWindow;
            TransportationDataSearchView showSearchWin = new TransportationDataSearchView();
            showSearchWin.Show();
            home.Close();
        }// end method
    }// end class
}// end namespace
