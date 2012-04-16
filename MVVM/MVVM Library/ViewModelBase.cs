﻿using System.ComponentModel;

namespace Pharos.MPS.Mobile.Client.MVVM
{    
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
       
        protected virtual void RaisePropertyChanged(string propertyName)
        {           
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}