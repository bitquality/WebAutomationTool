using CommandTestAutomation.Helpers;
using CommandTestAutomation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CommandTestAutomation.ViewModels
{

    /// <summary>
    /// Base class for all ViewModel classes displayed by TreeViewItems.  
    /// This acts as an adapter between a raw data object and a TreeViewItem.
    /// </summary>
    public class ITreeViewItemViewModel : ViewModelBase
    {
        #region Data

        static readonly ITreeViewItemViewModel DummyChild = new ITreeViewItemViewModel();

       
        readonly ITreeViewItemViewModel _parent;

        bool _IsNodeExpanded;
        bool _IsNodeSelected;

        #endregion // Data

        #region Constructors

        public ITreeViewItemViewModel(ITreeViewItemViewModel parent, bool lazyLoadChildren)
        {
            _parent = parent;

            _Children = new ObservableCollection<ITreeViewItemViewModel>();

            if (lazyLoadChildren)
                _Children.Add(DummyChild);
        }

        // This is used to create the DummyChild instance.
        private ITreeViewItemViewModel()
        {
        }

        #endregion // Constructors

        #region Presentation Members

        #region Children

        private ObservableCollection<ITreeViewItemViewModel> _Children;
        /// <summary>
        /// Returns the logical child items of this object.
        /// </summary>
        public ObservableCollection<ITreeViewItemViewModel> Children
        {
            get {
                // this condition is specific to test case view model
                    //if (this is TestCaseViewModel)//if the treeviewitem reaches TestCase, let's not load further children.
                    //{
                    //    return null;
                    //}
                    return _Children;
            }
            set
            {

                _Children = value;
                    NotifyPropertyChanged("Children");
                
            }
        }

      
        #endregion // Children

        #region HasLoadedChildren

        /// <summary>
        /// Returns true if this object's Children have not yet been populated.
        /// </summary>
        public bool HasDummyChild
        {
            get { return this.Children!=null && this.Children.Count == 1 && this.Children[0] == DummyChild; }
        }

        #endregion // HasLoadedChildren

        #region IsNodeExpanded
        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is expanded.
        /// </summary>
        public bool IsNodeExpanded
        {
            get { return _IsNodeExpanded; }
            set
            {
                if (value != _IsNodeExpanded)
                {
                    _IsNodeExpanded = value;
                    this.NotifyPropertyChanged("IsNodeExpanded");
                }

                // Expand all the way up to the root.
                if (_IsNodeExpanded && _parent != null)
                    _parent.IsNodeExpanded = true;

                // Lazy load the child items, if necessary.
                if (this.HasDummyChild)
                {
                    this.Children.Remove(DummyChild);
                    this.LoadChildren();
                }
            }
        }
        #endregion 

        #region IsNodeSelected
        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is selected.
        /// </summary>
        public bool IsNodeSelected
        {
            get { return _IsNodeSelected; }
            set
            {
                if (value != _IsNodeSelected)
                {
                    _IsNodeSelected = value;
                    if (this.Children == null)
                    {                        
                        this.LoadChildren();
                    }                    
                    this.NotifyPropertyChanged("IsNodeSelected");
                }
            }
        }      
        #endregion // IsNodeSelected

        #region LoadChildren

        /// <summary>
        /// Invoked when the child items need to be loaded on demand.
        /// Subclasses can override this to populate the Children collection.
        /// </summary>
        protected virtual void LoadChildren() { }
        

        #endregion // LoadChildren

        #region Button RunClickCommand Code
        private ICommand _cmdAddRemove;
        public ICommand cmdAddRemove
        {
            get
            {
                return _cmdAddRemove ?? (_cmdAddRemove = new CommandHandler(() => RunSelectedTestCase(), _canExecute));
            }
        }

        private ICommand _AddTag;
        public ICommand AddTag
        {
            get
            {
                return _AddTag ?? (_AddTag = new CommandHandler(() => RunSelectedTestCase(), _canExecute));
            }
        }

        private bool _canExecute;
        public void RunSelectedTestCase()
        {
            // call TestAutomation code here..
            TestCaseRunner testStepRunner = new TestCaseRunner();
            //testStepRunner.RunTestCase(this.TestCaseName);
        }
        #endregion


        #region Parent

        public ITreeViewItemViewModel Parent
        {
            get { return _parent; }
        }

        #endregion // Parent

        #endregion // Presentation Members

       
    }
}
