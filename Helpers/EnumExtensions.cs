using CommandTestAutomation.DAL;
using CommandTestAutomation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandTestAutomation.Helpers
{
    public static class EnumExtensions
    {

      
        public static string GetDisplayName(this Enum enumValue)
            {
                return enumValue.GetType()
                                .GetMember(enumValue.ToString())
                                .First()
                                .GetCustomAttribute<DisplayAttribute>()
                                .GetName();
            }
        
        public static string GetDescription( Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DisplayNameAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DisplayNameAttribute)) as DisplayNameAttribute;
                    if (attr != null)
                    {
                        return attr.DisplayName;
                    }
                }
            }
            return null;
        }

        public static ObservableCollection<MyKeyValueModel<T>> ToPropertyValuePairObservableCollection<T>()
        {
            ObservableCollection<MyKeyValueModel<T>> data = new ObservableCollection<MyKeyValueModel<T>>();
            foreach (var item in Enum.GetNames(typeof(T)))
            {
                data.Add(new MyKeyValueModel<T>()
                {
                    Key = (T)Enum.Parse(typeof(T), item),
                    Value = string.Empty

                });
            }
            return data;
        }

        public static ObservableCollection<string> ToPropertyNameObservableCollection<T>()
        {
            ObservableCollection<string> data = new ObservableCollection<string>();
            foreach (var item in Enum.GetNames(typeof(T)))
            {
                data.Add(((T)Enum.Parse(typeof(T), item)).ToString());
            }
            return data;
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

    }//class
}//namespace
