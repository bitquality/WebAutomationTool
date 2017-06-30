using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandTestAutomation;
using CommandTestAutomation.DAL;
using System.ComponentModel;

namespace CommandTestAutomation.Interfaces
{
   public interface INode
    {
        string NodeName { get; set; }

        bool IsSelected { get; set; }

        bool IsInEditMode { get; set; }


    }
}
