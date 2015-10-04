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
            return ParseFormat("<code>{0}</code>");
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"code"};
            }
        }
    }
}
