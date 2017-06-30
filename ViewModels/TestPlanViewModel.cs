using CommandTestAutomation.DAL;
using CommandTestAutomation.Enums;
using CommandTestAutomation.Helpers;
using CommandTestAutomation.Interfaces;
using CommandTestAutomation.Models;
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
    //Viewmodel code
    public class TestPlanViewModel : ViewModelBase
    {
        public TestPlanViewModel()
        {  

        }


        private ICommand _DeleteNodeClickCommand;
        public ICommand DeleteNodeClickCommand
        {
            get
            {
                return _DeleteNodeClickCommand ?? (_DeleteNodeClickCommand = new CommandHandler(() => RemoveNode(), _canExecute));
            }
        }

       

        private void RemoveNode()
        {
            if (SelectedTestPlanTreeViewItem != null)
            {
                if (!(SelectedTestPlanTreeViewItem is RootNode))
                {
                    if (
                       ((SelectedTestPlanTreeViewItem as INodeWithChildren).Children == null) || (
                       ((SelectedTestPlanTreeViewItem as INodeWithChildren).Children != null) && ((SelectedTestPlanTreeViewItem as INodeWithChildren).Children.Count == 0))
                         )
                    {
                        NodeExtensions.DeleteNode(ProjectData, SelectedTestPlanTreeViewItem);
                        return;
                    }

                    MessageBox.Show("Don't abandon the children.");
                }

            }
        }
        private void RenameCommit()
        {
            if (SelectedTestPlanTreeViewItem != null)
                SelectedTestPlanTreeViewItem.IsInEditMode = true;
        }

       

      
        bool _isExpanded = false;
        bool _isSelected = false;
        #region IsExpanded
        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// </summary>
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (value != _isExpanded)
                {
                    _isExpanded = value;
                    this.NotifyPropertyChanged("IsExpanded");
                }

                // Expand all the way up to the root.
                //if (_isExpanded && _parent != null)
                //    _parent.IsExpanded = true;
            }
        }

        #endregion // IsExpanded

      
        private ICommand _EditNodeClickCommand;
        public ICommand EditNodeClickCommand
        {
            get
            {
                return _EditNodeClickCommand ?? (_EditNodeClickCommand = new CommandHandler(() => EnableEdit(),
                    _canExecute));
            }
        }

        private ICommand _CommitEditClickCommand;
        public ICommand CommitEditClickCommand
        {
            get
            {
                return _CommitEditClickCommand ?? (_CommitEditClickCommand = new CommandHandler(() => EnableEdit(true),
                    _canExecute));
            }
        }


        #region IsSelected

        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is selected.
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    NotifyPropertyChanged("IsSelected");
                }
            }
        }

        #endregion // IsSelected      

        #region Button commands Code
        private ICommand _RemoveTestCaseCommand;
        public ICommand RemoveTestCaseCommand
        {
            get
            {
                return _RemoveTestCaseCommand ?? (_RemoveTestCaseCommand = new CommandHandler(() => RemoveTestCase(), _canExecute));
            }
        }

        
        private ICommand _AddTestCaseClickCommand;
        public ICommand AddTestCaseClickCommand
        {
            get
            {
                return _AddTestCaseClickCommand ?? (_AddTestCaseClickCommand = new CommandHandler(() => AddNewTestCase(), _canExecute));
            }
        }

        private ICommand _AddTestStepClickCommand;
        public ICommand AddTestStepClickCommand
        {
            get
            {
                return _AddTestStepClickCommand ?? (_AddTestStepClickCommand = new CommandHandler(() => AddTestStep(), _canExecute));
            }
        }

        private ICommand _RemoveTestStepClickCommand;
        public ICommand RemoveTestStepClickCommand
        {
            get
            {
                return _RemoveTestStepClickCommand ?? (_RemoveTestStepClickCommand = new CommandHandler(() => RemoveTestStep(), _canExecute));
            }
        }

        private void RemoveTestStep()
        {
            if (SelectedTestStep!=null)
            {
               (SelectedTestPlanTreeViewItem as TestCaseNode).TestStepsData.Remove(SelectedTestStep);
            }
        }

        private void AddTestStep()
        {
            // just to avoid errors
            if (!(SelectedTestPlanTreeViewItem is TestCaseNode))
            {
                return;
            }
            //update database
            (SelectedTestPlanTreeViewItem as TestCaseNode).TestStepsData.Add(

                 new TestStep()
                 {
                     AutomationTypePlatform = AutomationEnvironmentType.Web,
                     
                     TestStepFieldActionName = "",
                     TestStepFieldActionValue = "",
                     UiFieldNodeItem =
                                                         new UIFieldNode()
                                                         {
                                                             NodeName = "<New UI Object>",
                                                             UIFieldType = WebUIElementType.DoNotKnow,
                                                         }

                 });
        }

        

        private INode _SelectedTestPlanTreeViewItem;
        public INode SelectedTestPlanTreeViewItem
        {
            get
            {
                return _SelectedTestPlanTreeViewItem;
            }
            set
            {
                if (_SelectedTestPlanTreeViewItem!=null && _SelectedTestPlanTreeViewItem != value)
                {
                    //set previously selected node properties to false . the isineditmode is not setto false when mouse leave happens on node which is in edit mode
                    _SelectedTestPlanTreeViewItem.IsSelected = false;
                    _SelectedTestPlanTreeViewItem.IsInEditMode = false;
                }
                _SelectedTestPlanTreeViewItem = value;               
                NotifyPropertyChanged("SelectedTestPlanTreeViewItem");
            }
        }


        private TestStep _SelectedTestStep;
        public TestStep SelectedTestStep
        {
            get
            {
                return _SelectedTestStep;
            }
            set
            {
                _SelectedTestStep = value;
                NotifyPropertyChanged("SelectedTestStep");
            }
        }
        private void AddNewTestCase()
        {
            if( (SelectedTestPlanTreeViewItem!=null) &&  (  SelectedTestPlanTreeViewItem is FolderNode))
            {
                (SelectedTestPlanTreeViewItem as FolderNode).Children.Add(new TestCaseNode { NodeName = "New Test Case*" });
            }
          
        }

        private ICommand _AddProjectClickCommand;
        public ICommand AddProjectClickCommand
        {
            get
            {
                return _AddProjectClickCommand ?? (_AddProjectClickCommand = new CommandHandler(() => AddProject(), _canExecute));
            }
        }

        private void AddProject()
        {
            if (SelectedTestPlanTreeViewItem is ProjectNode)
            {
                (SelectedTestPlanTreeViewItem as ProjectNode).Children.Add(new ProjectNode { NodeName = "<New Project>" });

            }
            if (SelectedTestPlanTreeViewItem is RootNode)
            {
                (SelectedTestPlanTreeViewItem as RootNode).Children.Add(new ProjectNode { NodeName = "<New Project>" });

            }
        }

        // AddFolderClickCommand
        private ICommand _AddFolderClickCommand;
        public ICommand AddFolderClickCommand
        {
            get
            {
                return _AddFolderClickCommand ?? (_AddFolderClickCommand = new CommandHandler(() => AddFolder(), _canExecute));
            }
        }

        private void AddFolder()
        {
            if (SelectedTestPlanTreeViewItem is FolderNode)
            {
                (SelectedTestPlanTreeViewItem as FolderNode).Children.Add(new FolderNode { NodeName = "<New Folder>" });

            }
            else if (SelectedTestPlanTreeViewItem is ProjectNode)
            {
                (SelectedTestPlanTreeViewItem as ProjectNode).Children.Add(new FolderNode { NodeName = "<New Folder>" });

            }

        }
        private void SaveTestStep()
        {
            //call database and save this step
            MessageBox.Show("Changes should be saved to database!");
        }


        private ICommand _SaveTestStepClickCommand;
        public ICommand SaveTestStepClickCommand
        {
            get
            {
                return _SaveTestStepClickCommand ?? (_SaveTestStepClickCommand = new CommandHandler(() => SaveTestStep(), _canExecute));
            }
        }
        
        private void RemoveTestCase()
        {
            if (SelectedTestPlanTreeViewItem!=null)
            {
                if (SelectedTestPlanTreeViewItem is TestCaseNode)
                {

                }
            }
        }

        private void EnableEdit(bool bSaveToDB = false)
        {

            if (SelectedTestPlanTreeViewItem != null)
            {
                if (SelectedTestPlanTreeViewItem.NodeName == string.Empty)
                {
                    MessageBox.Show("Sorry, Can't give an Empty node name");
                    return;
                }
                if (bSaveToDB)
                {
                    SelectedTestPlanTreeViewItem.IsInEditMode = false;
                    // SelectedTestPlanTreeViewItem.IsSelected = false;
                    //write code below to commit changes to db
                }
                else
                    SelectedTestPlanTreeViewItem.IsInEditMode = true;
            }
        }


       

        private bool _canExecute = true;    
        #endregion
        
    }
}
