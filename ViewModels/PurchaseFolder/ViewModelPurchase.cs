using DataBase_Product.ClientDb;
using DataBase_Product.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PuntoDeVenta.ViewModels.PurchaseFolder
{
    public class ViewModelPurchase:ViewModelBase
    {
        private Shop ShopClient;
        private ObservableCollection<ShopModel> PurchaseList;

        /*--------------------------------------------------------------PROPERTIES------------------------------------------------------------*/

        public ObservableCollection<ShopModel> PURCHASELIST
        {
            get
            {
                return PurchaseList;
            }

            set
            {
                PurchaseList = value;
                OnPropertyChanged("PURCHASELIST");
            }
        }



        /*--------------------------------------------------------------COMMNANDS------------------------------------------------------------*/

        public ViewModelComand COMMANDSEARCH { get; set; }

        public ViewModelComand COMMANDRESETDATAGRID { get; set; }

        public ViewModelComand COMMANDDELETEITEM { get; set; }

        

        /*--------------------------------------------------------------METHODS------------------------------------------------------------*/
        private void Refresh(object parameter=null)
        {
            PURCHASELIST.Clear();
            foreach(ShopModel Model in ShopClient.GetAll())
            {
                PURCHASELIST.Add(Model);
            }
        }

        private void SearchThroughTexBox(object Parameter)
        {
            PURCHASELIST.Clear();
            foreach (ShopModel Model in ShopClient.GetAll(Parameter.ToString())) 
            {
                PURCHASELIST.Add(Model);
            }
        }

        private void DeleteItem(object parameter)
        {
            if (parameter != null)
            {
                try
                {
                    ShopModel Model = (ShopModel)(parameter);
                    int ID = Model.ID;
                    ShopClient.Delete(ID);

                    MessageBox.Show($"Se ha eliminado el registro {Model.NAME} de la fecha {Model.DATE}");

                    Refresh();
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    MessageBox.Show("Ha ocurrido un error al eliminar el registro");
                }
            }

            else
            {
                MessageBox.Show("No se ha selecionado ningun regristro en concreto para ser eliminado");
            }
            
        }


        /*--------------------------------------------------------------BUILDER------------------------------------------------------------*/
        public ViewModelPurchase()
        {
            ShopClient = new Shop();
            PurchaseList = new ObservableCollection<ShopModel>();
            Refresh();

            COMMANDSEARCH = new ViewModelComand(SearchThroughTexBox);
            COMMANDRESETDATAGRID = new ViewModelComand(Refresh);
            COMMANDDELETEITEM = new ViewModelComand(DeleteItem);

            //SearchThroughTexBox("LAPTOP ACER 15");
            
        }
    }
}
