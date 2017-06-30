using EFCodeFirstAutomation.Data;
using CommandTestAutomation.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandTestAutomation.Dialogs;
using System.Windows;
using System.Windows.Input;
using CommandTestAutomation.Helpers;
using CommandTestAutomation.Enums;

namespace CommandTestAutomation.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        
        public MainViewModel()
        {
           
        }

        private bool _canExecute = true;

        private List<string> _TestDataSources;
        public List<string> TestDataSources
        {
            get { return Enum.GetNames(typeof(TestDataSource)).ToList(); }
            set
            {
                _TestDataSources = value;
                NotifyPropertyChanged("TestDataSources");
            }
        }

        private TestDataSource _SelectedTestDataSource;

        public TestDataSource SelectedTestDataSource
        {
            get { return _SelectedTestDataSource; }
            set
            {
                _SelectedTestDataSource = value;
                NotifyPropertyChanged("SelectedTestDataSource");
            }
        }

        private ICommand _AboutClickCommand;
        public ICommand AboutClickCommand
        {
            get
            {
                return _AboutClickCommand ?? (_AboutClickCommand = new CommandHandler(() => ShowAbout(), _canExecute));
            }
        }

        private void ShowAbout()
        {
            var dialog = new About();
            if (dialog.ShowDialog() == true)
            {
                MessageBox.Show("You Opened help dialog! ");
            }
        }
    }//cls
}//eofn
