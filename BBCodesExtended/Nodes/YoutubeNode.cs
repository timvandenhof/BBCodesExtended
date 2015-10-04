using System;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// Description of YoutubeNode.
    /// </summary>
    public class YoutubeNode : Node
    {
        public YoutubeNode()
        {
        }
        
        public override string ToHTML()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Node n in this) // Todo: First only
                sb.Append(n.ToHTML());

            return "<iframe width=\"420\" height=\"315\" src=\"http://youtube.com/embed/" + sb.ToString() + "\" frameborder=\"0\" allowfullscreen></iframe>";
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"youtube"};
            }
        }
    }
}
