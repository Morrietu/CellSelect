using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CellSelect.ViewModels
{
    /// <summary>
    /// View model for the main page
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Default Costructor
        /// </summary>
        public MainViewModel()
        {

        }
        /// <summary>
        /// Constructor overload to handle navigation
        /// </summary>
        public MainViewModel(INavigation navigation)
        {
            // Sets navigation
            this.Navigation = navigation;
            // Command call for click event
            this.cellCountClick = new Command(async () => await goToCellCountPage());
            // Command call for click event
            this.diffCountClick = new Command(async () => await goToDiffCountClick());
            // Command call for click event
            this.savedSessionsClick = new Command(async () => await goToSavedSessionsClick());
            // Command call for click event
            this.runReportsClick = new Command(async () => await goToRunReportsClick());
        }
        #endregion

        #region Interface Command Properties
        /// <summary>
        /// Stores click event for cell count button
        /// </summary>
        public ICommand cellCountClick { protected set; get; }
        /// <summary>
        /// Stores click event for differential count button
        /// </summary>
        public ICommand diffCountClick { protected set; get; }
        /// <summary>
        /// Stores click event for saved sessions button
        /// </summary>
        public ICommand savedSessionsClick { protected set; get; }
        /// <summary>
        /// Stores click event for run reports button
        /// </summary>
        public ICommand runReportsClick { protected set; get; }
        #endregion

        #region Navigation Methods
        /// <summary>
        /// Handles click event for the button
        /// </summary>
        /// <returns></returns>
        public async Task goToCellCountPage()
        {
            // Pushes new page unto the stack
            await Navigation.PushAsync(new CellCountPage());
        }
        /// <summary>
        /// Handles click event for the button
        /// </summary>
        /// <returns></returns>
        public async Task goToDiffCountClick()
        {
            // Pushes new page unto the stack
            await Navigation.PushAsync(new DiffCountPage());
        }
        /// <summary>
        /// Handles click event for the button
        /// </summary>
        /// <returns></returns>
        public async Task goToSavedSessionsClick()
        {
            // Pushes new page unto the stack
            await Navigation.PushAsync(new SavedSessionsPage());
        }
        /// <summary>
        /// Handles click event for the button
        /// </summary>
        /// <returns></returns>
        public async Task goToRunReportsClick()
        {
            // Pushes new page unto the stack
            await Navigation.PushAsync(new RunReportsPage());
        }
        #endregion
    }
}
