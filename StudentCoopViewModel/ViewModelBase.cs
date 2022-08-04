namespace StudentCoopViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;

    public class ViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}