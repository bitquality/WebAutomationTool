using CommandTestAutomation.Helpers;
using CommandTestAutomation.ViewModels;
using CommandTestAutomation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandTestAutomation.ViewModels
{
    public class SystemVariableViewModel :  ViewModelBase, INotifyPropertyChanged
    {
        private bool _canExecute = true;

        private ICommand _AddTestStepClickCommand;
        public ICommand AddTestStepClickCommand
        {
            get
            {
                return _AddTestStepClickCommand ?? (_AddTestStepClickCommand = new CommandHandler(() => AddEnvironment(), _canExecute));
            }
        }

        private void AddEnvironment()
        {
            throw new NotImplementedException();
        }

        private ICommand _RemoveTestStepClickCommand;
        public ICommand RemoveTestStepClickCommand
        {
            get
            {
                return _RemoveTestStepClickCommand ?? (_RemoveTestStepClickCommand = new CommandHandler(() => RemoveEnvironment(), _canExecute));
            }
        }

        private void RemoveEnvironment()
        {
            throw new NotImplementedException();
        }

        private SystemVariable _SelectedSystemVariable;
        public SystemVariable SelectedSystemVariable
        {
            get
            {
                return _SelectedSystemVariable;
            }
            set
            {
                _SelectedSystemVariable = value;
                NotifyPropertyChanged("SelectedSystemVariable");
            }
        }
    }//cls
}//eon
