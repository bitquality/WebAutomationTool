using CommandTestAutomation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandTestAutomation.DAL;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CommandTestAutomation.Helpers;
using System.Windows;
using System.Runtime.CompilerServices;
using CommandTestAutomation.Models;

namespace CommandTestAutomation.Models
{
    public class TestCaseNode : NodeBase, INode
    {
        public TestCaseNode()
        {
          _TestStepsData = new ObservableCollection<TestStep>();
            //foreach (var item in DataProvider.GetTestSteps("Login"))
            //{
            //    _TestStepsData.Add(item);
            //}
        
        }

        private string _NodeName;

        public string NodeName
        {
            get { return _NodeName; }
            set { _NodeName = value;
                NotifyPropertyChanged("NodeName");
            }
        }

        //public string NodeName { get; set; }

        private ObservableCollection<TestStep> _TestStepsData;
        public ObservableCollection<TestStep> TestStepsData
        {
            get
            {
                return _TestStepsData;
            }
            set
            {
                _TestStepsData = value;
                NotifyPropertyChanged("TestStepsData");
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










    }//cls
}//ns node
