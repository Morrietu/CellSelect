using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CellSelect.ViewModels
{
    public class BaseViewModel : Helper_Classes.ObservableProperty
    {
        // Propterty for MVVM page navigation
        public INavigation Navigation { get; set; }
        
        public Dictionary<string, ICommand> Commands { get; protected set; }

        public BaseViewModel()
        {
            Commands = new Dictionary<string, ICommand>();
        }
    }
}
