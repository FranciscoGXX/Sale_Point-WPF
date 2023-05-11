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
using PuntoDeVenta.ViewModels.EmployeeFolder;

namespace PuntoDeVenta.Views.Employee
{
    /// <summary>
    /// Lógica de interacción para EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Window
    {
        public EmployeeView()
        {
            InitializeComponent();
            this.DataContext = new ViewModelEmployee();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HomeView homeView = new();
            homeView.Show();
            this.Close();
        }

        private void HanlderAddEmployee(object sender, RoutedEventArgs e)
        {
            ADDEMPLOYEE AddEmployeeView = new();
            AddEmployeeView.ShowDialog();
            this.Close();
        }
    }
}
