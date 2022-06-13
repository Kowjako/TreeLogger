using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeLogger.ViewModels;

namespace TreeLogger.TreeNodes
{
    internal class OperationTreeNode : TreeNode
    {
        internal OperationTreeNode(OperationContract contract)
        {
            Text = contract.Message;
            ImageIndex = (int)contract.MessageSeverity;
            SelectedImageIndex = ImageIndex;
            ToolTipText = contract.Message;
        }
    }
}
