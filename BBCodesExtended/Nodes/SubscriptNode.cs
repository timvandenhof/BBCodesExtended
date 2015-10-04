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
            return ParseFormat("<sub>{0}</sub>");
        }
        
        public override string[] NodeNames {
            get {
                return new string[] { "sub" };
            }
        }
    }
}
