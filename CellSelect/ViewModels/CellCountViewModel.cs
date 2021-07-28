using CellSelect.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Linq;

namespace CellSelect.ViewModels
{
    public class CellCountViewModel : BaseViewModel
    {
        #region Fields
        // Object for current count
        CellCount currentCount = new CellCount();
        // Stores whtie cell click
        public int whiteCell = 0;
        // Stores red cell clicks
        public int redCell = 0;
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
        /// Stores white count
        /// </summary>
        public int WhiteCount
        {
            get => whiteCell;
            set
            {
                whiteCell = value;
                OnPropertyChanged("WhiteCount");
            }
        }
        /// <summary>
        /// Stores red count
        /// </summary>
        public int RedCount
        {
            get => redCell;
            set
            {
                redCell = value;
                OnPropertyChanged("RedCount");
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
        public CellCountViewModel()
        {
            // Add commands for the view
            Commands.Add("WhiteCountOnClick", new Command(WhiteCountOnClick));
            Commands.Add("RedCountOnClick", new Command(RedCountOnClick));
            Commands.Add("SaveCount", new Command(SaveCount));
        }
        /// <summary>
        /// Overload for modifying a count
        /// </summary>
        /// <param name="selectedCount"></param>
        public CellCountViewModel(CellCount selectedCount)
        {
            currentCount = selectedCount;

            WhiteCount = selectedCount.WhiteCell;
            RedCount = selectedCount.RedCell;
            FluidType = selectedCount.FluidType;
            CountTitle = selectedCount.CountTitle;
            currentId = selectedCount.Id;

            // Add commands for the view
            Commands.Add("WhiteCountOnClick", new Command(WhiteCountOnClick));
            Commands.Add("RedCountOnClick", new Command(RedCountOnClick));
            Commands.Add("SaveCount", new Command(SaveCount));
        }
        #endregion

        #region Commands
        /// <summary>
        /// Command for incrementing red count
        /// </summary>
        public void RedCountOnClick()
        {
            ++RedCount;
        }
        /// <summary>
        /// Command for incrementing white count
        /// </summary>
        public void WhiteCountOnClick()
        {
            ++WhiteCount;
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

            if(sameId && isValid)
            {
                currentCount.WhiteCell = WhiteCount;
                currentCount.RedCell = RedCount;
                currentCount.FluidType = FluidType;
                currentCount.CountTitle = CountTitle;
                currentCount.DateModified = DateTime.Now;

                using (SQLiteConnection conn = new SQLiteConnection(App.DB_PATH))
                {
                    conn.CreateTable<CellCount>();
                    conn.Update(currentCount);
                }

                Application.Current.MainPage.DisplayAlert("Success", "Count successfully saved.", "Okay");

            }

            // Saves to database
            else if (isValid && doesntExist)
            {
                currentCount.WhiteCell = WhiteCount;
                currentCount.RedCell = RedCount;
                currentCount.FluidType = FluidType;
                currentCount.CountTitle = CountTitle;
                currentCount.DateCreated = DateTime.Now;
                currentCount.DateModified = DateTime.Now;

                using (SQLiteConnection conn = new SQLiteConnection(App.DB_PATH))
                {
                    conn.CreateTable<CellCount>();
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
                conn.CreateTable<CellCount>();
                var existingSessions = conn.Query<CellCount>("SELECT * FROM CellCount WHERE CountTitle = '" + countTitle + "';");

                if (existingSessions.Count != 0)
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
                conn.CreateTable<CellCount>();
                var existingSessions = conn.Query<CellCount>("SELECT * FROM CellCount WHERE Id = '" + currentId + "';");

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
