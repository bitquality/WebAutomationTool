using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTestAutomation.Models
{
    public class PropertyNameValueModel: NodeBase
    {
        private string _PropertyName;
        public string PropertyName
        {
            get { return _PropertyName; }

            set
            {
                if (value != null)
                {
                    _PropertyName = value;
                    NotifyPropertyChanged("PropertyName");
                }
              
            }
        }


        private string _PropertyValue;
        public string PropertyValue
        {
            get { return _PropertyValue; }

            set
            {
                _PropertyValue = value;
                NotifyPropertyChanged("PropertyValue");
            }
        }

    }//cls
}//ns
