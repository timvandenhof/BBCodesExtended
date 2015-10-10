using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodesExtended.Parsing.Test
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
            const string expected = "The following text has no color to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_escape_color_tags_color_to_prevent_css_injection()
        {
            const string input    = "The following text has a [color=red;font-size:10px]color[/color] to it.";
            const string expected = "The following text has a <span style=\"color:red\\00003Bfont\\00002Dsize\\00003A10px\">color</span> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual, true, System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Framework does not allow this kind of construction, throws parse exception in stead of escaping all the rubbish.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exceptions.BBCodeParseException))]
        public void Does_escape_color_tags_color_to_prevent_html_injection()
        {
            const string input = "The following text has a [color=red\"><h1>Custom</h1><span style=\"]color[/color] to it.";
            const string expectedMessage = "No node found for type 'color=red\"><h1>Custom</h1><span'!";

            try
            {
                var actual = BBCode.Parse(input);
            }
            catch(Exceptions.BBCodeParseException parseEx)
            {
                
                Assert.AreEqual(expectedMessage, parseEx.Message);
                throw;
            }
        }

        [TestMethod]
        public void Does_escape_color_tags_color_to_prevent_javascript_injection_attempt_1()
        {
            const string input = "The following text has a [color=red\"onclick=\"alert('danger');]color[/color] to it.";
            const string expected = "The following text has a <span style=\"color:red\\000022onclick\\000022alert\\000028\\000027danger\\000027\\000029\\00003B\">color</span> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Framework does not allow this kind of construction, throws parse exception in stead of escaping all the rubbish.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exceptions.BBCodeParseException))]
        public void Does_escape_color_tags_color_to_prevent_javascript_injection_attempt_2()
        {
            const string input = "The following text has a [color=red\" onclick=\"alert('danger');]color[/color] to it.";
            const string expectedMessage = "No node found for type 'color=red\"'!";

            try
            {
                var actual = BBCode.Parse(input);
            }
            catch (Exceptions.BBCodeParseException parseEx)
            {

                Assert.AreEqual(expectedMessage, parseEx.Message);
                throw;
            }
        }
    }
}
