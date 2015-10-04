using System;
using System.Collections.Generic;

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
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //foreach (Node n in this)
            //    sb.Append(n.ToHTML());
            //return sb.ToString();
            return Text;//.Replace(" ", "&nbsp");
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {""};
            }
        }
        
    }
}
