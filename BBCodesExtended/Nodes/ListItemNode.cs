using System;
using System.Text;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// Description of ListItemNode.
    /// </summary>
    public class ListItemNode : Node
    {
        public ListItemNode()
        {
        }
        
        public override string ToHTML()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Node n in this)
                sb.Append(n.ToHTML());
            return "<li>" + sb.ToString() + "</li>";
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"li", "*"};
            }
        }
    }
}
