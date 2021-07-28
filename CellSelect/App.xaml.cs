using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CellSelect
{
    public partial class App : Application
    {
        // Default path for the database connection
        public static string DB_PATH = string.Empty;
        /// <summary>
        /// Default constructor
        /// </summary>
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
        /// <summary>
        /// Constructor override to take database path
        /// </summary>
        /// <param name="DB_Path"></param>
        public App(string DB_Path)
        {
            InitializeComponent();
            // Given path is stored as the global path
            DB_PATH = DB_Path;

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
