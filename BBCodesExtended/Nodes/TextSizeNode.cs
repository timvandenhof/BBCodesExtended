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
            var innerContent = GetInnerContent();
            if (string.IsNullOrWhiteSpace(innerContent))
            {
                return string.Empty;
            }

            if (Arguments != null && Arguments.Count != 0 && IsInteger(Arguments[0].Item1))
            {
                return "<span style=\"font-size:" + Arguments[0].Item1 + "px\">" + innerContent + "</span>";
            }
            else
            {
                return innerContent;
            }
        }

        public override string[] NodeNames {
            get {
                return new string[] { "size" };
            }
        }
    }
}
