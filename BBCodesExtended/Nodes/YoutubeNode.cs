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
            var innerContent = GetInnerContent(firstNodeOnly: true);
            if (string.IsNullOrWhiteSpace(innerContent))
            {
                return string.Empty;
            }

            return string.Format("<iframe width=\"420\" height=\"315\" src=\"http://youtube.com/embed/{0}\" frameborder=\"0\" allowfullscreen></iframe>", EncodeForHtmlAttribute(innerContent, true));
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"youtube"};
            }
        }
    }
}
