using Microsoft.Win32;
using PuntoDeVenta.ViewModels.EmployeeFolder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace PuntoDeVenta.Views.Employee
{
    /// <summary>
    /// Lógica de interacción para ADDEMPLOYEE.xaml
    /// </summary>
    public partial class ADDEMPLOYEE : Window
    {
        public ADDEMPLOYEE()
        {
            InitializeComponent();
            this.DataContext = new ViewModelAddEmployee();

            //Debug.WriteLine(PhotoProfile.GetType());


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmployeeView employeeView = new();
            employeeView.Show();
            this.Close();
            
        }

        private void HandlerAddImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.InitialDirectory="c//"


            if (fileDialog.ShowDialog() == true)
            {

                try
                {
                    PhotoProfile.Source = new BitmapImage(new Uri(fileDialog.FileName));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error mientras se cargaba la imagen, revise que el archivo selecionado sea una imagen del tipo JPEG/PNG");
                }

            }

            else
            {
                MessageBox.Show("Ocurrio un error al la hora de selecionar el archivo");
            }

            
        }

    }
}
