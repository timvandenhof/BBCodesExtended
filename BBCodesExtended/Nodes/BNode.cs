using System;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// The [b] [/b] node
    /// </summary>
    public class BNode : Node
    {
        public BNode()
        {
            
        }
        
        public override string ToHTML()
        {
            return ParseFormat("<b>{0}</b>");
        }
        
        public override string[] NodeNames {
            get {
                return new string[] {"b"};
            }
        }
    }
}
