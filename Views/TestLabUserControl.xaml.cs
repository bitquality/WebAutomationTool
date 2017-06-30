using CommandTestAutomation.DAL;
using CommandTestAutomation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommandTestAutomation.Views
{
    /// <summary>
    /// Interaction logic for TestLabUserControl.xaml
    /// </summary>
    public partial class TestLabUserControl : UserControl
    {
        public TestLabUserControl()
        {
            InitializeComponent();
            TestLabViewModel viewModel = new TestLabViewModel();
            base.DataContext = viewModel;
        }
    }
}
