using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CellSelect
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RunReportsPage : ContentPage
    {
        public RunReportsPage()
        {
            InitializeComponent();
            BindingContext = new CellSelect.ViewModels.ReportsViewModel(Navigation);
        }
    }
}