using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandTestAutomation.Models;
using System.Collections.ObjectModel;
using CommandTestAutomation.DAL;
using System.Windows.Input;
using CommandTestAutomation.Helpers;
using System.Windows;


namespace CommandTestAutomation.ViewModels
{
    /// <summary>
    /// Initializes a new instance of TestCaseViewModel
    /// </summary>
    public class TestCaseViewModel :  ITreeViewItemViewModel
    {
        readonly TestCase _testCase;

        public TestCaseViewModel(TestCase TestCase, ProjectViewModel parentProject)
            : base(parentProject, true)
        {
            _canExecute = true;
            _testCase = TestCase;
          //  this.TestStepsData = null;
        }

        public string TestCaseName
        {
            get { return _testCase.TestCaseName; }
        }       

        protected override void LoadChildren()
        {

           // TestStepsData = DataProvider.GetTestSteps(this._testCase.TestCaseName);
        }

       

        public void RemoveTestCase()
        {
            foreach (TestCaseViewModel item in this.Parent.Children)
	        {
                if (item.TestCaseName == this.TestCaseName)
                {
                    this.Parent.Children.Remove(item);
                    break;
                    
                }
               
	        }
           
            MessageBox.Show("ok, i got call for remove test case");
            
        }

        #region Button commands Code
        private ICommand _RemoveTestCaseCommand;
        public ICommand RemoveTestCaseCommand
        {
            get
            {
                return _RemoveTestCaseCommand ?? (_RemoveTestCaseCommand = new CommandHandler(() => RemoveTestCase(), _canExecute));
            }
        }

        private ICommand _TestRunClickCommand;
        public ICommand TestRunClickCommand
        {
            get
            {
                return _TestRunClickCommand ?? (_TestRunClickCommand = new CommandHandler(() => RunSelectedTestCase(), _canExecute));
            }
        }

        private ICommand _AddTestStepClickCommand   ;
        public ICommand AddTestStepClickCommand
        {
            get
            {
                return _AddTestStepClickCommand ?? (_AddTestStepClickCommand = new CommandHandler(() => AddTestStep(), _canExecute));
            }
        }

        private ICommand _SaveTestStepClickCommand  ;
        public ICommand SaveTestStepClickCommand
        {
            get
            {
                return _SaveTestStepClickCommand ?? (_SaveTestStepClickCommand = new CommandHandler(() => SaveTestStep(), _canExecute));
            }
        }

        private void SaveTestStep()
        {
            //call database and save this step
            MessageBox.Show("Changes should be saved to database!");
        }

        private void AddTestStep()
        {
            //update database
            //TestStepsData.Add(new TestStep()
            //{
                
            //});
        }

        private bool _canExecute= true;

        public new void RunSelectedTestCase()
        {          
            //foreach (var item in this.TestStepsData)
            //{
            //    TestCaseRunner testStepRunner = new TestCaseRunner();
            //    item.TestStepStatus = EnumExtensions.GetDisplayName(StepStatus.NORUN);               
            //}         
            MessageBox.Show("Data updated!");
        }
        #endregion



       
    }//cls
}//ns
