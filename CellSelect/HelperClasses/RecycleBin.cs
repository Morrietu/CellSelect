using System;
using System.Collections.Generic;
using System.Text;

namespace CellSelect.HelperClasses
{
    class RecycleBin
    {
        /*
        List<CellCount> cellCounts;
        List<DifferentialCount> diffCounts;
        private ObservableCollection<CellCount> cellCollection;
        private ObservableCollection<DifferentialCount> diffCollection;

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
        */

        /*
         
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
         */
    }
}
