using System;
using System.Text;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// The [ol] tag
    /// </summary>
    public class OrderedListNode : ListNode
    {
        public OrderedListNode()
        {
        }
        
        public override string ToHTML()
        {
            return ParseFormat("<ol>{0}</ol>");
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"ol"};
            }
        }
    }
}
