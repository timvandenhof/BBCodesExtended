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
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Node n in this)
                sb.Append(n.ToHTML());
            if (Arguments.Count != 0)
            {
                return "<a href=\"" + Arguments[0].Item1 + "\">" + sb.ToString() + "</a>";
            }
            else
                return "<a href=\"" + sb.ToString() + "\">" + sb.ToString() + "</a>";
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"url", "link"};
            }
        }
    }
}
