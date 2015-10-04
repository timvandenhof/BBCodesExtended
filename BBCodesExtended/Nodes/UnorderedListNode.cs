using System;
using System.Text;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// The [ul] tag
    /// </summary>
    public class UnorderedListNode : ListNode
    {
        public UnorderedListNode()
        {
        }
        
        public override string ToHTML()
        {
            return ParseFormat("<ul>{0}</ul>");
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"ul", "list"};
            }
        }
    }
}
