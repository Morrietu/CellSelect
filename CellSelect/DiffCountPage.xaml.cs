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
    public partial class DiffCountPage : ContentPage
    {
        public DiffCountPage()
        {
            InitializeComponent();

            BindingContext = new ViewModels.DiffCountViewModel();
        }

        public DiffCountPage(DifferentialCount selectedCount)
        {
            InitializeComponent();

            BindingContext = new ViewModels.DiffCountViewModel(selectedCount);
        }
    }
}