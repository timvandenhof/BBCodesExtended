using System;
using System.Collections.Generic;
using System.Web;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// Description of TextNode.
    /// </summary>
    public class TextNode : BBCodesExtended.Nodes.Node
    {
        public TextNode()
        {
            Text = "";
        }
        
        public TextNode(string texT)
        {
            Text = texT;
        }
        
        public string Text
        {get; set; }
        
        public override string ToHTML()
        {
            //return HttpUtility.HtmlEncode(Text);
            return EncodeForHtml(Text);
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {""};
            }
        }
        
    }
}
