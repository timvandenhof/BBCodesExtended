using System;
using System.Text;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// The [ol] tag
    /// </summary>
    public class OrderedListNode : ListNode
    {
        public OrderedListNode()
        {
        }
        
        public override string ToHTML()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ol>");
            foreach (Node n in this) // should be [li] or [*] (ListItemNode)
                sb.Append(n.ToHTML());
            sb.Append("</ol>");
            return sb.ToString();
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"ol"};
            }
        }
    }
}
