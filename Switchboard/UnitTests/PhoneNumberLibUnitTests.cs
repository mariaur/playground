using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PhoneNumberLibTests
{
    using PhoneNumberLib;
    using PhoneNumberPairList = List<Tuple<string, string>>;

    [TestClass]
    public class PhoneNumberComparerUnitTests
    {
        // Possible comparers
        LinqCompare _linqComparer;
        RegexCompare _regexComparer;
        SerialCompare _serialComparer;

        // Deterministic values for unit tests
        static readonly PhoneNumberPairList EqualNumbers = new PhoneNumberPairList
        {
            Tuple.Create("(123) 456-7890","123.456.7890"),
            Tuple.Create("1234567890", "sfjdfhjskdfh12kdsfjs34ksdfjdkf56dkf7890"),
            Tuple.Create("123, '\"45   67*(&890", "sfjdfhjskdfh12kdsfjs34ksdfjdkf56dkf7890")
        };

        static readonly PhoneNumberPairList DifferentNumbers = new PhoneNumberPairList
        {
            Tuple.Create("1-123-456-7890","123-456-7890"),
            Tuple.Create("1234567890", @"sfjdfhjsk\2353kf7890")
        };
        [TestInitialize]
        public void Init()
        {
            _linqComparer = new LinqCompare();
            _regexComparer = new RegexCompare();
            _serialComparer = new SerialCompare();
        }

        [TestMethod]
        public void EqualNumbersTest()
        {
            foreach (var pair in EqualNumbers)
            {
                Assert.IsTrue(PhoneNumberComparer.AreEqual(pair.Item1, pair.Item2, _linqComparer));
                Assert.IsTrue(PhoneNumberComparer.AreEqual(pair.Item1, pair.Item2, _regexComparer));
                Assert.IsTrue(PhoneNumberComparer.AreEqual(pair.Item1, pair.Item2, _serialComparer));
            }
        }

        [TestMethod]
        public void DifferentNumbersTest()
        {
            foreach (var pair in DifferentNumbers)
            {
                Assert.IsFalse(PhoneNumberComparer.AreEqual(pair.Item1, pair.Item2, _serialComparer));
                Assert.IsFalse(PhoneNumberComparer.AreEqual(pair.Item1, pair.Item2, _regexComparer));
                Assert.IsFalse(PhoneNumberComparer.AreEqual(pair.Item1, pair.Item2, _linqComparer));
            }
        }

        [TestMethod]
        public void BothEmptyNumbersTest()
        {
            Assert.IsTrue(PhoneNumberComparer.AreEqual(string.Empty, string.Empty, _serialComparer));
            Assert.IsTrue(PhoneNumberComparer.AreEqual(string.Empty, string.Empty, _regexComparer));
            Assert.IsTrue(PhoneNumberComparer.AreEqual(string.Empty, string.Empty, _linqComparer));
        }

        [TestMethod]
        public void BothWhiteSpacesNumbersTest()
        {
            Assert.IsTrue(PhoneNumberComparer.AreEqual("           ", " ", _serialComparer));
            Assert.IsTrue(PhoneNumberComparer.AreEqual("  ", "                  ", _regexComparer));
            Assert.IsTrue(PhoneNumberComparer.AreEqual(" ", "  ", _linqComparer));
        }


        [TestMethod]
        public void OneEmptyNumberTest()
        {
            var phoneNumber = "SDFD df12345678{";
            Assert.IsFalse(PhoneNumberComparer.AreEqual(string.Empty, phoneNumber, _serialComparer));
            Assert.IsFalse(PhoneNumberComparer.AreEqual(phoneNumber, string.Empty, _regexComparer));
            Assert.IsFalse(PhoneNumberComparer.AreEqual(string.Empty, phoneNumber, _linqComparer));
        }

        [TestMethod]
        public void OneWhiteSpaceOnlyNumberTest()
        {
            var phoneNumber = "SDFD df12345678{";
            Assert.IsFalse(PhoneNumberComparer.AreEqual("    ", phoneNumber, _serialComparer));
            Assert.IsFalse(PhoneNumberComparer.AreEqual("     ", string.Empty, _regexComparer));
            Assert.IsFalse(PhoneNumberComparer.AreEqual(phoneNumber, "  ", _linqComparer));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidateIllegalNumbersTest()
        {
            // Exception of Argument out of Range will be thrown only in case both are at least Cosnts.Max_VALID_LENGTH
            // Otherwise we know the numbers are different (number of digits is different)
            var phoneNumber = "SDFD df1234567888888888888888888888888888888888888888{";
            var phoneNumber2 = "332434444444444444444";
            PhoneNumberComparer.AreEqual(phoneNumber, phoneNumber2, _regexComparer);
        }
    }
}