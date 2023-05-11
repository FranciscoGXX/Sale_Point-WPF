using DataBase_Product.Models;
using PuntoDeVenta.ViewModels.PurchaseFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PuntoDeVenta.Views.Shop
{
    /// <summary>
    /// Lógica de interacción para PurchasesMade.xaml
    /// </summary>
    public partial class PurchasesMade : Window
    {
        public PurchasesMade()
        {
            InitializeComponent();

            this.DataContext = new ViewModelPurchase();
        }

        private void HandlerSeletedItem(object sender, MouseEventArgs e)
        {
            ShopModel Model = new ShopModel();

            try
            {
                if (GVInventary.SelectedItem != null)
                {
                    Model = (ShopModel)GVInventary.SelectedItem;

                    SubTotalText.Text = Model.TOTALPRICE.ToString();

                    double ITBIS = Model.PRICEOFSHOP * 0.18;
                    double Total = Model.TOTALPRICE + ITBIS;

                    //double TOTAL =

                    ITBISText.Text = ITBIS.ToString();
                    TotalText.Text = Total.ToString();

                    //PayWithText.Text = Model.PAYWITH.ToString();
                    //ChangeText.Text = Model.CHANGES.ToString();
                }

                else
                {
                    //MessageBox.Show("El Modelo es nulo");
                    return;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //MessageBox.Show(Model.NAMEEMPLOYEE);
        }


        private void HandlerExit(object sender, RoutedEventArgs e)
        {
            HomeView homeView = new HomeView();
            homeView.Show();
            this.Close();
        }

        private void SwichToCreatePurchase(object sender, RoutedEventArgs e)
        {
            CreatePurchaseView createPurchaseView = new CreatePurchaseView();
            createPurchaseView.ShowDialog();
            this.Close();
            
        }
    }
}
