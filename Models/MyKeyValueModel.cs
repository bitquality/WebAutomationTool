using CommandTestAutomation.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTestAutomation.Models
{
    public class MyKeyValueModel<T>
    {
        public T Key { get; set; }
        public string Value { get; set; }
    }
}
