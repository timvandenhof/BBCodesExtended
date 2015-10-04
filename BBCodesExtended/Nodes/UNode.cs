using System;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// The [u] node
    /// </summary>
    public class UNode : Node
    {
        public UNode()
        {
        }
        
        public override string ToHTML()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Node n in this)
                sb.Append(n.ToHTML());
            return "<u>" + sb.ToString() + "</u>";
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"u"};
            }
        }
    }
}
