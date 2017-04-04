using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Task1.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        [TestCase("G", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        [TestCase("NRP", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        [TestCase("NR", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00")]
        [TestCase("N", ExpectedResult = "Customer record: Jeffrey Richter")]
        [TestCase("R", ExpectedResult = "Customer record: 1,000,000.00")]
        [TestCase("P", ExpectedResult = "Customer record: +1 (425) 555-0100")]
        [TestCase(null, ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        [TestCase("", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        public string ToString_PassedStringFormatAndFormatProvider_ExpectedPositiveTest(string format)
        {
            Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            return customer.ToString(format, CultureInfo.InvariantCulture);
        }

        [TestCase("G", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        [TestCase("NRP", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        [TestCase("NR", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00")]
        [TestCase("N", ExpectedResult = "Customer record: Jeffrey Richter")]
        [TestCase("R", ExpectedResult = "Customer record: 1,000,000.00")]
        [TestCase("P", ExpectedResult = "Customer record: +1 (425) 555-0100")]
        [TestCase(null, ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        [TestCase("", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        public string ToString_PassedStringFormat_ExpectedPositiveTest(string format)
        {
            Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            return customer.ToString(format);
        }

        [TestCase("N02")]
        [TestCase("F")]
        public void ToString_PassedInvalidStringFormatAndFormatProvider_ExpectedPositiveTest(string format)
        {
            Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            Assert.Throws<FormatException>(() => customer.ToString(format, CultureInfo.InvariantCulture));
        }

        [TestCase("N02")]
        [TestCase("F")]
        public void ToString_PassedInvalidStringFormat_ExpectedPositiveTest(string format)
        {
            Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            Assert.Throws<FormatException>(() => customer.ToString(format));
        }
    }
}
