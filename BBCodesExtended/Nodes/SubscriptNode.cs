using System;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// Description of SubscriptNode.
    /// </summary>
    public class SubscriptNode : Node
    {
        public SubscriptNode()
        {
        }
        
        public override string ToHTML()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Node n in this)
                sb.Append(n.ToHTML());
            return "<sub>" + sb.ToString() + "</sub>";
        }
        
        public override string[] NodeNames {
            get {
                return new string[] { "sub" };
            }
        }
    }
}
