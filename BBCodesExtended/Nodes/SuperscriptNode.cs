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
            return ParseFormat("<sup>{0}</sup>");
        }
        
        public override string[] NodeNames {
            get {
                return new string[] { "sup" };
            }
        }
    }
}
