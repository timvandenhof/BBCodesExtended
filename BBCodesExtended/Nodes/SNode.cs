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
            return ParseFormat("<s>{0}</s>");
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"s"};
            }
        }
    }
}
