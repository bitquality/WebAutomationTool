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
using System.Windows.Input;

namespace CommandTestAutomation.Models
{
    public class ProjectNode : NodeBase, INodeWithChildren
    {

        //initialize default values
        public ProjectNode()
        {
            Children = new ObservableCollection<INode>();
        }

        private ObservableCollection<INode> _Children;

        public ObservableCollection<INode> Children
        {
            get { return _Children; }
            set { _Children = value; NotifyPropertyChanged("Children"); }
        }

      //  public ObservableCollection<INode> Children { get; set; }

        private string _NodeName;
        public string NodeName
        {
            get { return _NodeName; }
            set {
                _NodeName = value;
                NotifyPropertyChanged("NodeName");
            }
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



       
        
        private bool _canExecute = true;

        
        //private ICommand _EditProjectClickCommand;
        //public ICommand EditProjectClickCommand
        //{
        //    get
        //    {
        //        return _EditProjectClickCommand ?? (_EditProjectClickCommand = new CommandHandler(() => EditProject(), _canExecute));
        //    }
        //}

        //private void EditProject()
        //{
        //    IsInEditMode = true;
        //}

        
    }//cls
}//ns
