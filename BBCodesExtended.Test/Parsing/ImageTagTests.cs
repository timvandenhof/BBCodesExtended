using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodesExtended.Parsing.Test
{
    [TestClass]
    public class ImageTagTests
    {
        [TestMethod]
        public void Can_parse_image_tags()
        {
            const string input = "The following text contains an image: [img]https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png[/img].";
            const string expected = "The following text contains an image: <img src=\"https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png\" alt=\"https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png\" />.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_image_tags_with_width_and_height_combined()
        {
            const string input = "The following text contains an image: [img=272x92]https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png[/img].";
            const string expected = "The following text contains an image: <img src=\"https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png\" alt=\"https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png\" width=\"272\" height=\"92\" />.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_image_tags_with_width_and_height_seperate()
        {
            const string input = "The following text contains an image: [img width=272 height=92]https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png[/img].";
            const string expected = "The following text contains an image: <img src=\"https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png\" alt=\"https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png\" width=\"272\" height=\"92\" />.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_image_tags()
        {
            const string input = "The following text contains an image: [img]https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png[/img] and another one: [img]https://fake.url/logo.png[/img].";
            const string expected = "The following text contains an image: <img src=\"https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png\" alt=\"https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png\" /> and another one: <img src=\"https://fake.url/logo.png\" alt=\"https://fake.url/logo.png\" />.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Nested image tags, should only take the url and skip other child nodes to prevent HTML corruption 
        /// due to child tags being rendered inside the url and alt.
        /// </summary>
        [TestMethod]
        public void Does_skip_nested_image_tags()
        {
            const string input = "The following text contains an image: [img]https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png[img]https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png[/img][/img].";
            const string expected = "The following text contains an image: <img src=\"https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png\" alt=\"https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png\" />.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_image_tags()
        {
            const string input = "The following text contains an empty image: [img][/img].";
            const string expected = "The following text contains an empty image: .";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
