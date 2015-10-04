using System;
using System.Text;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// Description of CodeNode.
    /// </summary>
    public class CodeNode : Node
    {
        public CodeNode()
        {
        }
        
        public override string ToHTML()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Node n in this)
                sb.Append(n.ToHTML());
            return "<code>" + sb.ToString() + "</code>";
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"code"};
            }
        }
    }
}
