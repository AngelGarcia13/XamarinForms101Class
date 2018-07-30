using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ListViews.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        bool isRunning = false;
        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                if (isRunning != value)
                {
                    isRunning = value;
                    OnPropertyChanged("IsRunning");
                    OnPropertyChanged("IsNotRunning");
                }
            }
        }

        public bool IsNotRunning
        {
            get
            {
                return !isRunning;
            }
        }
    }
}
