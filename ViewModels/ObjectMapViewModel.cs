using CommandTestAutomation.DAL;
using CommandTestAutomation.Helpers;
using CommandTestAutomation.Interfaces;
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

namespace PortableAutomation.ViewModels
{
    public class ObjectMapViewModel: INotifyPropertyChanged
    {        
            public ObjectMapViewModel()
            {
               //Project definiation
                _ObjectMapData = new ObservableCollection<INode>();
                _ObjectMapData.Add(new ProjectNode { ItemName = "Root" });

                //initialize and add
                ObservableCollection<INode> ProjectData = new ObservableCollection<INode>();

                //add Root items
                ProjectData.Add(new ProjectNode { ItemName = "ScotiaWeb" });
                ProjectData.Add(new ProjectNode { ItemName = "ScotiaDesktop" });

              ObservableCollection<INode> FolderrData = new ObservableCollection<INode>();

            //add sub items
                FolderrData.Add(new FolderNode { ItemName = "Login" });
                FolderrData.Add(new FolderNode { ItemName = "Account" });
                FolderrData.Add(new FolderNode { ItemName = "Transaction" });
                FolderrData.Add(new FolderNode { ItemName = "Summary" });

                foreach (var item in DataProvider.GetStaticTestObjects())
                {                
                     (FolderrData[0] as INodeWithChildren).Children.Add(item);
               
                 }

                foreach (var item in FolderrData)
                {
                    (ProjectData[0] as INodeWithChildren).Children.Add(item);
                 }

                foreach (var item in ProjectData)
                {
                  (_ObjectMapData[0] as INodeWithChildren).Children.Add(item);
                 }
               

        }

            private ObservableCollection<TestStep> _TestStepsData;
            public ObservableCollection<TestStep> TestStepsData
            {
                get
                {
                    //return _TestStepsData;
                    return _TestStepsData;
                }
                set
                {
                    _TestStepsData = value;
                    NotifiyPropertyChanged("TestStepsData");
                }
            }


            bool _isExpanded = false;
            bool _isSelected = false;
        bool _IsEditEnabled = false;
        public bool IsEditEnabled
        {
            get { return _IsEditEnabled; }
            set
            {
                if (value != _IsEditEnabled)
                {
                    _IsEditEnabled = value;
                    this.NotifiyPropertyChanged("IsEditEnabled");
                }

                // Expand all the way up to the root.
                //if (_isExpanded && _parent != null)
                //    _parent.IsExpanded = true;
            }
        }

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
                        this.NotifiyPropertyChanged("IsExpanded");
                    }

                    // Expand all the way up to the root.
                    //if (_isExpanded && _parent != null)
                    //    _parent.IsExpanded = true;
                }
            }

            #endregion // IsExpanded



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
                        this.NotifiyPropertyChanged("IsSelected");
                    }
                }
            }

            #endregion // IsSelected


            private ObservableCollection<INode> _ObjectMapData;
            public ObservableCollection<INode> ObjectMapData
              {
                get { return _ObjectMapData; }
                set
                {
                    _ObjectMapData = value;
                    NotifiyPropertyChanged("ObjectMapData");
                }
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
                throw new NotImplementedException();
            }

            private bool _canExecute = true;

        

        public ObservableCollection<string> EnvironmentCollection
        {
            get
            {
                return new ObservableCollection<string>(Enum.GetNames(typeof(AutomationEnvironmentType)).Cast<string>().ToList());
            }
        }

        public ObservableCollection<string> ControlTypeCollection
        {
            get
            {
                return new ObservableCollection<string>(Enum.GetNames(typeof(WebUIElementType)).Cast<string>().ToList());

            }
        }
        #endregion

        private UIFieldNode _SelectedFieldItem;
        public UIFieldNode SelectedFieldItem
        {
            get
            {
                return _SelectedFieldItem;
            }
            set
            {
                _SelectedFieldItem = value;
                NotifiyPropertyChanged("SelectedFieldItem");
            }
        }

        //private  UIFieldNode _selectedItem ;
        //// This is public get-only here but you could implement a public setter which also selects the item.
        //// Also this should be moved to an instance property on a VM for the whole tree, otherwise there will be conflicts for more than one tree.
        //public  UIFieldNode SelectedItem
        //{
        //    get {
        //        return _selectedItem;
        //    }
        //    private set
        //    {
        //        if (_selectedItem != value)
        //        {
        //            _selectedItem = value;
        //            //OnSelectedItemChanged();
        //        }
        //    }
        //}

        void NotifiyPropertyChanged(string property)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
            }

            public event PropertyChangedEventHandler PropertyChanged;
        
    }//cls
}//ns
