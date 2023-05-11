using PuntoDeVenta.ViewModels.InventaryFolder;
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

namespace PuntoDeVenta.Views
{
    /// <summary>
    /// Lógica de interacción para Inventory.xaml
    /// </summary>
    public partial class Inventory : Window
    {
        public Inventory()
        {
            InitializeComponent();

            this.DataContext = new ViewModelInventary();
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HomeView homeView = new();
            homeView.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddProductDetails addProductDetails = new();
            addProductDetails.ShowDialog();
            this.Hide();
        }
    }
}
