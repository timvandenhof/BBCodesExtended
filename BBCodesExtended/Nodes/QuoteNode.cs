using System;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// Description of QuoteNode.
    /// </summary>
    public class QuoteNode : Node
    {
        public QuoteNode()
        {
        }
        
        public override string ToHTML()
        {
            var innerContent = GetInnerContent();
            if (string.IsNullOrWhiteSpace(innerContent))
            {
                return string.Empty;
            }

            if (Arguments != null && Arguments.Count != 0)
            {
                return "<blockquote cite=\"" + EncodeForHtmlAttribute(Arguments[0].Item1) + "\">" + innerContent + "</blockquote>";
            }
            else
            {
                return "<blockquote>" + innerContent + "</blockquote>";
            }
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"quote"};
            }
        }
    }
}
