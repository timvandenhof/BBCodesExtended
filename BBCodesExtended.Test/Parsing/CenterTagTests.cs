using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodesExtended.Parsing.Test
{
    [TestClass]
    public class CenterTagTests
    {
        [TestMethod]
        public void Can_parse_center_tags()
        {
            const string input = "The following text [center]has been centered[/center] all the way to the middle.";
            const string expected = "The following text <center>has been centered</center> all the way to the middle.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_center_tags()
        {
            const string input = "The following text [center]has been centered[/center] all the way [center]to the middle[/center].";
            const string expected = "The following text <center>has been centered</center> all the way <center>to the middle</center>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_nested_center_tags()
        {
            const string input = "The following text [center]has been [center]perfect centered[/center][/center] all the way to the middle.";
            const string expected = "The following text <center>has been <center>perfect centered</center></center> all the way to the middle.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_center_tags()
        {
            const string input = "The following text has no [center][/center] center to it.";
            const string expected = "The following text has no  center to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
