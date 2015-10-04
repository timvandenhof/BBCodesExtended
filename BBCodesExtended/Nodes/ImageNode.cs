﻿using System;

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
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            // Ignore other nodes between the tags, except the first one (which is the url).
            var e = this.GetEnumerator();
            e.MoveNext();
            sb.Append(e.Current.ToHTML());

            if (this.Arguments.Count == 0)
            {
                // basic IMG only
                return "<img src=\"" + sb.ToString() + "\" alt=\"" + sb.ToString() + "\" />";
            }
            else if (this.Arguments.Count == 1)
            {
                string[] dimensions = this.Arguments[0].Item1.Split('x');
                return "<img src=\"" + sb.ToString() + "\" alt=\"" + sb.ToString() + "\" width=\"" + dimensions[0] + "\" height=\"" + dimensions[1] + "\" />";
            }
            else
            {
                string ret = "<img src=\"" + sb.ToString() + "\" alt=\"" + sb.ToString() + "\" ";
                foreach (Tuple<string, string> arg in Arguments)
                {
                    if (arg.Item1.ToLower().Trim() == "width")
                        ret += "width=\"" + arg.Item2 + "\" ";
                    else if (arg.Item1.ToLower().Trim() == "height")
                        ret += "height=\"" + arg.Item2 + "\" ";
                }
                return ret + "/>";
            }
        }
        
        public override string[] NodeNames {
            get {
                return new string[]  {"img"};
            }
        }
    }
}