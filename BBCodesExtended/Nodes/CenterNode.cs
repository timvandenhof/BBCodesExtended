using System;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// the [center] node
    /// </summary>
    public class CenterNode : Node
    {
        public CenterNode()
        {
        }
        
        public override string ToHTML()
        {
            return ParseFormat("<center>{0}</center>");
        }
        
        public override string[] NodeNames {
            get {
                return new string[] { "center" };
            }
        }
    }
}
