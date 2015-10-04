using System;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// The [i] node
    /// </summary>
    public class INode : Node
    {
        public INode()
        {
        }
        
        public override string ToHTML()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Node n in this)
                sb.Append(n.ToHTML());
            return "<i>" + sb.ToString() + "</i>";
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"i"};
            }
        }
    }
}
