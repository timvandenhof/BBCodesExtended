using System;
using System.Text;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// Description of TableDataNode.
    /// </summary>
    public class TableDataNode : Node
    {
        public TableDataNode()
        {
        }
        
        public override string ToHTML()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Node n in this)
                sb.Append(n.ToHTML());
            return "<td>" + sb.ToString() + "</td>";
        }
        
        public override string[] NodeNames {
            get {
                return new string[] { "td" };
            }
        }
    }
}
