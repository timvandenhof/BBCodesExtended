using System;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// the [center] node
    /// </summary>
    public class CenterNode : Node
    {
        public CenterNode()
        {
        }
        
        public override string ToHTML()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Node n in this)
                sb.Append(n.ToHTML());
            return "<center>" + sb.ToString() + "</center>";
        }
        
        public override string[] NodeNames {
            get {
                return new string[] { "center" };
            }
        }
    }
}
