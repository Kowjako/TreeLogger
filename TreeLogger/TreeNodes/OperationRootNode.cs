using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeLogger.TreeNodes
{
    public class OperationRootNode : TreeNode
    {
        public OperationRootNode(string caption)
        {
            Text = caption;
            SelectedImageIndex = ImageIndex = 4;
        }
    }
}
