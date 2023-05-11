using DataBase_Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase_Product.ClientDb;
using System.Windows;
using System.Collections.ObjectModel;

namespace PuntoDeVenta.ViewModels.SaleFolder
{
    class ViewModelSale:ViewModelBase
    {
        private Sale ClientSale;
        private ObservableCollection<SaleModel> SaleList;

        public ObservableCollection<SaleModel> SALELIST
        {
            get
            {
                return SaleList;
            }

            set
            {
                SaleList = value;
                OnPropertyChanged();
            }
        }


        /*--------------------------------------------------------------COMMNANDS------------------------------------------------------------*/


         //Comamand for Search throught the SearchBox

         public ViewModelComand COMMANDSEARCHSALES { get; set; }
         private void SearchSales(object parameter)
        {
            SaleList.Clear();
            string StringParameter = parameter.ToString();

            foreach (SaleModel Model in ClientSale.GetAll(StringParameter))
            {
                SALELIST.Add(Model);
            }

            Console.ReadLine();
        }

        //Command for reset the DataGrid
        
        public ViewModelComand COMMANDRESETDATAGRID { get; set; }
        private void ResetDataGrid(object? parameter=null)
        {
            SALELIST.Clear();
            foreach (SaleModel Model in ClientSale.GetAll())
            {
                SALELIST.Add(Model);
            }
        }





        /*--------------------------------------------------------------BUILDER------------------------------------------------------------*/
        public ViewModelSale()
        {
            ClientSale = new Sale();
            //ClientSale.GetAll(0, "Ana Reyes");
            SaleList = new ObservableCollection<SaleModel>();
            ResetDataGrid();
            

            Console.ReadLine();

            COMMANDSEARCHSALES = new ViewModelComand(SearchSales);
            COMMANDRESETDATAGRID = new ViewModelComand(ResetDataGrid);


            
        }
    }
}
