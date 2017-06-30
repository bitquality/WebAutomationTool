using CommandTestAutomation.Models;
using CommandTestAutomation.ViewModels;
using PortableAutomation.ViewModels;
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
    /// Interaction logic for UIFieldTreeViewControl.xaml
    /// </summary>
    public partial class ObjectTreeViewControl : UserControl
    {

        public ObjectTreeViewControl()
        {
            InitializeComponent();
           
            //this.DataContext = new ObjectRepositoryTreeViewModel();
        }

        //public static readonly DependencyProperty TextProperty = DependencyProperty.Register("SelectedObjectTreeItem",
        //    typeof(object), typeof(ObjectTreeViewControl));//Write Namespace of your UserControl where I mentioned

        //public object SelectedObjectTreeItem
        //{
        //    get { return GetValue(TextProperty); }
        //    set
        //    {
        //        SetValue(TextProperty,value);
        //    }
        //}

    }
}
