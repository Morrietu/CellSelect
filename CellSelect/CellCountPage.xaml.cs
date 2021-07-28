using CellSelect.Classes;
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
    public partial class CellCountPage : ContentPage
    {
        public CellCountPage()
        {
            InitializeComponent();

            BindingContext = new ViewModels.CellCountViewModel();
        }
        public CellCountPage(CellCount selectedCount)
        {
            InitializeComponent();

            BindingContext = new ViewModels.CellCountViewModel(selectedCount);
        }
    }
}