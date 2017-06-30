using CommandTestAutomation.DAL;
using CommandTestAutomation.Enums;
using CommandTestAutomation.Helpers;
using CommandTestAutomation.Interfaces;
using CommandTestAutomation.Models;
using CommandTestAutomation.ViewModels;
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
   
     public class ObjectRepositoryTreeViewModel: ViewModelBase, INotifyPropertyChanged
    {
        public ObjectRepositoryTreeViewModel()
        {
           this.EnvironmentCollection = new ObservableCollection<string>(Enum.GetNames(typeof(AutomationEnvironmentType)).Cast<string>().ToList());
        }

        private ICommand _AddPropertyClickCommand;
        public ICommand AddPropertyClickCommand
        {
            get
            {
                return _AddPropertyClickCommand ?? (_AddPropertyClickCommand = new CommandHandler(() => AddPropertyNameValue(), _canExecute));
            }
        }

        private void AddPropertyNameValue()
        {
            if (SelectedTestObjectTreeViewItem!=null )
            {
                if (SelectedTestObjectTreeViewItem is UIFieldNode)
                {
                    (SelectedTestObjectTreeViewItem as UIFieldNode).UIFieldPropCollection.Add(new PropertyNameValueModel()
                    {
                       PropertyName="Select an item",PropertyValue="<Enter a value>"
                    });
                }
               
            }
            
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
            if (SelectedTestObjectTreeViewItem != null )
            {
                if (! (SelectedTestObjectTreeViewItem is RootNode))
                {
                     if(
                        (  (SelectedTestObjectTreeViewItem as INodeWithChildren).Children == null)  || (
                        ( (SelectedTestObjectTreeViewItem as INodeWithChildren).Children!=null)  && ((SelectedTestObjectTreeViewItem as INodeWithChildren).Children.Count==0 ) )                        
                          )                        
                     {
                        NodeExtensions.DeleteNode(ObjectMapData, SelectedTestObjectTreeViewItem);
                        return;
                    }

                    MessageBox.Show("Don't abandon the children.");
                }
               
            } 
        }

        private ICommand _RemovePropertyClickCommand;
        public ICommand RemovePropertyClickCommand
        {
            get
            {
                return _RemovePropertyClickCommand ?? (_RemovePropertyClickCommand = new CommandHandler(() => RemoveProperty(), _canExecute));
            }
        }

        private void RemoveProperty()
        {
            if (SelectedTestObjectTreeViewItem != null)
            {
                if (SelectedTestObjectTreeViewItem is UIFieldNode)
                {
                    //var propvalueModel = (SelectedTestObjectTreeViewItem as UIFieldNode).SelectedPropertyNameValue;
                    (SelectedTestObjectTreeViewItem as UIFieldNode).UIFieldPropCollection.Remove(SelectedPropertyNameValue);
                }
            }
        }

        private ICommand _SavePropertyClickCommand;
        public ICommand SavePropertyClickCommand
        {
            get
            {
                return _SavePropertyClickCommand ?? (_SavePropertyClickCommand = new CommandHandler(() => SaveProperty(), _canExecute));
            }
        }

        private void SaveProperty()
        {
            MessageBox.Show("save property to db");
        }



        private ObservableCollection<string> _PropertyNameCollection;
        public ObservableCollection<string> PropertyNameCollection
        {
            get { return _PropertyNameCollection; }
            set { _PropertyNameCollection = value; NotifyPropertyChanged("PropertyNameCollection"); }
        }


      
        private void AddNewUIObject()
        {          
          
            if (SelectedTestObjectTreeViewItem !=null && SelectedTestObjectTreeViewItem is FolderNode)
            {
                (SelectedTestObjectTreeViewItem as FolderNode).Children.Add(
                    new UIFieldNode() { NodeName="<New UI Object>"}
                    );
            }
            else if (SelectedTestObjectTreeViewItem != null && SelectedTestObjectTreeViewItem is UIFieldNode)
            {
                (SelectedTestObjectTreeViewItem as UIFieldNode).Children.Add(
                    new UIFieldNode() { NodeName = "<New UI Object>" }
                    );
            }

        }

        private PropertyNameValueModel _SelectedPropertyNameValue;
        public PropertyNameValueModel SelectedPropertyNameValue
        {
            get { return _SelectedPropertyNameValue; }
            set { _SelectedPropertyNameValue = value; NotifyPropertyChanged("SelectedPropertyNameValue"); }
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
            if (SelectedTestObjectTreeViewItem is ProjectNode)
            {
                (SelectedTestObjectTreeViewItem as ProjectNode).Children.Add(new ProjectNode { NodeName = "<New Project>" });

            }
            if (SelectedTestObjectTreeViewItem is RootNode)
            {
                (SelectedTestObjectTreeViewItem as RootNode).Children.Add(new ProjectNode { NodeName = "<New Project>" });

            }
        }

        #region IsExpanded slected enabled
        bool _isExpanded = false;
        bool _isSelected = false;
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
                    this.NotifyPropertyChanged("IsSelected");
                }
            }
        }

        #endregion // IsSelected

        
        private INode _SelectedTestObjectTreeViewItem;
        public INode SelectedTestObjectTreeViewItem
        {
            get
            {
                return _SelectedTestObjectTreeViewItem  ;
            }
            set
            {
                _SelectedTestObjectTreeViewItem  = value;
                NotifyPropertyChanged("SelectedTestObjectTreeViewItem");
                if (_SelectedTestObjectTreeViewItem is UIFieldNode)
                {


                    if ((_SelectedTestObjectTreeViewItem as UIFieldNode).UIFieldEnvironmentType == AutomationEnvironmentType.Web)
                    {
                        this.UIFieldTypeCollection = new ObservableCollection<string>(Enum.GetNames(typeof(WebUIElementType)).Cast<string>().ToList());
                        this.PropertyNameCollection = EnumExtensions.ToPropertyNameObservableCollection<WebAttributeBy>();
                    }
                    else if ((_SelectedTestObjectTreeViewItem as UIFieldNode).UIFieldEnvironmentType == AutomationEnvironmentType.Windows)
                    {
                        this.UIFieldTypeCollection = new ObservableCollection<string>(Enum.GetNames(typeof(WebUIElementType)).Cast<string>().ToList());
                        this.PropertyNameCollection = EnumExtensions.ToPropertyNameObservableCollection<WebAttributeBy>();
                    }
                    else
                    {
                        this.UIFieldTypeCollection = new ObservableCollection<string>();
                        this.PropertyNameCollection = new ObservableCollection<string>();

                    }
                    NotifyPropertyChanged("UIFieldTypeCollection");
                    NotifyPropertyChanged("PropertyNameCollection");
                }


            }
        }

     

        private ICommand _AddUIObjectCommand;
        public ICommand AddUIObjectCommand
        {
            get
            {
                return _AddUIObjectCommand ?? (_AddUIObjectCommand = new CommandHandler(() => AddNewUIObject(), _canExecute));
            }
            set { }
        }


        private void EnableEdit(bool bSaveToDB=false)
        {

            if (SelectedTestObjectTreeViewItem != null)
            {
                if (SelectedTestObjectTreeViewItem.NodeName == string.Empty)
                {
                    MessageBox.Show("Sorry, Can't give an Empty node name");
                    return;
                }

                if (bSaveToDB)
                {
                    SelectedTestObjectTreeViewItem.IsInEditMode = false;
                    //write code below to commit changes to db
                }
                else
                    SelectedTestObjectTreeViewItem.IsInEditMode = true;
            }
        }


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

      

        private void EditUIField()
        {
            throw new NotImplementedException();
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

        private void RemoveTestCase()
        {
            throw new NotImplementedException();
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
            FolderNode newFolder = new FolderNode()
            {
                NodeName = "<New Folder *>",
               
            };

            if (SelectedTestObjectTreeViewItem is FolderNode)
            {
                (SelectedTestObjectTreeViewItem as FolderNode).Children.Add(newFolder);
            }

            if (SelectedTestObjectTreeViewItem is ProjectNode)
            {
                (SelectedTestObjectTreeViewItem as ProjectNode).Children.Add(newFolder);
            }

        }

        private bool _canExecute = true;



        #endregion

        #region StaticData from Db for enum env,control type

        private ObservableCollection<string> _EnvironmentCollection;

        public ObservableCollection<string> EnvironmentCollection
        {
            get { return _EnvironmentCollection; }
            set { _EnvironmentCollection = value;
                NotifyPropertyChanged("EnvironmentCollection");

            }
        }


        //public ObservableCollection<string> EnvironmentCollection
        //{
        //    get
        //    {
        //        return new ObservableCollection<string>(Enum.GetNames(typeof(AutomationEnvironmentType)).Cast<string>().ToList());
        //    }
        //}


        private ObservableCollection<string> _UIFieldTypeCollection;

        public ObservableCollection<string> UIFieldTypeCollection
        {
            get { return _UIFieldTypeCollection; }
            set { _UIFieldTypeCollection = value; NotifyPropertyChanged("UIFieldTypeCollection"); }
        }


        //public ObservableCollection<string> UIFieldTypeCollection
        //{
        //    get
        //    {
        //        return new ObservableCollection<string>(Enum.GetNames(typeof(WebUIElementType)).Cast<string>().ToList());

        //    }
        //}
        #endregion



    }//cls
}//ns
