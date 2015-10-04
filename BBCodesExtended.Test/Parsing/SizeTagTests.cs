using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodesExtended.Parsing.Test
{
    [TestClass]
    public class SizeTagTests
    {
        [TestMethod]
        public void Can_parse_size_tags()
        {
            const string input = "The following text has a [size=10]different size[/size] to it.";
            const string expected = "The following text has a <span style=\"font-size:10px\">different size</span> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_size_tags()
        {
            const string input = "The following text has a [size=10]different size[/size] but not [size=24]like this[/size].";
            const string expected = "The following text has a <span style=\"font-size:10px\">different size</span> but not <span style=\"font-size:24px\">like this</span>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_nested_size_tags()
        {
            const string input = "The following [size=10]text has a [size=24]different[/size] size[/size].";
            const string expected = "The following <span style=\"font-size:10px\">text has a <span style=\"font-size:24px\">different</span> size</span>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_size_tags()
        {
            const string input = "The following text has no [size=10][/size] size to it.";
            const string expected = "The following text has no  size to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_size_tags_without_size()
        {
            const string input = "The following text has a [size]normal size[/size] to it.";
            const string expected = "The following text has a normal size to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_size_tags_with_invalid_size()
        {
            const string input = "The following text has a [size=test]normal size[/size] to it.";
            const string expected = "The following text has a normal size to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
