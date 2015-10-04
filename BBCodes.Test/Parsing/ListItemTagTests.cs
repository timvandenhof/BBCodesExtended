using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodes.Parsing.Test
{
    [TestClass]
    public class ListItemTagTests
    {
        [TestMethod]
        public void Can_parse_listitem_li_tags()
        {
            const string input = "The following text has a [li]list item[/li] to it.";
            const string expected = "The following text has a <li>list item</li> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_listitem_astrix_tags()
        {
            const string input = "The following text has a [*]list item[/*] to it.";
            const string expected = "The following text has a <li>list item</li> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_listitem_li_tags()
        {
            const string input = "The following text has multiple list items: [li]list item 1[/li] [li]list item 2[/li] to it.";
            const string expected = "The following text has multiple list items: <li>list item 1</li> <li>list item 2</li> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_listitem_asterix_tags()
        {
            const string input = "The following text has multiple list items: [*]list item 1[/*] [*]list item 2[/*] to it.";
            const string expected = "The following text has multiple list items: <li>list item 1</li> <li>list item 2</li> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_nested_listitem_li_tags()
        {
            const string input = "The following text has a [li]list item with a [li]nested list item[/li][/li] to it.";
            const string expected = "The following text has a <li>list item with a <li>nested list item</li></li> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_nested_listitem_asterix_tags()
        {
            const string input = "The following text has a [*]list item with a [*]nested list item[/*][/*] to it.";
            const string expected = "The following text has a <li>list item with a <li>nested list item</li></li> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_listitem_li_tags()
        {
            const string input = "The following text has no [li][/li] list item to it.";
            const string expected = "The following text has no  list item to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_listitem_asterix_tags()
        {
            const string input = "The following text has no [*][/*] list item to it.";
            const string expected = "The following text has no  list item to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
