using CellSelect.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CellSelect.ViewModels
{
    class ReportsViewModel : BaseViewModel
    {
        #region Properties
        public bool CellRadio { get; set; }
        public bool DiffRadio { get; set; }
        public bool BothRadio { get; set; }

        public CellCount CellReport { get; set; }
        public DifferentialCount DiffReport { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Today;
        public DateTime EndDate { get; set; } = DateTime.Today;

        public List<CellCount> CellQuery { get; set; }
        public List<DifferentialCount> DiffQuery { get; set; }
        #endregion

        #region ctor
        /// <summary>
        /// Default constructor
        /// </summary>
        public ReportsViewModel()
        {

        }
        /// <summary>
        /// Constructor overload to handle navigation
        /// </summary>
        /// <param name="navigation"></param>
        public ReportsViewModel(INavigation navigation)
        {
            // Sets navigation
            this.Navigation = navigation;

            using (SQLiteConnection conn = new SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<CellCount>();
                conn.CreateTable<DifferentialCount>();
                CellQuery = conn.Table<CellCount>().ToList();
                DiffQuery = conn.Table<DifferentialCount>().ToList();
            }

                // Command call for click event
                this.genReportClick = new Command(async () => await goToReportDisplayPage());
        }
        #endregion

        #region Commands
        /// <summary>
        /// Stores click event for cell count button
        /// </summary>
        public ICommand genReportClick { protected set; get; }
        #endregion

        #region Methods
        /// <summary>
        /// Handles click event for the button
        /// </summary>
        /// <returns></returns>
        public async Task goToReportDisplayPage()
        {
            var validEntry = CheckEntry();
            if (CellRadio == true && validEntry)
            {
                    foreach (var item in CellQuery)
                    {
                        if(item.DateCreated <= StartDate && item.DateModified >= EndDate)
                        {
                            CellQuery.Remove(item);
                        }
                    }
                    // Pushes new page unto the stack
                    await Navigation.PushAsync(new ReportDisplayPage(CellQuery, StartDate, EndDate));
                
            }
            else if (DiffRadio == true && validEntry)
            {
                    foreach (var item in DiffQuery)
                    {
                        if (item.DateCreated <= StartDate && item.DateModified >= EndDate)
                        {
                            DiffQuery.Remove(item);
                        }
                    }
                    // Pushes new page unto the stack
                    await Navigation.PushAsync(new ReportDisplayPage(DiffQuery, StartDate, EndDate));
                
            }
            else if(validEntry)
            {
                foreach (var item in CellQuery)
                {
                    if (item.DateCreated <= StartDate && item.DateModified >= EndDate)
                    {
                        CellQuery.Remove(item);
                    }
                }
                foreach (var item2 in DiffQuery)
                {
                    if (item2.DateCreated <= StartDate && item2.DateModified >= EndDate)
                    {
                        DiffQuery.Remove(item2);
                    }
                }
                await Navigation.PushAsync(new ReportDisplayPage(CellQuery, DiffQuery, StartDate, EndDate));
            }
        }

        public bool CheckEntry()
        {
            if(!CellRadio && !DiffRadio && !BothRadio)
            {
                Application.Current.MainPage.DisplayAlert("Warning", "Please enter count type.", "Okay");
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
