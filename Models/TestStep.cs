using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CommandTestAutomation.DAL;
using CommandTestAutomation;
using System.Collections.ObjectModel;
using CommandTestAutomation.DAL;
using CommandTestAutomation.Enums;

namespace CommandTestAutomation.Models
{
    public class TestStep : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of Test Case Step class...
        /// </summary>
        public TestStep()
        {
           //s this.UIFields = StaticDataHelper.UIFields;
        }

        private int _TestStepId;

        public int TestStepId
        {
            get { return _TestStepId; }
            set { _TestStepId = value;
                NotifyPropertyChanged("TestStepId");
            }
        }


        private string _TestStepDescription;
        public string TestStepDescription
        {
            get { return _TestStepDescription; }
            set
            {
                _TestStepDescription = value;
                NotifyPropertyChanged("TestStepDescription");
            }
        }

        private AutomationEnvironmentType _AutomationTypePlatform;
        public AutomationEnvironmentType AutomationTypePlatform
        {
            get { return _AutomationTypePlatform; }
            set { _AutomationTypePlatform = value;
                NotifyPropertyChanged("AutomationTypePlatform");
            }
        }
        

        /// <summary>
        /// It has values like SetText,Click,SelectItem,Navigate,Open etc..
        /// </summary>
        private string _TestStepFieldActionName;
        public string TestStepFieldActionName
        {
            get { return _TestStepFieldActionName; }
            set { _TestStepFieldActionName = value;
            NotifyPropertyChanged("TestStepFieldActionName");
            }
        }

        private string _TestStepFieldActionValue;
        public string TestStepFieldActionValue
        {
            get { return _TestStepFieldActionValue; }
            set { _TestStepFieldActionValue = value;
                NotifyPropertyChanged("TestStepFieldActionValue");
            }
        }

        private StepRunStatus _TestStepStatus;
        public StepRunStatus TestStepStatus
        {
            get { return _TestStepStatus; }
            set { _TestStepStatus = value;
                NotifyPropertyChanged("TestStepStatus");
            }
        }


        private UIFieldNode _UiFieldNodeItem    ;
        public UIFieldNode UiFieldNodeItem
        {
            get {
                return _UiFieldNodeItem; }
            set
            {
                _UiFieldNodeItem = value;
                NotifyPropertyChanged("UiFieldNodeItem");
            }
        }




        #region Static values from db
        private List<string> _UIFieldActions;
        public List<string> UIFieldActions
        {
            get { return Enum.GetNames(typeof(WebUIAction)).ToList(); }
            set
            {
                _UIFieldActions = value;
                NotifyPropertyChanged("UIFieldActions");
            }
        }

        //private ObservableCollection<UIFieldNode> _UIFields;
        //public ObservableCollection<UIFieldNode> UIFields
        //{
        //    get
        //    {
        //        // var data = StaticDataHelper.UIFields;
        //        // _UIFields = data;
        //        return _UIFields;

        //    }
        //    set
        //    {
        //        _UIFields = value;
        //        NotifyPropertyChanged("UIFields");
        //    }
        //}


        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members

    }//end of class
}//end of ns
