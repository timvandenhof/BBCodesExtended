using System;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// The [s] node
    /// </summary>
    public class SNode : Node
    {
        public SNode()
        {
        }
        
        public override string ToHTML()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Node n in this)
                sb.Append(n.ToHTML());
            return "<s>" + sb.ToString() + "</s>";
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"s"};
            }
        }
    }
}
