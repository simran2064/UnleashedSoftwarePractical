using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnleashedSoftwarePractical;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnleashedSoftwarePractical.Tests
{
    [TestClass()]
    public class NumberConverterTests
    {
        [TestMethod()]
        public void ConvertToWordsTest()
        {
            var number = "150.50";
            var expected = "One Hundred Fifty Dollars and Fifty Cents";

            var actual = NumberConverter.ConvertToWords(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void convertWholeNumberTest()
        {
            var number = "150";
            var expected = "One Hundred Fifty";

            var actual = NumberConverter.convertWholeNumber(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void tensTest()
        {
            var number = "50";
            var expected = "Fifty";

            var actual = NumberConverter.tens(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void onesTest()
        {
            var number = "1";
            var expected = "One";

            var actual = NumberConverter.ones(number);

            Assert.AreEqual(expected, actual);
        }

        //user input error needs Int32.Parse(String s)
        [TestMethod()]
        public void ConvertToDecimalTest()
        {
            string number = ".52";
            var expected = " Dollars and Fifty Two Cents";
            var actual = NumberConverter.ConvertToDecimal(number);

            Assert.AreEqual(expected, actual);
        }
    }
}