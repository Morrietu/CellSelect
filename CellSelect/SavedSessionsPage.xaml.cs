using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellSelect.Classes;
using CellSelect.ViewModels;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CellSelect
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SavedSessionsPage : ContentPage
    {
        List<CellCount> cellCounts;
        List<DifferentialCount> diffCounts;
        private ObservableCollection<CellCount> cellCollection;
        private ObservableCollection<DifferentialCount> diffCollection;

        Page previousPage;

        bool isLoaded = false;

        protected async override void OnAppearing()
        {
            if (isLoaded)
            {
                await Navigation.PushAsync(new SavedSessionsPage());
                Navigation.RemovePage(previousPage);

                isLoaded = false;
            }
        }


        public ObservableCollection<CellCount> CellCollection 
        {
            get
            {
                return cellCollection;
            }
            set
            {
                cellCollection = value;
                OnPropertyChanged("CellCollection");
            }
        }
        public ObservableCollection<DifferentialCount> DiffCollection
        {
            get
            {
                return diffCollection;
            }
            set
            {
                diffCollection = value;
                OnPropertyChanged("DiffCollection");
            }
        }
        
        CellCount selectedCellCount = new CellCount();
        DifferentialCount selectedDiffCount = new DifferentialCount();

        public SavedSessionsPage()
        {
            InitializeComponent();

            BindingContext = new CellSelect.ViewModels.SavedSessionsViewModel();

            using (SQLiteConnection conn = new SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<CellCount>();
                conn.CreateTable<DifferentialCount>();

                cellCounts = conn.Table<CellCount>().ToList();
                diffCounts = conn.Table<DifferentialCount>().ToList();

                ObservableCollection<CellCount> tempCellCollection = new ObservableCollection<CellCount>(cellCounts as List<CellCount>);
                ObservableCollection<DifferentialCount> tempDiffCollection = new ObservableCollection<DifferentialCount>(diffCounts as List<DifferentialCount>);

                CellCollection = tempCellCollection;
                DiffCollection = tempDiffCollection;

                cellCountListView.ItemsSource = CellCollection;
                diffCountListView.ItemsSource = DiffCollection;
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            cellCountListView.ItemsSource = GetCellTitle(e.NewTextValue);
            diffCountListView.ItemsSource = GetDiffTitle(e.NewTextValue);
        }

        IEnumerable<CellCount> GetCellTitle(string searchText = null)
        {
         

            if (string.IsNullOrEmpty(searchText))
                return cellCounts;
            return cellCounts.Where(p => p.CountTitle.StartsWith(searchText));
        }

        IEnumerable<DifferentialCount> GetDiffTitle(string searchText = null)
        {


            if (string.IsNullOrEmpty(searchText))
                return diffCounts;
            return diffCounts.Where(p => p.DiffTitle.StartsWith(searchText));
        }

        private void cellCountListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }

        private void modifySessionButton_Clicked(object sender, EventArgs e)
        {
            if(cellCountListView.SelectedItem != null)
            {
                selectedCellCount = cellCountListView.SelectedItem as CellCount;
                previousPage = Navigation.NavigationStack.LastOrDefault();
                isLoaded = true;
                Navigation.PushAsync(new CellCountPage(selectedCellCount));
            }
            
            else if(diffCountListView.SelectedItem != null)
            {
                selectedDiffCount = diffCountListView.SelectedItem as DifferentialCount;
                previousPage = Navigation.NavigationStack.LastOrDefault();
                isLoaded = true;
                Navigation.PushAsync(new DiffCountPage(selectedDiffCount));
            }
        }

        async private void deleteSessionButton_Clicked(object sender, EventArgs e)
        {
            if (cellCountListView.SelectedItem != null)
            {
                selectedCellCount = cellCountListView.SelectedItem as CellCount;

                var ans = await DisplayAlert("Warning", "Are you sure that you want to delete the selected count?", "Continue", "Cancel");

                if (ans == true)
                {
                    using (SQLiteConnection db = new SQLiteConnection(App.DB_PATH))
                    {
                        db.CreateTable<CellCount>();
                        int toDelete = db.Delete(selectedCellCount);
                    }
                    previousPage = Navigation.NavigationStack.LastOrDefault();
                    await Navigation.PushAsync(new SavedSessionsPage());
                    Navigation.RemovePage(previousPage);
                }
            }
            else if (diffCountListView.SelectedItem != null)
            {
                selectedDiffCount = diffCountListView.SelectedItem as DifferentialCount;

                var ans = await DisplayAlert("Warning", "Are you sure that you want to delete the selected count?", "Continue", "Cancel");

                if (ans == true)
                {
                    using (SQLiteConnection db = new SQLiteConnection(App.DB_PATH))
                    {
                        db.CreateTable<CellCount>();
                        int toDelete = db.Delete(selectedDiffCount);
                    }
                    previousPage = Navigation.NavigationStack.LastOrDefault();
                    await Navigation.PushAsync(new SavedSessionsPage());
                    Navigation.RemovePage(previousPage);
                }
            }
        }
    }
}