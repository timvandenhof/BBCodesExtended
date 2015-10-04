using System;
using System.Collections.Generic;
using System.Text;

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

        internal bool IsInteger(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            int value;
            return (int.TryParse(input, out value));
        }
    }
}
