using CommandTestAutomation.DAL;
using CommandTestAutomation.Enums;
using CommandTestAutomation.Helpers;
using CommandTestAutomation.Interfaces;
using CommandTestAutomation.ViewModels;
using CommandTestAutomation.Models;
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
    public class UIFieldNode : NodeBase, INodeWithChildren
    {
        //initialize default values
        public UIFieldNode()
        {
            // Children = new ObservableCollection<INode>();
            // PropertyNames = EnumExtensions.ToPropertyNameObservableCollection<UIFieldEnvironmentType>();
            _UIFieldPropCollection = new ObservableCollection<PropertyNameValueModel>();
            //{
            //    new PropertyNameValueModel() {PropertyName="xyzid",PropertyValue="myvalue" }
            //};
        }

        public ObservableCollection<INode> Children { get; set; }
     
        private string _NodeName;
        public string NodeName
        {
            get { return _NodeName; }
            set { _NodeName = value; NotifyPropertyChanged("NodeName"); }
        }


        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }

            set
            {
                _isSelected = value;
                NotifyPropertyChanged("IsSelected");
            }
        }

        private bool _IsInEditMode;
        public bool IsInEditMode
        {
            get { return _IsInEditMode; }

            set
            {
                _IsInEditMode = value;
                NotifyPropertyChanged("IsInEditMode");
            }
        }

        private WebUIElementType _UIFieldType;

        public WebUIElementType UIFieldType
        {
            get { return _UIFieldType; }
            set { _UIFieldType = value;
                NotifyPropertyChanged("UIFieldType");
            }
        }
        
      



        private AutomationEnvironmentType _UIFieldEnvironmentType;

        public AutomationEnvironmentType UIFieldEnvironmentType
        {
            get { return _UIFieldEnvironmentType; }
            set
            {
                _UIFieldEnvironmentType = value;
                NotifyPropertyChanged("UIFieldEnvironmentType");
            }
        }
        

        private ObservableCollection<PropertyNameValueModel> _UIFieldPropCollection;
        public ObservableCollection<PropertyNameValueModel> UIFieldPropCollection
        {
            get { return _UIFieldPropCollection; }
            set { _UIFieldPropCollection = value;
                NotifyPropertyChanged("UIFieldPropCollection"); }
        }



        public bool IsParentRoot { get; set; }
       

        private bool _canExecute = true;

        //private ICommand _EditUIObjectClickCommand;
        //public ICommand EditUIObjectClickCommand
        //{
        //    get
        //    {
        //        return _EditUIObjectClickCommand ?? (_EditUIObjectClickCommand = new CommandHandler(() => EnableEditClick(), _canExecute));
        //    }
        //}

        bool _IsEditEnabled = false;

        //#region IsExpanded
        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// </summary>
        public bool IsEditEnabled
        {
            get { return _IsEditEnabled; }
            set
            {
                if (value != _IsEditEnabled)
                {
                    _IsEditEnabled = value;
                    NotifyPropertyChanged("IsEditEnabled");
                }

                
            }
        }

        private void EnableEditClick()
        {
            IsEditEnabled = true;
        }

      

       
      

    }//cls
}//ns
