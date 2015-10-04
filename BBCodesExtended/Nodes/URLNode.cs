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
                return "<a href=\"" + Arguments[0].Item1 + "\">" + innerContent + "</a>";
            }
            else
            {
                return "<a href=\"" + innerContent + "\">" + innerContent + "</a>";
            }
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"url", "link"};
            }
        }
    }
}
