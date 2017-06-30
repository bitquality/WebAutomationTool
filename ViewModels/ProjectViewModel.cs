using CommandTestAutomation.DAL;
using CommandTestAutomation.Helpers;
using CommandTestAutomation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CommandTestAutomation.ViewModels
{
    /// <summary>
    /// The ViewModel for the project treeview demo.  This simply
    /// exposes a read-only collection of projects.
    /// </summary>
    public class ProjectViewModel:  ITreeViewItemViewModel
    {
        readonly Project _project;
        public ProjectChildrenType ChildrenType { get; private set; }  

        public ProjectViewModel(Project project,  ProjectChildrenType childrenType) 
            : base(null, true)
        {
            _project = project;
            this.ChildrenType = childrenType;
        }

        public string ProjectName
        {
            get { return _project.ProjectName; }
        }

        protected override void LoadChildren()
        {
            if (this.ChildrenType == ProjectChildrenType.TestPlan)
            {
                foreach (TestCase testCase in DataProvider.GetTestCases(_project))
                    base.Children.Add(new TestCaseViewModel(testCase, this));
            }
            //else if (this.ChildrenType == ProjectChildrenType.ObjectRepository)
            //{
            //    foreach (UIField testCase in DataProvider.GetTestObjects())
            //        base.Children.Add(new UITestControlViewModel(testCase, this));
            //}
            else if (this.ChildrenType == ProjectChildrenType.TestLab)
            {
                foreach (TestCase testCase in DataProvider.GetTestCases(_project))
                    base.Children.Add(new TestCaseViewModel(testCase, this));
            }

        }

        #region Button RunClickCommand Code
        private ICommand _AddTestCaseCommand;
        public ICommand AddTestCaseCommand
        {
            get
            {
                return _AddTestCaseCommand ?? (_AddTestCaseCommand = new CommandHandler(() => AddTestCase(), _canExecute));
            }
        }

        private ICommand _AddFolderCommand;
        public ICommand AddFolderCommand
        {
            get
            {
                return _AddFolderCommand ?? (_AddFolderCommand = new CommandHandler(() => AddFolder(), _canExecute));
            }
        }

        private object AddFolder()
        {
            throw new NotImplementedException();
        }


        private bool _canExecute = true;
        public void AddTestCase()
        {
            // call TestAutomation code here..
           // TestCaseRunner testStepRunner = new TestCaseRunner();
            MessageBox.Show("ok, i got call for add test case");
            if (this.ChildrenType == ProjectChildrenType.TestPlan)
            {
                base.Children.Add(
                    new TestCaseViewModel( new TestCase("<New Test Case>") , this)
                    );
            }
        }

        #endregion


        private ObservableCollection<Project> _ProjectsData;
        public ObservableCollection<Project> ProjectsData
        {
            get { return _ProjectsData; }
            set { _ProjectsData = value;
                NotifyPropertyChanged("ProjectsData");
            }
        }
        
    }
}
