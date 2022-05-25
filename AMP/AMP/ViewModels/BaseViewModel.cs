using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AMP.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged


    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

    }
}
