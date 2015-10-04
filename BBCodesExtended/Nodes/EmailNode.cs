using System;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// Description of EmailNode.
    /// </summary>
    public class EmailNode : Node
    {
        public EmailNode()
        {
        }
        
        public override string ToHTML()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Node n in this)
                sb.Append(n.ToHTML());
            return "<a href=\"mailto:" + Arguments[0].Item1 + "\">" + sb.ToString() + "</a>";
        }
        
        public override string[] NodeNames {
            get {
                return new string[] { "email" };
            }
        }
    }
}
