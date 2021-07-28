using CellSelect.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CellSelect.ViewModels
{
    class SavedSessionsViewModel : BaseViewModel
    {
        #region Fields
        public List<CellCount> cellCounts;
        public List<DifferentialCount> diffCounts;
        #endregion

        #region Properties
        public List<CellCount> CellCounts 
        { 
          get 
            {
                return cellCounts;
            }
          set
            {
                cellCounts = value;
                OnPropertyChanged("CellCounts");
            }
        }
        public List<DifferentialCount> DiffCounts 
        {
            get
            {
                return diffCounts;
            }
            set
            {
                diffCounts = value;
                OnPropertyChanged("DiffCounts");
            }
        }
        #endregion

        #region ctor
        public SavedSessionsViewModel()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<CellCount>();
                conn.CreateTable<DifferentialCount>();

                CellCounts = conn.Table<CellCount>().ToList();
                DiffCounts = conn.Table<DifferentialCount>().ToList();
            }
        }
        #endregion
    }
}
