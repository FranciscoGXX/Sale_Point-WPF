﻿using PuntoDeVenta.ViewModels.InventaryFolder;
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
    /// Lógica de interacción para Example.xaml
    /// </summary>
    public partial class Example : Window
    {
        public Example()
        {
            InitializeComponent();

            this.DataContext = new ViewModelInventary();
        }
    }
}
