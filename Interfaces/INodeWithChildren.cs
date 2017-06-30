using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTestAutomation.Interfaces
{
    public interface INodeWithChildren : INode
    {
         ObservableCollection<INode> Children { get; }
    }
}
