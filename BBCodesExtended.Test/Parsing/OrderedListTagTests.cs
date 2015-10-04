using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodesExtended.Parsing.Test
{
    [TestClass]
    public class OrderedListTagTests
    {
        [TestMethod]
        public void Can_parse_ordered_list_tags_with_li_items()
        {
            const string input = "The following text has an ordered list [ol][li]item 1[/li][li]item 2[/li][li]item 3[/li][/ol] to it.";
            const string expected = "The following text has an ordered list <ol><li>item 1</li><li>item 2</li><li>item 3</li></ol> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_ordered_list_tags_with_li_items_multiline()
        {
            const string input = @"The following text has an ordered list
[ol]
[li]item 1[/li]
[li]item 2[/li]
[li]item 3[/li]
[/ol]
to it.";
            const string expected = @"The following text has an ordered list
<ol>
<li>item 1</li>
<li>item 2</li>
<li>item 3</li>
</ol>
to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_ordered_list_tags_with_asterix_items()
        {
            const string input = "The following text has an ordered list [ol][*]item 1[/*][*]item 2[/*][*]item 3[/*][/ol] to it.";
            const string expected = "The following text has an ordered list <ol><li>item 1</li><li>item 2</li><li>item 3</li></ol> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_ordered_list_tags_with_asterix_items_multiline()
        {
            const string input = @"The following text has an ordered list
[ol]
[*]item 1[/*]
[*]item 2[/*]
[*]item 3[/*]
[/ol]
to it.";
            const string expected = @"The following text has an ordered list
<ol>
<li>item 1</li>
<li>item 2</li>
<li>item 3</li>
</ol>
to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_ordered_list_tags_with_nested_lists_in_li()
        {
            const string input = @"The following text has an ordered list
[ol]
[li]item 1[/li]
[li]item 2[/li]
[li][ol]
[li]item 2.1[/li]
[li]item 2.2[/li]
[/ol][/li]
[li]item 3[/li]
[li]item 4[/li]
[/ol]
to it.";
            const string expected = @"The following text has an ordered list
<ol>
<li>item 1</li>
<li>item 2</li>
<li><ol>
<li>item 2.1</li>
<li>item 2.2</li>
</ol></li>
<li>item 3</li>
<li>item 4</li>
</ol>
to it.";
            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// This is not following HTML specs according to http://www.w3.org/wiki/HTML_lists#Nesting_lists
        /// </summary>
        [TestMethod]
        public void Can_parse_ordered_list_tags_with_nested_lists_out_li()
        {
            const string input = @"The following text has an ordered list
[ol]
[li]item 1[/li]
[li]item 2[/li]
[ol]
[li]item 2.1[/li]
[li]item 2.2[/li]
[/ol]
[li]item 3[/li]
[li]item 4[/li]
[/ol]
to it.";
            const string expected = @"The following text has an ordered list
<ol>
<li>item 1</li>
<li>item 2</li>
<ol>
<li>item 2.1</li>
<li>item 2.2</li>
</ol>
<li>item 3</li>
<li>item 4</li>
</ol>
to it.";
            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_ordered_list_tags_with_nested_lists_in_li_with_text()
        {
            const string input = @"The following text has an ordered list
[ol]
[li]item 1[/li]
[li]item 2
[ol]
[li]item 2.1[/li]
[li]item 2.2[/li]
[/ol]
[/li]
[li]item 3[/li]
[li]item 4[/li]
[/ol]
to it.";
            const string expected = @"The following text has an ordered list
<ol>
<li>item 1</li>
<li>item 2
<ol>
<li>item 2.1</li>
<li>item 2.2</li>
</ol>
</li>
<li>item 3</li>
<li>item 4</li>
</ol>
to it.";
            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_ordered_list_tags()
        {
            const string input = "The following text has empty [ol][/ol] ordered list to it.";
            const string expected = "The following text has empty  ordered list to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
