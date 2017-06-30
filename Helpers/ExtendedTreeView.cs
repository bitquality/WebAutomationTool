using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CommandTestAutomation.Helpers
{
    #region fix1
    //public class ExtendedTreeView : TreeView, INotifyPropertyChanged
    //{
    //    public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register("SelectedItem",
    //        typeof(Object), typeof(ExtendedTreeView), new PropertyMetadata(null));
    //    public new Object SelectedItem
    //    {
    //        get { return (Object)GetValue(SelectedItemProperty); }
    //        set
    //        {
    //            SetValue(SelectedItemsProperty, value);
    //            NotifyPropertyChanged("SelectedItem");
    //        }
    //    }

    //    public ExtendedTreeView()
    //        : base()
    //    {
    //        base.SelectedItemChanged += new RoutedPropertyChangedEventHandler<Object>(MyTreeView_SelectedItemChanged);
    //    }

    //    private void MyTreeView_SelectedItemChanged(Object sender, RoutedPropertyChangedEventArgs<Object> e)
    //    {
    //        this.SelectedItem = base.SelectedItem;
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;
    //    private void NotifyPropertyChanged(String aPropertyName)
    //    {
    //        if (PropertyChanged != null)
    //            PropertyChanged(this, new PropertyChangedEventArgs(aPropertyName));
    //    }
    //}
    #endregion

    #region fix2
    public class ExtendedTreeView : TreeView
    {
        public ExtendedTreeView()
            : base()
        {
            this.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(___ICH);
        }

        void ___ICH(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (SelectedItem != null)
            {
                SetValue(SelectedItem_Property, SelectedItem);

            }
        }

        public object SelectedItem_
        {
            get
            {
                return (object)GetValue(SelectedItem_Property);
            }
            set
            {
                SetValue(SelectedItem_Property, value);
            }
        }


        public static readonly DependencyProperty SelectedItem_Property =
            DependencyProperty.Register("SelectedItem_", typeof(object), typeof(ExtendedTreeView), new UIPropertyMetadata(null));
    }
    #endregion
}
