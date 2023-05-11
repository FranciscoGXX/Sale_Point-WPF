using DataBase_Product.ClientDb;
using DataBase_Product.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PuntoDeVenta.ViewModels.PurchaseFolder
{
    class ViewModelCreatePurchase : ViewModelBase
    {
        private Shop ShopClient;
        private ShopModel shopModel;

        /*--------------------------------------------------------------PROPERTIES------------------------------------------------------------*/

        public ShopModel SHOPMODEL
        {
            get
            {
                return shopModel;
            }
            set
            {
                shopModel = value;
                OnPropertyChanged("SHOPMODEL");
            }
        }

        /*--------------------------------------------------------------COMMNANDS------------------------------------------------------------*/

        public ViewModelComand COMMANDCREATESHOP { get; set; }
        public ViewModelComand COMMANDDELTESHOP { get; set; }

        /*--------------------------------------------------------------METHODS------------------------------------------------------------*/

        private void CreateNewShop(object parameter)
        {
            if (parameter == null)
            {
                MessageBox.Show("No se han enviado los datos suficientes para registrar dicha compra. Por favor revisar cada uno de los campos");
            }

            var Values = (object[])parameter;

            ShopModel NewShopModel = new ShopModel();

            NewShopModel.NAME = Values[0].ToString();
            NewShopModel.PRICEOFSHOP = Int32.Parse(Values[1].ToString());
            NewShopModel.AMOUNT = Int32.Parse(Values[2].ToString());
            NewShopModel.PRICEOFSALE= Int32.Parse(Values[4].ToString());
            NewShopModel.CATEGORY = Values[5].ToString();
            NewShopModel.CODE = Int64.Parse(Values[6].ToString());

            
            
                ShopClient.Create(NewShopModel.CODE, NewShopModel.AMOUNT, NewShopModel.NAME, NewShopModel.PRICEOFSHOP, NewShopModel.PRICEOFSALE, NewShopModel.CATEGORY);
                
            
            /*catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al registrar dicha venta");
                Debug.WriteLine(ex.Message);
            }*/






            //ShopClient.Create();
            


        }

        private void DeleteShop(object parameter)
        {
            ShopModel shopModel = (ShopModel)parameter;
            ShopClient.Delete(shopModel.ID);
        }
            
        /*--------------------------------------------------------------BUILDER------------------------------------------------------------*/
        public ViewModelCreatePurchase()
        {
            ShopClient = new Shop();

            COMMANDCREATESHOP = new ViewModelComand(CreateNewShop);
            COMMANDDELTESHOP = new ViewModelComand(DeleteShop);
        }
    }
}
