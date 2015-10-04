using System;
using System.Text;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// the [size=X] node
    /// </summary>
    public class TextSizeNode : Node
    {
        public TextSizeNode()
        {
        }
        
        public override string ToHTML()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Node n in this)
                sb.Append(n.ToHTML());
            return "<span style=\"font-size:" + Arguments[0].Item1 + "px\">" + sb.ToString() + "</span>";
        }
        
        public override string[] NodeNames {
            get {
                return new string[] { "size" };
            }
        }
    }
}
