using System;
using System.Text;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// Description of TableDataNode.
    /// </summary>
    public class TableDataNode : Node
    {
        public TableDataNode()
        {
        }
        
        public override string ToHTML()
        {
            return ParseFormat("<td>{0}</td>", keepEmpty: true);
        }
        
        public override string[] NodeNames {
            get {
                return new string[] { "td" };
            }
        }
    }
}
