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
using DataBase_Product.Models;
using PuntoDeVenta.ViewModels.SaleFolder;

namespace PuntoDeVenta.Views.Sale
{
    /// <summary>
    /// Lógica de interacción para MadeSaleView.xaml
    /// </summary>
    public partial class MadeSaleView : Window
    {
        public MadeSaleView()
        {
            InitializeComponent();
            this.DataContext = new ViewModelSale();
        }



        private void HandlerSeletedItem(object sender, MouseEventArgs e)
        {
            SaleModel Model = new SaleModel();

            try
            {
                if (GVInventary.SelectedItem != null)
                {
                    Model = (SaleModel)GVInventary.SelectedItem;

                    SubTotalText.Text = Model.SUBTOTAL.ToString();

                    double ITBIS = Model.SUBTOTAL * 0.18;
                    double Total = Model.SUBTOTAL + ITBIS;

                    //double TOTAL =

                    ITBISText.Text = ITBIS.ToString();
                    TotalText.Text = Total.ToString();

                    PayWithText.Text = Model.PAYWITH.ToString();
                    ChangeText.Text = Model.CHANGES.ToString();
                }

                else
                {
                    //MessageBox.Show("El Modelo es nulo");
                    return;
                }
                
                
            }
            catch(Exception ex)
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
    }
}

