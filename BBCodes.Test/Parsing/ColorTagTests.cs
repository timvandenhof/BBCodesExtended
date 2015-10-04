using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodes.Parsing.Test
{
    [TestClass]
    public class ColorTagTests
    {
        [TestMethod]
        public void Can_parse_color_tags_by_name()
        {
            const string input = "The following text has a [color=red]color[/color] to it.";
            const string expected = "The following text has a <span style=\"color:red\">color</span> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_color_tags_by_hex()
        {
            const string input = "The following text has a [color=#FF0000]color[/color] to it.";
            const string expected = "The following text has a <span style=\"color:#FF0000\">color</span> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_color_tags_by_hex_without_hash()
        {
            const string input = "The following text has a [color=FF0000]color[/color] to it.";
            const string expected = "The following text has a <span style=\"color:#FF0000\">color</span> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_color_tags()
        {
            const string input = "The following text has a [color=green]color[/color] but not [color=red]like this[/color].";
            const string expected = "The following text has a <span style=\"color:green\">color</span> but not <span style=\"color:red\">like this</span>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_nested_color_tags()
        {
            const string input = "The following [color=green]text has a [color=red]different[/color] color[/color].";
            const string expected = "The following <span style=\"color:green\">text has a <span style=\"color:red\">different</span> color</span>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_color_tags_without_color()
        {
            const string input = "The following text has no [color]color[/color] to it.";
            const string expected = "The following text has no color to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_color_tags_with_invalid_hexcolor()
        {
            const string input = "The following text has no [color=#test]color[/color] to it.";
            const string expected = "The following text has no  color to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
