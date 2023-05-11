using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PuntoDeVenta.ViewModels
{
    public class ViewModelComand : ICommand
    {
        Action<object>_Execute;
        Predicate<object> _CanExecute;

        public ViewModelComand(Action<object> execute, Predicate<object> canExecute=null)
        {
            _Execute = execute;
            _CanExecute = canExecute;
        }

       

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (this._CanExecute != null)
            {
                return _CanExecute(parameter);
            }

            return true;      
        }

        public void Execute(object? parameter)
        {
            if (this._Execute == null)
            {
                throw new NullReferenceException();
            }
            
            this._Execute.Invoke(parameter);
        }
    }
}
