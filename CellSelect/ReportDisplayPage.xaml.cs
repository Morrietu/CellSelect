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
    public partial class ReportDisplayPage : ContentPage
    {
        public ReportDisplayPage()
        {
            InitializeComponent();
        }
        public ReportDisplayPage(List<CellCount> reportType, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            diffCountListView.IsVisible = false;
            BindingContext = new ViewModels.ReportDisplayViewModel(reportType, startDate, endDate);
        }
        public ReportDisplayPage(List<DifferentialCount> reportType, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            cellCountListView.IsVisible = false;
            BindingContext = new ViewModels.ReportDisplayViewModel(reportType, startDate, endDate);
        }

        public ReportDisplayPage(List<CellCount> reportType1, List<DifferentialCount> reportType2, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            BindingContext = new ViewModels.ReportDisplayViewModel(reportType1, reportType2, startDate, endDate);
        }
    }
}