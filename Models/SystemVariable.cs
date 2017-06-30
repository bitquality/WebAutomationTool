using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTestAutomation.Models
{
    public class SystemVariable : INotifyPropertyChanged
    {
        public SystemVariable()
        {

        }


        private string _PropertyName;

        public string PropertyName
        {
            get { return _PropertyName; }
            set { _PropertyName = value; NotifyPropertyChanged("PropertyName"); }
        }

            
        private string _PropertyValue;

        public string PropertyValue
        {
            get { return _PropertyValue; }
            set { _PropertyValue = value; NotifyPropertyChanged("PropertyValue"); }
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members
    }
}
