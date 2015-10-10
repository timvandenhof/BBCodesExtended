using System;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// The [color] node
    /// </summary>
    public class TextColorNode : Node
    {
        public TextColorNode()
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
                if(!string.IsNullOrWhiteSpace(Arguments[0].Item1))
                {
                    var color = Arguments[0].Item1;
                    if (color.StartsWith("#"))
                    {
                        if (IsHex(color.Substring(1)))
                        {
                            return "<span style=\"color:" + color + "\">" + innerContent + "</span>";
                        }
                        else
                        {
                            return innerContent;
                        }
                    }
                    else if(IsHex(color))
                    {
                        return "<span style=\"color:#" + color + "\">" + innerContent + "</span>";
                    }
                    else
                    {
                        // todo escape color to prevent injection
                        return "<span style=\"color:" + EncodeForCss(color) + "\">" + innerContent + "</span>";
                    }
                }
            }

            return innerContent;
        }
        
        public override string[] NodeNames {
            get {
                return new string[] { "color" };
            }
        }
        
        bool IsHex(string s)
        {
            foreach (char c in s)
            {
                if (c != 'a' &&
                    c != 'b' &&
                    c != 'c' &&
                    c != 'd' &&
                    c != 'e' &&
                    c != 'f' &&
                    c != 'A' &&
                    c != 'B' &&
                    c != 'C' &&
                    c != 'D' &&
                    c != 'E' &&
                    c != 'F' &&
                    c != '1' &&
                    c != '2' &&
                    c != '3' &&
                    c != '4' &&
                    c != '5' &&
                    c != '6' &&
                    c != '7' &&
                    c != '8' &&
                    c != '9' &&
                    c != '0' )
                    return false;
            }
            return true;
        }
    }
}
