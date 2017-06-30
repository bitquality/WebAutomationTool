using CommandTestAutomation.Interfaces;
using CommandTestAutomation.Models;
using CommandTestAutomation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CommandTestAutomation.Helpers
{
   public class NodeExtensions
    {
        public static void DeleteNode(ObservableCollection<INode> nodes, INode NodeToRemove)
        {
            if (nodes == null)
            {
                MessageBox.Show("Collection is empty. Can't delete.");
                return;
            }
            bool foundNodeToDelete = false;
            foreach (var node in nodes)
            {
                if (
                    node.NodeName == NodeToRemove.NodeName &&
                    (  NodeToRemove.ToString() ==   node.ToString())
                    )
                {
                 
                    foundNodeToDelete = true;
                    break;
                }

                if (node is RootNode)
                {
                    DeleteNode((node as RootNode).Children, NodeToRemove);
                }
                else if(node is FolderNode)
                {
                    DeleteNode((node as FolderNode).Children, NodeToRemove);
                }
                else if (node is ProjectNode)
                {
                    DeleteNode((node as ProjectNode).Children, NodeToRemove);
                }
                //else if (node is UIFieldNode)
                //{
                //    break;
                //}
                //else if (node is TestCaseNode)
                //{
                //    break;
                //}

            }//end of foreach
            if (foundNodeToDelete)
            {
                nodes.Remove(NodeToRemove);
            }
        }//eom

    }//cls
}//ns
