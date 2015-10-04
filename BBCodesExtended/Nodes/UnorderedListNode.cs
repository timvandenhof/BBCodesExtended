using System;
using System.Text;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// The [ul] tag
    /// </summary>
    public class UnorderedListNode : ListNode
    {
        public UnorderedListNode()
        {
        }
        
        public override string ToHTML()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>");
            foreach (Node n in this) // should be [li] or [*] (ListItemNode)
                sb.Append(n.ToHTML());
            sb.Append("</ul>");
            return sb.ToString();
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"ul", "list"};
            }
        }
    }
}
