using CommandTestAutomation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandTestAutomation.DAL;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommandTestAutomation.Helpers;
using System.ComponentModel;
using CommandTestAutomation.Models;

namespace CommandTestAutomation.Models
{
    public class FolderNode : NodeBase, INodeWithChildren
    {
        //initialize default values
        public FolderNode()
        {
            Children = new ObservableCollection<INode>();
        }

        private ObservableCollection<INode> _Children;

        public ObservableCollection<INode> Children
        {
            get { return _Children; }
            set { _Children = value; NotifyPropertyChanged("Children"); }
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


       
        
   
        private string _NodeName;

        public string NodeName
        {
            get { return _NodeName; }
            set
            {
                _NodeName = value;
                NotifyPropertyChanged("NodeName");
            }
        }


        

       


  

       
    }//cls
}//ns
