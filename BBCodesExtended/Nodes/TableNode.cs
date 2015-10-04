using System;
using System.Text;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// Description of TableNode.
    /// </summary>
    public class TableNode : Node
    {
        public TableNode()
        {
        }
        
        public override string ToHTML()
        {
            return ParseFormat("<table>{0}</table>");
        }
        
        public override string[] NodeNames {
            get {
                return new string[] { "table" };
            }
        }
    }
}
