using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CellSelect.Helper_Classes
{
    /// <summary>
    /// Handles propery changed events for theview models
    /// </summary>
    public class ObservableProperty : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
