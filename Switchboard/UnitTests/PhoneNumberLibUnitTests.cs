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

        [TestMethod]
        public void LinqEqualNumbersTest()
        {
            var linqComparer = new LinqCompare();
            foreach (var pair in EqualNumbers)
            {
                Assert.IsTrue(PhoneNumberComparer.AreEqual(pair.Item1, pair.Item2, linqComparer));
            }
        }

        [TestMethod]
        public void RegexEqualNumbersTest()
        {
            var regexComparer = new RegexCompare();
            foreach (var pair in EqualNumbers)
            {
                Assert.IsTrue(PhoneNumberComparer.AreEqual(pair.Item1, pair.Item2, regexComparer));
            }
        }

        [TestMethod]
        public void SerialEqualNumbersTest()
        {
            var serialComparer = new SerialCompare();
            foreach (var pair in EqualNumbers)
            {
                Assert.IsTrue(PhoneNumberComparer.AreEqual(pair.Item1, pair.Item2, serialComparer));
            }
        }

        [TestMethod]
        public void SerialDifferentNumbersTest()
        {
            var serialComparer = new SerialCompare();
            foreach (var pair in DifferentNumbers)
            {
                Assert.IsFalse(PhoneNumberComparer.AreEqual(pair.Item1, pair.Item2, serialComparer));
            }
        }

        [TestMethod]
        public void RegexDifferentNumbersTest()
        {
            var regexComparer = new RegexCompare();
            foreach (var pair in DifferentNumbers)
            {
                Assert.IsFalse(PhoneNumberComparer.AreEqual(pair.Item1, pair.Item2, regexComparer));
            }
        }

        [TestMethod]
        public void LinqDifferentNumbersTest()
        {
            var linqComparer = new LinqCompare();
            foreach (var pair in DifferentNumbers)
            {
                Assert.IsFalse(PhoneNumberComparer.AreEqual(pair.Item1, pair.Item2, linqComparer));
            }
        }
    }
}