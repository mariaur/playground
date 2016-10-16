using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PhoneNumberLib
{
    /// <summary>
    /// Class that encapsulates number comparing logic
    /// </summary>
    public static class PhoneNumberComparer
    {
        /// <summary>
        /// Compare two phone numbers by using various implementations, e.g. using IEqualityComparer<string>
        /// </summary>
        /// <param name="phoneA"> Phone number A </param>
        /// <param name="phoneB"> Phone number B </param>
        /// <param name="method"> Comparing method </param>
        /// <returns> true if the numbers are equals, false otherwise </returns>
        public static bool AreEqual(string phoneA, string phoneB, IEqualityComparer<string> comparer)
        {
            // Cover the case: Numbers are exactly the same 
            if (ReferenceEquals(phoneA, phoneB))
                return true;

            // Case: One of the numbers is null, while the other is not - they are not equal
            if ((phoneA == null) || (phoneB == null))
                return false;

            // Case: Both numbers are not null & they aren't explicitly equal
            return comparer.Equals(phoneA, phoneB);
        }

        /// <summary>
        /// Validate that the extracted phone number is legal, currently validates only length
        /// Throws 'ArgumentOutOfRangeException' on illigal length
        /// </summary>
        /// <param name="phoneNumber"> Phone number to validate </param>
        internal static void ValidateNumber(string phoneNumber)
        {
            if (phoneNumber.Length > Consts.MAX_VALID_LENGTH)
                throw new ArgumentOutOfRangeException($"Phone number should not exceed '{Consts.MAX_VALID_LENGTH}' digits! Current value:'{phoneNumber}'");
        }
    }

    /// <summary>
    /// Compare phone numbers using Regex
    /// Will throw in case phone number isn't valid, see ValidateNumber function
    /// </summary>
    public class RegexCompare : IEqualityComparer<string>
    {
        const string _numberMatchingPattern = "[^0-9]";

        public bool Equals(string x, string y)
        {
            var extractedA = Regex.Replace(x, _numberMatchingPattern, string.Empty);
            PhoneNumberComparer.ValidateNumber(extractedA);

            var extractedB = Regex.Replace(y, _numberMatchingPattern, string.Empty);
            PhoneNumberComparer.ValidateNumber(extractedB);

            return extractedA == extractedB;
        }

        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }

    /// <summary>
    /// Compare phone numbers using Linq
    /// Will throw in case phone number isn't valid, see ValidateNumber function
    /// </summary>
    public class LinqCompare : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            var extractedA = new String(x.Where(Char.IsDigit).ToArray());
            PhoneNumberComparer.ValidateNumber(extractedA);

            var extractedB = new String(y.Where(Char.IsDigit).ToArray());
            PhoneNumberComparer.ValidateNumber(extractedB);

            return extractedA == extractedB;
        }

        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }

    /// <summary>
    /// Compare phone numbers by scanning both strings in a serial manner
    /// Will throw in case phone number length isn't valid
    /// </summary>
    public class SerialCompare : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            int xLen = x.Length;
            int yLen = y.Length;

            for (int i = 0, j = 0, validatePhoneLength = 0; i < xLen && j < yLen; i++, j++, validatePhoneLength++)
            {
                if (validatePhoneLength > Consts.MAX_VALID_LENGTH)
                    throw new ArgumentOutOfRangeException($"Phone number length doesn't match the valid length: '{Consts.MAX_VALID_LENGTH}', numbers are: '{y}', '{y}'");

                while (!Char.IsDigit(x[i]) && i < xLen) { i++; }
                while (!Char.IsDigit(y[j]) && j < yLen) { j++; }

                // Both numbers don't include digits - equal empty numbers
                if ((i == xLen) && (j == yLen))
                    return true;

                // Digits doesn't match
                if (x[i] != y[j])
                    return false;
            }

            // Phone numbers have valid length with matching digits
            return true;
        }

        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
}
