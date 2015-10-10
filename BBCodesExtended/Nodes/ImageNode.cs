using System;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// The [img] node
    /// </summary>
    public class ImageNode : Node
    {
        public ImageNode()
        {
        }
        
        public override string ToHTML()
        {
            var innerContent = GetInnerContent(firstNodeOnly: true);
            if (string.IsNullOrWhiteSpace(innerContent))
            {
                return string.Empty;
            }

            // Full width and height specified
            if (Arguments != null && Arguments.Count == 2)
            {
                string ret = "<img src=\"" + EncodeForHtmlAttribute(innerContent, true, true) + "\" alt=\"" + EncodeForHtmlAttribute(innerContent, true, true) + "\" ";
                foreach (Tuple<string, string> arg in Arguments)
                {
                    if (arg.Item1.ToLower().Trim() == "width")
                        ret += "width=\"" + EncodeForHtmlAttribute(arg.Item2) + "\" ";
                    else if (arg.Item1.ToLower().Trim() == "height")
                        ret += "height=\"" + EncodeForHtmlAttribute(arg.Item2) + "\" ";
                }
                return ret + "/>";
            }

            // Shorthand
            if (Arguments != null && Arguments.Count == 1)
            {
                if(!string.IsNullOrWhiteSpace(this.Arguments[0].Item1))
                {
                    string[] dimensions = this.Arguments[0].Item1.Split('x');
                    if(dimensions.Length == 2 && IsInteger(dimensions[0]) && IsInteger(dimensions[1]))
                    {
                        return "<img src=\"" + EncodeForHtmlAttribute(innerContent, true, true) + "\" alt=\"" + EncodeForHtmlAttribute(innerContent, true, true) + "\" width=\"" + EncodeForHtmlAttribute(dimensions[0]) + "\" height=\"" + EncodeForHtmlAttribute(dimensions[1]) + "\" />";
                    }
                }
            }

            // No width and height specified
            return "<img src=\"" + EncodeForHtmlAttribute(innerContent, true, true) + "\" alt=\"" + EncodeForHtmlAttribute(innerContent, true, true) + "\" />";
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"img"};
            }
        }
    }
}
