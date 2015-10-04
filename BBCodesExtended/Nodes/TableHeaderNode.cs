using System;
using System.Text;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// Description of TableHeaderNode.
    /// </summary>
    public class TableHeaderNode : Node
    {
        public TableHeaderNode()
        {
        }
        
        public override string ToHTML()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Node n in this)
                sb.Append(n.ToHTML());
            return "<th>" + sb.ToString() + "</th>";
        }
        
        public override string[] NodeNames {
            get {
                return new string[] { "th" };
            }
        }
    }
}
