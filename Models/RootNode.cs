using CommandTestAutomation.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTestAutomation.Models
{
    public class RootNode : NodeBase, INodeWithChildren
    {
        public ObservableCollection<INode> Children { get; set; }
        public string NodeName { get; set; }

        //initialize default values
        public RootNode()
        {
            Children = new ObservableCollection<INode>();
          
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
        void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
