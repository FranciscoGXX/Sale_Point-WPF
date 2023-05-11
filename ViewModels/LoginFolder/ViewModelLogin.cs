using DataBase_Product.ClientDb;
using DataBase_Product.Models;
using PuntoDeVenta.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PuntoDeVenta.ViewModels.LoginFolder
{
    public class ViewModelLogin:ViewModelBase
    {
        private Employee EmployeeClient;
        private EmployeeModel CheckedEmployee;


        /*--------------------------------------------------------------PROPERTIES------------------------------------------------------------*/

        /*--------------------------------------------------------------COMMNANDS------------------------------------------------------------*/
        
        public ViewModelComand VERIFYCOMMAND { get; set; }

        /*--------------------------------------------------------------METHODS------------------------------------------------------------*/
        
        private void VerifyEmployee(object parameter)
        {
            if( parameter == null)
            {
                MessageBox.Show("Por favor rellenar todos los campos solicitados");
                return;
            }

            try
            {
                var Values = (object[])parameter;

                string Name = Values[0].ToString();
                string Password = Values[1].ToString();
                Window LoginView = (Window)Values[2];


                foreach (EmployeeModel Model in EmployeeClient.GetAll())
                {
                    if (Model.USUARIO == Name && Model.CONTRASEÑA == Password)
                    {
                        ViewModelBase.EmployeeActive= Model;
                        HomeView homeView = new HomeView();
                        homeView.Show();
                        LoginView.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error mientras se hacia la verificacion de usuario");
                Debug.WriteLine(ex.Message);
            }

           
        }

        /*--------------------------------------------------------------BUILDER------------------------------------------------------------*/

        public ViewModelLogin()
        {
            EmployeeClient = new Employee();

            VERIFYCOMMAND = new ViewModelComand(VerifyEmployee);

           // new ViewModelBase(CheckedEmployee);
            

        }
    }
}
