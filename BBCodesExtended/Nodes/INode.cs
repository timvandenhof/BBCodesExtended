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
            return ParseFormat("<i>{0}</i>");
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"i"};
            }
        }
    }
}
