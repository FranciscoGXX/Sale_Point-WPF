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
using PuntoDeVenta.ViewModels.PurchaseFolder;

namespace PuntoDeVenta.Views.Shop
{
    /// <summary>
    /// Lógica de interacción para CreatePurchaseView.xaml
    /// </summary>
    public partial class CreatePurchaseView : Window
    {
        public CreatePurchaseView()
        {
            InitializeComponent();
            this.DataContext = new ViewModelCreatePurchase();
        }

        private void HandlerExit(object sender, RoutedEventArgs e)
        {
            PurchasesMade purchasesMade = new PurchasesMade();
            purchasesMade.Show();
            this.Close();

        }
    }
}
