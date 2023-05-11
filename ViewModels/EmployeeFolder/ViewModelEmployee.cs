using DataBase_Product.ClientDb;
using DataBase_Product.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PuntoDeVenta.ViewModels.EmployeeFolder
{
    public class ViewModelEmployee:ViewModelBase
    {
        private Employee EmployeeClient;
        private ObservableCollection<EmployeeModel> ListOfEmployee;

        public ObservableCollection<EmployeeModel> LISTOFEMPLOYEE { get => ListOfEmployee; set => ListOfEmployee = value; }

        /*--------------------------------------------------------------PROPERTIES------------------------------------------------------------*/

        /*--------------------------------------------------------------COMMNANDS------------------------------------------------------------*/

       public ViewModelComand SEARCHCOMMAND { get; set; }

       public ViewModelComand RESETCOMMAND { get; set; }

        /*--------------------------------------------------------------METHODS------------------------------------------------------------*/

        private void Refresh(object parameter=null)
        {
            ListOfEmployee.Clear();

            foreach(EmployeeModel Model in EmployeeClient.GetAll())
            {
                ListOfEmployee.Add(Model);
                
            }

            Console.ReadLine();
        }    

        private void HandlerSearchCommand(object parameter)
        {
            ListOfEmployee.Clear();

            foreach (EmployeeModel Model in EmployeeClient.GetAll(parameter.ToString()))
            {
                ListOfEmployee.Add(Model);
            }

            MessageBox.Show("hanlderSearch");
        }

        /*--------------------------------------------------------------BUILDER------------------------------------------------------------*/

        public ViewModelEmployee()
        {
            EmployeeClient = new Employee();
            ListOfEmployee = new ObservableCollection<EmployeeModel>();

            Refresh();


            //Instantiates Commands
            SEARCHCOMMAND = new ViewModelComand(HandlerSearchCommand);
            RESETCOMMAND = new ViewModelComand(Refresh);

        }

    }
}
