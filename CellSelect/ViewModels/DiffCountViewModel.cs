using CellSelect.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CellSelect.ViewModels
{
    public class DiffCountViewModel : BaseViewModel
    {
        #region Fields
        // Object for current count
        DifferentialCount currentCount = new DifferentialCount();
        // Stores cell clicks
        public int seg = 0;
        public int lymph = 0;
        public int mono = 0;
        public int eo = 0;
        public int baso = 0;
        public int meta = 0;
        public int myelo = 0;
        public int blast = 0;
        public int aLymph = 0;
        public int pro = 0;
        // Check for entry validation
        public bool isValid;
        // Check for exiting sessions
        public bool doesntExist;
        // Stores Id
        public int currentId;
        // Compares current and table id
        public bool sameId;
        #endregion

        #region Properties

        /// <summary>
        /// Properties for cell types
        /// </summary>
        public int Seg
        {
            get => seg;
            set
            {
                seg = value;
                OnPropertyChanged("Seg");
            }
        }
        public int Lymph
        {
            get => lymph;
            set
            {
                lymph = value;
                OnPropertyChanged("Lymph");
            }
        }
        public int Mono
        {
            get => mono;
            set
            {
                mono = value;
                OnPropertyChanged("Mono");
            }
        }
        public int Eo
        {
            get => eo;
            set
            {
                eo = value;
                OnPropertyChanged("Eo");
            }
        }
        public int Baso
        {
            get => baso;
            set
            {
                baso = value;
                OnPropertyChanged("Baso");
            }
        }
        public int Meta
        {
            get => meta;
            set
            {
                meta = value;
                OnPropertyChanged("Meta");
            }
        }
        public int Myelo
        {
            get => myelo;
            set
            {
                myelo = value;
                OnPropertyChanged("Myelo");
            }
        }
        public int Blast
        {
            get => blast;
            set
            {
                blast = value;
                OnPropertyChanged("Blast");
            }
        }
        public int ALymph
        {
            get => aLymph;
            set
            {
                aLymph = value;
                OnPropertyChanged("ALymph");
            }
        }
        public int Pro
        {
            get => pro;
            set
            {
                pro = value;
                OnPropertyChanged("Pro");
            }
        }
        /// <summary>
        /// Stores fluid type
        /// </summary>
        public string FluidType { get; set; }
        /// <summary>
        /// Stores count title
        /// </summary>
        public string CountTitle { get; set; }
        #endregion

        #region ctor
        /// <summary>
        /// Default ctor
        /// </summary>
        public DiffCountViewModel()
        {
            // Add commands for the view
            Commands.Add("SegCountOnClick", new Command(SegCountOnClick));
            Commands.Add("LymphCountOnClick", new Command(LymphCountOnClick));
            Commands.Add("MonoCountOnClick", new Command(MonoCountOnClick));
            Commands.Add("EoCountOnClick", new Command(EoCountOnClick));
            Commands.Add("BasoCountOnClick", new Command(BasoCountOnClick));
            Commands.Add("MetaCountOnClick", new Command(MetaCountOnClick));
            Commands.Add("MyeloCountOnClick", new Command(MyeloCountOnClick));
            Commands.Add("BlastCountOnClick", new Command(BlastCountOnClick));
            Commands.Add("ALymphCountOnClick", new Command(ALymphCountOnClick));
            Commands.Add("ProCountOnClick", new Command(ProCountOnClick));
            Commands.Add("SaveCount", new Command(SaveCount));
        }
        /// <summary>
        /// Overload for modifying a count
        /// </summary>
        /// <param name="selectedCount"></param>
        public DiffCountViewModel(DifferentialCount selectedCount)
        {
            currentCount = selectedCount;

            Seg = selectedCount.Neutrophil;
            Lymph = selectedCount.Lymphocyte;
            Mono = selectedCount.Monocyte;
            Eo = selectedCount.Eosinophil;
            Baso = selectedCount.Basophil;
            Meta = selectedCount.Metamyelocyte;
            Myelo = selectedCount.Myelocyte;
            Blast = selectedCount.Blast;
            ALymph = selectedCount.AtypicalLymphocyte;
            Pro = selectedCount.Promyelocyte;
            FluidType = selectedCount.FluidType;
            CountTitle = selectedCount.DiffTitle;
            currentId = selectedCount.Id;

            // Add commands for the view
            Commands.Add("SegCountOnClick", new Command(SegCountOnClick));
            Commands.Add("LymphCountOnClick", new Command(LymphCountOnClick));
            Commands.Add("MonoCountOnClick", new Command(MonoCountOnClick));
            Commands.Add("EoCountOnClick", new Command(EoCountOnClick));
            Commands.Add("BasoCountOnClick", new Command(BasoCountOnClick));
            Commands.Add("MetaCountOnClick", new Command(MetaCountOnClick));
            Commands.Add("MyeloCountOnClick", new Command(MyeloCountOnClick));
            Commands.Add("BlastCountOnClick", new Command(BlastCountOnClick));
            Commands.Add("ALymphCountOnClick", new Command(ALymphCountOnClick));
            Commands.Add("ProCountOnClick", new Command(ProCountOnClick));
            Commands.Add("SaveCount", new Command(SaveCount));
        }
        #endregion

        #region Commands
        /// <summary>
        /// Commands for incrementing cell counts
        /// </summary>
        public void SegCountOnClick()
        {
            ++Seg;
        }
        public void LymphCountOnClick()
        {
            ++Lymph;
        }
        public void MonoCountOnClick()
        {
            ++Mono;
        }
        public void EoCountOnClick()
        {
            ++Eo;
        }
        public void BasoCountOnClick()
        {
            ++Baso;
        }
        public void MetaCountOnClick()
        {
            ++Meta;
        }
        public void MyeloCountOnClick()
        {
            ++Myelo;
        }
        public void BlastCountOnClick()
        {
            ++Blast;
        }
        public void ALymphCountOnClick()
        {
            ++ALymph;
        }
        public void ProCountOnClick()
        {
            ++Pro;
        }
        /// <summary>
        /// Saves count to database
        /// </summary>
        public void SaveCount()
        {
            // Makes sure that entries have values
            isValid = CheckValues(FluidType, CountTitle);

            // Checks so see if current count is already stored
            sameId = CheckId(CountTitle);

            if(!sameId)
            {
                // Makes sure that a conflicting entry doesn't exist
                doesntExist = CheckTables(CountTitle);
            }

            if (sameId && isValid)
            {
                currentCount.Neutrophil = Seg;
                currentCount.Lymphocyte = Lymph;
                currentCount.Monocyte = Mono;
                currentCount.Eosinophil = Eo;
                currentCount.Basophil = Baso;
                currentCount.Metamyelocyte = Meta;
                currentCount.Myelocyte = Myelo;
                currentCount.Blast = Blast;
                currentCount.AtypicalLymphocyte = ALymph;
                currentCount.Promyelocyte = Pro;
                currentCount.FluidType = FluidType;
                currentCount.DiffTitle = CountTitle;
                currentCount.DateModified = DateTime.Now;

                using (SQLiteConnection conn = new SQLiteConnection(App.DB_PATH))
                {
                    conn.CreateTable<DifferentialCount>();
                    conn.Update(currentCount);
                }

                Application.Current.MainPage.DisplayAlert("Success", "Count successfully saved.", "Okay");
            }

            // Saves to database
            if (isValid && doesntExist)
            {
                currentCount.Neutrophil = Seg;
                currentCount.Lymphocyte = Lymph;
                currentCount.Monocyte = Mono;
                currentCount.Eosinophil = Eo;
                currentCount.Basophil = Baso;
                currentCount.Metamyelocyte = Meta;
                currentCount.Myelocyte = Myelo;
                currentCount.Blast = Blast;
                currentCount.AtypicalLymphocyte = ALymph;
                currentCount.Promyelocyte = Pro;
                currentCount.FluidType = FluidType;
                currentCount.DiffTitle = CountTitle;
                currentCount.DateCreated = DateTime.Now;
                currentCount.DateModified = DateTime.Now;

                using (SQLiteConnection conn = new SQLiteConnection(App.DB_PATH))
                {
                    conn.CreateTable<DifferentialCount>();
                    conn.Insert(currentCount);
                }
                Application.Current.MainPage.DisplayAlert("Success", "Count successfully saved.", "Okay");
            }
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Checks entry values
        /// </summary>
        /// <param name="fluidType"></param>
        /// <param name="countTitle"></param>
        /// <returns></returns>
        public bool CheckValues(string fluidType, string countTitle)
        {
            if (fluidType == null || countTitle == null)
            {
                Application.Current.MainPage.DisplayAlert("Warning", "Please enter fluid type and title.", "Okay");
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Checks that a conflicting entry doesn't exist
        /// </summary>
        /// <param name="countTitle"></param>
        /// <returns></returns>
        public bool CheckTables(string countTitle)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<DifferentialCount>();
                var existingSessions = conn.Query<DifferentialCount>("SELECT * FROM DifferentialCount WHERE DiffTitle = '" + countTitle + "';");

                if(existingSessions.Count != 0)
                {
                    Application.Current.MainPage.DisplayAlert("Warning", "A count by that title already exists.", "Okay");

                    return false;
                }

                else
                {
                    return true;
                }
            }

        }
        /// <summary>
        /// Checks that a conflicting entry doesn't exist
        /// </summary>
        /// <param name="countTitle"></param>
        /// <returns></returns>
        public bool CheckId(string countTitle)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<DifferentialCount>();
                var existingSessions = conn.Query<DifferentialCount>("SELECT * FROM DifferentialCount WHERE Id = '" + currentId + "';");

                if (existingSessions.Count != 0)
                {
                    foreach (var item in existingSessions)
                    {
                        if (item.Id == currentId)
                        {
                            return true;
                        }
                    }
                    return false;
                }

                else
                {
                    return false;
                }
            }
        }
        #endregion
    }
}
