using CommandTestAutomation.DAL;
using CommandTestAutomation.Interfaces;
using CommandTestAutomation.Models;
using CommandTestAutomation.Models;
using CommandTestAutomation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTestAutomation.ViewModels
{
    public  class ViewModelBase : INotifyPropertyChanged
    {
       
        public  ViewModelBase()
        {
         
            if (ObjectMapData == null)//&& ObjectMapData.Count == 0)
            {
                RootNode rootNode = new RootNode() { NodeName = "Projects" };
                rootNode.Children = DataProvider.GetUIObjects() ?? new ObservableCollection<INode>();
                ObjectMapData = new ObservableCollection<INode> { rootNode };
            }

            if (ProjectData == null)
            {
                RootNode rootNode = new RootNode() { NodeName = "Projects" };
                rootNode.Children = DataProvider.GetTestCases() ?? new ObservableCollection<INode>();
                ProjectData = new ObservableCollection<INode> { rootNode };
            }



        }

        #region CommonDataCollection
      

        private static ObservableCollection<SystemVariable> _SystemVariableData;
        public static ObservableCollection<SystemVariable> SystemVariableData
        {
            get { return _SystemVariableData; }
            set
            {
                _SystemVariableData = value;
                //NotifiyPropertyChanged("SystemVariableData");
            }
        }
        private static ObservableCollection<INode> _ProjectData;

        public static ObservableCollection<INode> ProjectData
        {
            get { return _ProjectData; }
            set
            {
                _ProjectData = value;
                // NotifyPropertyChanged("ObjectMapData");            
            }
        }




        private   static ObservableCollection<INode> _ObjectMapData;

        public  static ObservableCollection<INode> ObjectMapData
        {
            get { return _ObjectMapData; }
            set { _ObjectMapData = value;
               // NotifyPropertyChanged("ObjectMapData");            
            }
        }

        #endregion


        #region INotifyPropertyChanged Members



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual  void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members
    }
}
