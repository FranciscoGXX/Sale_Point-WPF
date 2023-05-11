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
using System.Data.SqlClient;
using PuntoDeVenta.Views.Sale;
using PuntoDeVenta.Views.Shop;
using PuntoDeVenta.Views.Employee;
using PuntoDeVenta.ViewModels.HomeFolder;
using PuntoDeVenta.Views.User;

namespace PuntoDeVenta.Views
{
    /// <summary>
    /// Lógica de interacción para HomeView.xaml
    /// </summary>
    public partial class HomeView : Window
    {

        public HomeView()
        {
            InitializeComponent();
            this.DataContext = new ViewModelHome();
 
        }


        private void InventaryButton(object sender, RoutedEventArgs e)
        {
            Inventory InventoryView = new();
            InventoryView.Show();
            this.Hide();

        }

        private void ShopButton(object sender, RoutedEventArgs e)
        {
            NewShopView newShopView = new();
            this.Hide();
            newShopView.Show();
        }

        private void SwichToMadeSale(object sender, RoutedEventArgs e)
        {
            MadeSaleView madeSaleView = new MadeSaleView();
            madeSaleView.Show();
            this.Close();
        }

        private void SwichToMadePurchases(object sender, RoutedEventArgs e)
        {
            PurchasesMade PurchasesView = new PurchasesMade();
            PurchasesView.Show();
            this.Close();
        }

        private void SwichToEmployee(object sender, RoutedEventArgs e)
        {
            EmployeeView EmployeeView = new EmployeeView();
            EmployeeView.Show();
            this.Close();
        }

        private void HandlerSwichToUser(object sender, RoutedEventArgs e)
        {
            UserView userView = new UserView();
            userView.Show();
            this.Close();
        }
    }


    public class ModelPrueba
    {
        public int Codigo{ get; set; }
        public string Producto { get; set; }
        public string Categoria { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
    }
}
