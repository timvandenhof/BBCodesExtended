using System;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// the [url] node
    /// </summary>
    public class URLNode : Node
    {
        public URLNode()
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
                return "<a href=\"" + EncodeForHtmlAttribute(Arguments[0].Item1, true, false) + "\">" + innerContent + "</a>";
            }
            else
            {
                return "<a href=\"" + EncodeForHtmlAttribute(innerContent, true, true) + "\">" + innerContent + "</a>";
            }
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"url", "link"};
            }
        }
    }
}
