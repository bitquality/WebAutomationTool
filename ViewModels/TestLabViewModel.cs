using CommandTestAutomation.DAL;
using CommandTestAutomation.Helpers;
using CommandTestAutomation.Interfaces;
using CommandTestAutomation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace CommandTestAutomation.ViewModels
{
    //Viewmodel code
    public class TestLabViewModel : ViewModelBase,INotifyPropertyChanged
    {
        // Create the token source.
        CancellationTokenSource cts = null;// new CancellationTokenSource();

        public TestLabViewModel()
        {  

        }      

        private INode _SelectedTreeViewItem;
        public INode SelectedTreeViewItem
        {
            get
            {
                return _SelectedTreeViewItem;
            }
            set
            {
                _SelectedTreeViewItem = value;
                NotifyPropertyChanged("SelectedTreeViewItem");
            }
        }

        #region Button commands Code


        private bool _canExecute = true;

        private ICommand _TestRunClickCommand;
        public ICommand TestRunClickCommand
        {
            get
            {
                return _TestRunClickCommand ?? (_TestRunClickCommand = new CommandHandler(() => StartTestRun(), _canExecute));
            }
        }

        private void StartTestRun()
        {
            if( (SelectedTreeViewItem == null) || (!(SelectedTreeViewItem is  TestCaseNode)) ||(
                (SelectedTreeViewItem is TestCaseNode) && ((SelectedTreeViewItem as TestCaseNode).TestStepsData.Count==0)
                ) 
                )
            {
                MessageBox.Show("Looks like there are no steps to run!");
                return; 
            }

            // Create the token source.
            //CancellationTokenSource cts = new CancellationTokenSource();
            cts = new CancellationTokenSource();

            // Pass the token to the cancelable operation.
            ThreadPool.QueueUserWorkItem(new WaitCallback(RunSelectedTestCase), cts.Token);

        
        }
       
        private void RunSelectedTestCase(object obj)
        {
            CancellationToken token = (CancellationToken)obj;
            
            foreach (var item in (SelectedTreeViewItem as TestCaseNode).TestStepsData)
            {
                if (token.IsCancellationRequested)
                {
                   //if it reaches this conditoin it means execution has been interrupted
                    return;
                }
                try
                {
                    TestCaseRunner testStepRunner = new TestCaseRunner();
                    item.TestStepStatus = testStepRunner.RunTestStep(item);
                }
                catch (Exception ex)
                {

                    item.TestStepStatus = Enums.StepRunStatus.FAILED;
                }               
                            
            }

            Application.Current.Dispatcher.Invoke(new Action(() => { Application.Current.MainWindow.Activate(); }));

            if (cts!=null)
            {
                // Request cancellation.
                cts.Cancel();

                //Thread.Sleep(2500);

                // Cancellation should have happened, so call Dispose.
                cts.Dispose();

                cts = null;
            }
         

            MessageBox.Show("Completed executing the tests: ");
        }


        private ICommand _TestRunStopClickCommand;
        public ICommand TestRunStopClickCommand
        {
            get
            {
                return _TestRunStopClickCommand ?? (_TestRunStopClickCommand = new CommandHandler(() => StopTestRun(), _canExecute));
            }
        }

        private void StopTestRun()
        {
            if (cts == null)
            {
                return;
            }
            // Request cancellation.
            cts.Cancel();
          
            //Thread.Sleep(2500);
            
            // Cancellation should have happened, so call Dispose.
            cts.Dispose();

            cts = null;

            Application.Current.MainWindow.Activate();
            MessageBox.Show("Interrupted test executions from Lab.");
        }
        #endregion


    }
}
