using DataBase_Product.ClientDb;
using DataBase_Product.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;

namespace PuntoDeVenta.ViewModels.InventaryFolder
{
    class ViewModelInventary : ViewModelBase
    {
        private Inventary InventaryClient;

        private ObservableCollection<IModel> InventaryItem;

        /*--------------------------------------------------------------PROPERTIES------------------------------------------------------------*/

        public ObservableCollection<IModel> INVENTARYITEM
        {
            get
            {
                return InventaryItem;
            }

            set
            {
                InventaryItem = value;
                OnPropertyChanged("INVENTARYITEM");
            }
        }

        /*--------------------------------------------------------------COMMNANDS------------------------------------------------------------*/

        public ViewModelComand COMMANDSEARCH { get; set; }

        public ViewModelComand COMMANDRESET { get; set; }

        /*--------------------------------------------------------------METHODS---------------------------------------------------------------*/
        private void Refresh(object parameter= null)
        {
            INVENTARYITEM.Clear();

            foreach (InventaryModel model in InventaryClient.GetAll())
            {
                INVENTARYITEM.Add(model);
            }
        }

        private void HandlerSearchCommand(object parameter) 
        {
            if (parameter != null)
            {
                INVENTARYITEM.Clear();

                string StringParameter = parameter.ToString();

                try
                {
                    foreach (InventaryModel model in InventaryClient.GetAll(StringParameter))
                    {
                        INVENTARYITEM.Add(model);
                    }

                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error en la busquedad");
                    Debug.WriteLine(ex.Message);
                }
            }
        }



        /*--------------------------------------------------------------BUILDER------------------------------------------------------------*/

        public ViewModelInventary()
        {
            InventaryClient = new Inventary();

            INVENTARYITEM = new ObservableCollection<IModel>();

            Refresh();

            //COMANDS
            COMMANDSEARCH = new ViewModelComand(HandlerSearchCommand);
            COMMANDRESET = new ViewModelComand(Refresh);
        }


    }
}
