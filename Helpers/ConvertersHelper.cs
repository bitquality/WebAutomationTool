using CommandTestAutomation.DAL;
using CommandTestAutomation.Models;
using CommandTestAutomation.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace CommandTestAutomation.Helpers
{
    class INodeToVisibilityConverter : IValueConverter
    {
        #region Constructors
        /// <summary>
        /// The default constructor
        /// </summary>
        public INodeToVisibilityConverter() { }
        #endregion

        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value!=null)
            {
                //var type = value.GetType();
                if ( (value.GetType() == typeof(TestCaseNode)) || (value.GetType() == typeof(UIFieldNode)))
                {
                    return Visibility.Visible;
                }
               
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility visibility = (Visibility)value;

            if (visibility == Visibility.Visible)
                return true;
            else
                return false;
        }
        #endregion
    }

    public class BoolToVisibleOrHidden : IValueConverter
    {
        #region Constructors
        /// <summary>
        /// The default constructor
        /// </summary>
        public BoolToVisibleOrHidden() { }
        #endregion

        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool bValue = (bool)value;
            if (bValue)
                return Visibility.Visible;
            else
                return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility visibility = (Visibility)value;

            if (visibility == Visibility.Visible)
                return true;
            else
                return false;
        }
        #endregion
    }
    public class PathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            string iconName = "Unknown";
            if (value == null)
            {
                return null;
            }
            if (value is FolderNode)
            {
                iconName = "Folder";
            }
            else if (value is TestCaseNode)
            {
                iconName = "TestCase";
            }
            else if (value is UIFieldNode)
            {
                iconName = "Field";
            }
            else if (value is ProjectNode)
            {
                iconName = "Project";
            }
            else if (value is RootNode)
            {
                iconName = "Root";
            }
            //Console.WriteLine("Value:" + value);
            return "../Images/" + iconName + ".png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }

    public class IsNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value == null);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("IsNullConverter can only be used OneWay.");
        }
    }
    public class BindingProxy : Freezable
    {
        #region Overrides of Freezable

        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }

        #endregion

        public object Data
        {
            get { return (object)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Data.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
    }
    public class ContextMenuConverter : IValueConverter
    {
        public ContextMenu RootMenu { get; set; }
        public ContextMenu ProjectMenu { get; set; }
        public ContextMenu FolderMenu { get; set; }
        public ContextMenu FileMenu { get; set; }

        public ContextMenu UIObjectMenu { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                Type type = value.GetType();
                if (type == typeof(ProjectNode))
                    return ProjectMenu;
                else if (type == typeof(FolderNode))
                    return FolderMenu;
                else if (type == typeof(UIFieldNode))
                    return UIObjectMenu;
                else if (type == typeof(TestCaseNode))
                    return FileMenu;
                else if (type == typeof(RootNode))
                    return RootMenu;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    public class EnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string EnumString;
            try
            {
                EnumString = Enum.GetName((value.GetType()), value);
                return EnumString;
            }
            catch
            {
                return string.Empty;
            }
        }

        // No need to implement converting back on a one-way binding 
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
    public class RowNumberConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            ////get the grid and the item
            //Object item = values[0];
            //DataGrid grid = values[1] as DataGrid;

            //int index = grid.Items.IndexOf(item);

            //return index.ToString();

            Object item = values[0];
            DataGrid grdPassedGrid = values[1] as DataGrid;
            if (grdPassedGrid == null)
            {
                return null;
            }
            int intRowNumber = grdPassedGrid.Items.IndexOf(item) + 1;
            return intRowNumber.ToString();//.PadLeft(2, '0');
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }//end of class

    public class RowToIndexConverter : MarkupExtension, IValueConverter
    {
        static RowToIndexConverter converter;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DataGridRow row = value as DataGridRow;
            if (row != null)
                return row.GetIndex();
            else
                return -1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (converter == null) converter = new RowToIndexConverter();
            return converter;
        }

        public RowToIndexConverter()
        {
        }
    }//end off class

}//end of namespace
