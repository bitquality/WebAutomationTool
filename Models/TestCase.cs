using CommandTestAutomation.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTestAutomation.Models
{
    public class TestCase : INotifyPropertyChanged
    {
        public TestCase(string testCaseName)
        {
            this.TestCaseName = testCaseName;
            _TestStepsData = new ObservableCollection<TestStep>()
                {
                    new TestStep(){
                        TestStepFieldItemName="",
                        TestStepFieldActionName="",
                        TestStepFieldActionValue="",
                        AutomationTypePlatform = AutomationEnvironmentType.Window,
                        
                        TestStepId=0,
                        TestStepStatus="",
                        SelectedFieldItem = new UIFieldNode(),

                        
                    }
                };
        }

        public int TestCaseId { get; set; }
        public string TestCaseName { get;  set; }

        public virtual Project Project { get; set; }

        private  ObservableCollection<TestStep> _TestStepsData;
        public  ObservableCollection<TestStep> TestStepsData
        {
            get { return _TestStepsData; }
            set { _TestStepsData = value;
            OnPropertyChanged("TestStepsData");
            }
        }


        #region IsNodeSelected
        public bool _IsNodeSelected = true;
        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is selected.
        /// </summary>
        public bool IsNodeSelected
        {
            get { return _IsNodeSelected; }
            set
            {

                Console.WriteLine(StaticDataHelper.UIFields);
                if (value != _IsNodeSelected)
                {
                    _IsNodeSelected = value;
                    //if (this.Children == null)
                    //{
                    //    this.LoadChildren();
                    //}
                    OnPropertyChanged("IsNodeSelected");
                }
            }
        }


        #endregion // IsNodeSelected

        
        

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members        

       
    }//class
}//namespace
