using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Security.AntiXss;

namespace BBCodesExtended.Nodes
{
    /// <summary>
    /// The BBCode base node
    /// </summary>
    [Serializable]
    public abstract class Node : IEnumerable<Node>
    {
        /// <summary>
        /// Resolves the node into HTML
        /// </summary>
        public abstract string ToHTML();
        
        public Node()
        {
            //this.InnerText = innertext;
            InnerNodes = new List<Node>();
            Arguments = new List<Tuple<string, string>>();
        }
        
        /// <summary>
        /// The internal text
        /// </summary>
        public List<Node> InnerNodes
        {
            get; set;
        }
        
        public List<Tuple<string, string>> Arguments
        { get; set; }
        
        public IEnumerator<Node> GetEnumerator()
        {
            return InnerNodes.GetEnumerator();
        }
        
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return InnerNodes.GetEnumerator();
        }
        
        public abstract string[] NodeNames
        {
            get;
        }

        internal string GetInnerContent(bool firstNodeOnly = false)
        {
            if(firstNodeOnly)
            {
                return GetContentFromFirstChildNode();
            }
            else
            {
                return GetContentFromChildNodes();
            }
        }

        private string GetContentFromChildNodes()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Node n in this)
            {
                sb.Append(n.ToHTML());
            }
            return sb.ToString();
        }

        private string GetContentFromFirstChildNode()
        {
            var e = this.GetEnumerator();
            if(e.MoveNext())
            {
                return e.Current.ToHTML();
            }
            else
            {
                return string.Empty;
            }
        }

        internal string ParseFormat(string format, bool keepEmpty = false)
        {
            var innerContent = GetInnerContent();
            if (!keepEmpty && string.IsNullOrWhiteSpace(innerContent))
            {
                return string.Empty;
            }
            else
            {
                return string.Format(format, innerContent);
            }
        }

        /// <summary>
        /// Is the specified string an integer?
        /// </summary>
        /// <param name="input">The input to verify</param>
        /// <returns>True if it is an integer, false when not or when no value specified</returns>
        internal bool IsInteger(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            int value;
            return (int.TryParse(input, out value));
        }

        /// <summary>
        /// Encode the specified string for CSS use
        /// </summary>
        /// <param name="input">The string to use</param>
        /// <returns>CSS safe string</returns>
        public string EncodeForCss(string input)
        {
            return AntiXssEncoder.CssEncode(input);
        }

        /// <summary>
        /// Encode the specified string for HTML attribute use
        /// </summary>
        /// <param name="input">The string to use</param>
        /// <param name="filterHtml">Strip out HTML tags?</param>
        /// <param name="isEncoded">Is already encoded?</param>
        /// <returns>HTML attribute safe string</returns>
        /// <remarks>isEncoded ensures that the string is decoded first before processing.</remarks>
        public string EncodeForHtmlAttribute(string input, bool filterHtml = true, bool isEncoded = false)
        {
            var cleanInput = input;

            if(isEncoded)
            {
                cleanInput = HttpUtility.HtmlDecode(cleanInput);
            }

            cleanInput = cleanInput.ReplaceCarriageReturn();

            if(filterHtml)
            {
                cleanInput = cleanInput.StripHtmlTags();
            }

            cleanInput = AntiXssEncoder.HtmlEncode(cleanInput, useNamedEntities: true);
            return cleanInput;
        }

        /// <summary>
        /// Encode the specified string for HTML use
        /// </summary>
        /// <param name="input">The string to use</param>
        /// <returns>HTML safe string</returns>
        public string EncodeForHtml(string input)
        {
            var cleanInput = input.ReplaceCarriageReturn();
            return AntiXssEncoder.HtmlEncode(cleanInput, useNamedEntities : true);
        }
    }
}
