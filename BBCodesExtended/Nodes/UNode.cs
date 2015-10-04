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
            return ParseFormat("<u>{0}</u>");
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"u"};
            }
        }
    }
}
