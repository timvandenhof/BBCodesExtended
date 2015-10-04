using System;
using System.Text;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// Description of ListItemNode.
    /// </summary>
    public class ListItemNode : Node
    {
        public ListItemNode()
        {
        }
        
        public override string ToHTML()
        {
            return ParseFormat("<li>{0}</li>");
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"li", "*"};
            }
        }
    }
}
