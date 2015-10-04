using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodesExtended.Parsing.Test
{
    [TestClass]
    public class CodeTagTests
    {
        [TestMethod]
        public void Can_parse_code_tags()
        {
            const string input = "The following text contains some [code]very specific code[/code].";
            const string expected = "The following text contains some <code>very specific code</code>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_code_tags()
        {
            const string input = "The following text contains some [code]very specific code[/code]. Also check this [code]piece of sample code[/code].";
            const string expected = "The following text contains some <code>very specific code</code>. Also check this <code>piece of sample code</code>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_nested_code_tags()
        {
            const string input = "The following text contains some [code]very [code]specific[/code] code[/code].";
            const string expected = "The following text contains some <code>very <code>specific</code> code</code>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_code_tags()
        {
            const string input = "The following text has no [code][/code] code to it.";
            const string expected = "The following text has no  code to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
