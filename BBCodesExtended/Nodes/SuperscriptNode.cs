using System;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// Description of SuperscriptNode.
    /// </summary>
    public class SuperscriptNode : Node
    {
        public SuperscriptNode()
        {
        }
        
        public override string ToHTML()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Node n in this)
                sb.Append(n.ToHTML());
            return "<sup>" + sb.ToString() + "</sup>";
        }
        
        public override string[] NodeNames {
            get {
                return new string[] { "sup" };
            }
        }
    }
}
