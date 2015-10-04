using System;
using System.Text;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// Description of TableHeaderNode.
    /// </summary>
    public class TableHeaderNode : Node
    {
        public TableHeaderNode()
        {
        }
        
        public override string ToHTML()
        {
            return ParseFormat("<th>{0}</th>", keepEmpty: true);
        }
        
        public override string[] NodeNames {
            get {
                return new string[] { "th" };
            }
        }
    }
}
