using System;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// Description of EmailNode.
    /// </summary>
    public class EmailNode : Node
    {
        public EmailNode()
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
                return "<a href=\"mailto:" + Arguments[0].Item1 + "\">" + innerContent + "</a>";
            }
            else
            {
                return "<a href=\"mailto:" + innerContent + "\">" + innerContent + "</a>";
            }
        }
        
        public override string[] NodeNames {
            get {
                return new string[] { "email" };
            }
        }
    }
}
