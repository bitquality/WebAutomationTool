using CommandTestAutomation.DAL;
using CommandTestAutomation.Helpers;
using CommandTestAutomation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandTestAutomation.ViewModels
{
     
     /// <summary>
    /// Initializes a new instance of TestControlViewModel
    /// </summary>
    public class UITestControlViewModel :  ITreeViewItemViewModel
    {
        readonly UIField _UIField;

        public UITestControlViewModel(UIField UIField, ProjectViewModel parentProject)
            : base(parentProject, true)
        {
            _canExecute = true;
            _UIField = UIField;
            
        }

        public string UIFieldName
        {
            get { return _UIField.UIFieldName; }
        }       

        protected override void LoadChildren()
        {
            
           // this.TestObjectsData = Database.GetTestObjects();
        }

        #region Button RunClickCommand Code
        private ICommand _TestRunClickCommand;
        public ICommand TestRunClickCommand
        {
            get
            {
                return _TestRunClickCommand ?? (_TestRunClickCommand = new CommandHandler(() => RunSelectedUIField(), _canExecute));
            }
        }
        private bool _canExecute;
        public void RunSelectedUIField()
        {
            //// call TestAutomation code here..
            //UIFieldRunner testStepRunner = new UIFieldRunner();
            //testStepRunner.RunUIField(this.UIFieldName);
        }
        #endregion

        private ObservableCollection<UIField> _TestObjectsData;
        public ObservableCollection<UIField> TestObjectsData
        {
            get
            {
                return null;// Database.GetTestObjects();
            }
            set { _TestObjectsData = value; NotifyPropertyChanged("TestObjectsData"); }
        }

    }//class
}//namespacce
