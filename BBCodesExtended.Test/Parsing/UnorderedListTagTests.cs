using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodesExtended.Parsing.Test
{
    [TestClass]
    public class UnorderedListTagTests
    {
        [TestMethod]
        public void Can_parse_unordered_list_tags_with_li_items()
        {
            const string input = "The following text has an unordered list [ul][li]item 1[/li][li]item 2[/li][li]item 3[/li][/ul] to it.";
            const string expected = "The following text has an unordered list <ul><li>item 1</li><li>item 2</li><li>item 3</li></ul> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_unordered_list_tags_with_li_items_multiline()
        {
            const string input = @"The following text has an unordered list
[ul]
[li]item 1[/li]
[li]item 2[/li]
[li]item 3[/li]
[/ul]
to it.";
            const string expected = @"The following text has an unordered list
<ul>
<li>item 1</li>
<li>item 2</li>
<li>item 3</li>
</ul>
to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_unordered_list_tags_with_asterix_items()
        {
            const string input = "The following text has an unordered list [ul][*]item 1[/*][*]item 2[/*][*]item 3[/*][/ul] to it.";
            const string expected = "The following text has an unordered list <ul><li>item 1</li><li>item 2</li><li>item 3</li></ul> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_unordered_list_tags_with_asterix_items_multiline()
        {
            const string input = @"The following text has an unordered list
[ul]
[*]item 1[/*]
[*]item 2[/*]
[*]item 3[/*]
[/ul]
to it.";
            const string expected = @"The following text has an unordered list
<ul>
<li>item 1</li>
<li>item 2</li>
<li>item 3</li>
</ul>
to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_unordered_list_tags_with_nested_lists_in_li()
        {
            const string input = @"The following text has an unordered list
[ul]
[li]item 1[/li]
[li]item 2[/li]
[li][ul]
[li]item 2.1[/li]
[li]item 2.2[/li]
[/ul][/li]
[li]item 3[/li]
[li]item 4[/li]
[/ul]
to it.";
            const string expected = @"The following text has an unordered list
<ul>
<li>item 1</li>
<li>item 2</li>
<li><ul>
<li>item 2.1</li>
<li>item 2.2</li>
</ul></li>
<li>item 3</li>
<li>item 4</li>
</ul>
to it.";
            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// This is not following HTML specs according to http://www.w3.org/wiki/HTML_lists#Nesting_lists
        /// </summary>
        [TestMethod]
        public void Can_parse_unordered_list_tags_with_nested_lists_out_li()
        {
            const string input = @"The following text has an unordered list
[ul]
[li]item 1[/li]
[li]item 2[/li]
[ul]
[li]item 2.1[/li]
[li]item 2.2[/li]
[/ul]
[li]item 3[/li]
[li]item 4[/li]
[/ul]
to it.";
            const string expected = @"The following text has an unordered list
<ul>
<li>item 1</li>
<li>item 2</li>
<ul>
<li>item 2.1</li>
<li>item 2.2</li>
</ul>
<li>item 3</li>
<li>item 4</li>
</ul>
to it.";
            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_unordered_list_tags_with_nested_lists_in_li_with_text()
        {
            const string input = @"The following text has an unordered list
[ul]
[li]item 1[/li]
[li]item 2
[ul]
[li]item 2.1[/li]
[li]item 2.2[/li]
[/ul]
[/li]
[li]item 3[/li]
[li]item 4[/li]
[/ul]
to it.";
            const string expected = @"The following text has an unordered list
<ul>
<li>item 1</li>
<li>item 2
<ul>
<li>item 2.1</li>
<li>item 2.2</li>
</ul>
</li>
<li>item 3</li>
<li>item 4</li>
</ul>
to it.";
            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_unordered_list_ul_tags()
        {
            const string input = "The following text has empty [ul][/ul] unordered list to it.";
            const string expected = "The following text has empty  unordered list to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_unordered_list_list_tags()
        {
            const string input = "The following text has empty [list][/list] unordered list to it.";
            const string expected = "The following text has empty  unordered list to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
