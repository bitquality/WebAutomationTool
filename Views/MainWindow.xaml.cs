using CommandTestAutomation.ViewModels;
using EFCodeFirstAutomation.Data;
using EFCodeFirstAutomation.DataAccess;
using System;
using System.Linq;
using System.Windows;

namespace CommandTestAutomation.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainViewModel();

            try
            {            
                // lets initialize db here  temporarily
                IQueryable<Project> query;
                //using (var ctx = new AutomationDbContext(AutomationDbContext.ConnectToSqlServer()))
                using (var ctx = new SqlServerDbContext())
                {
                    //access the data
                    //query = ctx.Projects;

                    // or

                    //force the initialization
                    ctx.Database.Initialize(true);
                }
                    // var count = query.Count();
            }
            catch (Exception)
            {
                throw;
            }

        }

 
    }//cls
}//ns
