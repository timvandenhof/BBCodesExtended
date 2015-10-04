using System;
using System.Text;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// Description of TableRowNode.
    /// </summary>
    public class TableRowNode : Node
    {
        public TableRowNode()
        {
        }
        
        
        public override string ToHTML()
        {
            return ParseFormat("<tr>{0}</tr>", keepEmpty: true);
        }
        
        public override string[] NodeNames {
            get {
                return new string[] { "tr" };
            }
        }
        
    }
}
