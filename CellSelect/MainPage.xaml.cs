using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CellSelect
{
    /// <summary>
    /// Main page on app load
    /// </summary>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            // Sets binding for the page's view mdoel
            BindingContext = new CellSelect.ViewModels.MainViewModel(Navigation);
        }
    }
}
