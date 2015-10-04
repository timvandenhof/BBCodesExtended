/*
 * User: elijah
 * Date: 3/15/2012
 * Time: 3:55 PM
 */
using System;
using System.Text;

namespace BBCodes.Nodes
{
    /// <summary>
    /// Description of TableRowNode.
    /// </summary>
    public class TableRowNode : Node
    {
        public TableRowNode()
        {
        }
        
        
        public override string ToHTML()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Node n in this)
                sb.Append(n.ToHTML());
            return "<tr>" + sb.ToString() + "</tr>";
        }
        
        public override string[] NodeNames {
            get {
                return new string[] { "tr" };
            }
        }
        
    }
}
