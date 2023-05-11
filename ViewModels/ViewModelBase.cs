using DataBase_Product.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.ViewModels
{
    public  class ViewModelBase : INotifyPropertyChanged
    {



        protected static EmployeeModel EmployeeActive { get; set; }
        
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        //public ViewModelBase()
        //{
            
        //    if (EmployeeActive == null)
        //    {
        //        EmployeeActive = new EmployeeModel();
        //    } 
        //}

        //public ViewModelBase(EmployeeModel Employee)
        //{
        //    EmployeeActive = Employee;
        //}


    }
}
