using DataBase_Product.Models;
using PuntoDeVenta.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PuntoDeVenta.ViewModels.HomeFolder
{
    public class ViewModelHome:ViewModelBase
    {
        /*--------------------------------------------------------------PROPERTIES------------------------------------------------------------*/

        /*--------------------------------------------------------------COMMNANDS------------------------------------------------------------*/
        public ViewModelComand COMMANDLOGOUT { get; set; }
        /*--------------------------------------------------------------METHODS------------------------------------------------------------*/
        private void LogOut(object parameter)
        {
            EmployeeActive = new EmployeeModel();
            Window HomeView = (Window)parameter;

            Login LoginView = new Login();
            LoginView.Show();
            HomeView.Close();

        }
        /*--------------------------------------------------------------BUILDER------------------------------------------------------------*/

        public ViewModelHome()
        {
            //GC.KeepAlive()
            COMMANDLOGOUT = new ViewModelComand(LogOut);
        }
    }
}
