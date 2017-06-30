using CommandTestAutomation.DAL;
using CommandTestAutomation.Helpers;
using CommandTestAutomation.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandTestAutomation.Models
{
    public class UIField : INotifyPropertyChanged
    {
        public UIField(UIField parent = null)
        {
            _Children = new ObservableCollection<UIField>();

            Parent = parent;
        }
        public WebUIElementType UIFieldType { get; set; }

        public AutomationEnvironmentType UIFieldEnvironmentType { get; set; }

        public ObservableCollection<MyKeyValueModel<WebAttributeBy>> UIFieldPropCollection { get; set; }
      

        // Add all of the properties of a UIField here. In this example,
        // all we have is a name and whether we are expanded.
        private string _UIFieldName;
        public string UIFieldName
        {
            get { return _UIFieldName; }
            set
            {
                if (_UIFieldName != value)
                {
                    _UIFieldName = value;
                    OnPropertyChanged("UIFieldName");
                }
            }
        }

       
        

        public bool IsParentRoot { get; set; }
       

        private bool _canExecute = true;
     
        private ICommand _AddUIObjectCommand;
        public ICommand AddUIObjectCommand
        {
            get
            {
                return _AddUIObjectCommand ?? (_AddUIObjectCommand = new CommandHandler(() => AddNewUIField(), _canExecute));
            }
        }

        private  void AddNewUIField()
        {
            //var dadta = new ObservableCollection<string>(Enum.GetValues(typeof(AutomationType)).Cast<string>().ToList());
            UIField uiField = new UIField(){
                UIFieldName = "<New UI Object>",
                UIFieldPropCollection = EnumExtensions.ToObservableCollection<WebAttributeBy>()
            };
            this.Children.Add(uiField);
         
        }


        #region IsNodeSelected
        private bool _IsNodeSelected ;
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
                    this.OnPropertyChanged("IsNodeSelected");
                }
            }
        }

        private bool _IsNodeExpanded;
        public bool IsNodeExpanded
        {
            get { return _IsNodeExpanded; }
            set
            {
                if (_IsNodeExpanded != value)
                {
                    _IsNodeExpanded = value;
                    OnPropertyChanged("IsNodeExpanded");
                }
            }
        }


        private void LoadChildren()
        {
            throw new NotImplementedException();
        }
        #endregion // IsNodeSelected

        private ObservableCollection<UIField> _Children;
        // Children are required to use this in a TreeView
        public IList<UIField> Children { get { return _Children; } }

        // Parent is optional. Include if you need to climb the tree
        // from code. Not usually necessary.
        public UIField Parent { get; private set; }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members        


    }
}
