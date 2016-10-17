using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PhoneNumberLib
{
    /// <summary>
    /// Number comparison logic
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

            // Case: One of the numbers is null or empty, while the other is not - they are not equal
            if ((phoneA == null) || (phoneB == null))
                return false;
            if ((phoneA == string.Empty) || (phoneB == string.Empty))
                return false;

            // Case: Both numbers are not null & they aren't explicitly equal
            return comparer.Equals(phoneA, phoneB);
        }

        /// <summary>
        /// Validate that extracted phone number, currently validates only length
        /// Throws 'ArgumentOutOfRangeException' on illegal length
        /// </summary>
        /// <param name="phoneNumber"> Phone number to validate </param>
        internal static void ValidateNumber(string phoneNumber)
        {
            if (phoneNumber.Length > Consts.MAX_VALID_LENGTH)
                throw new ArgumentOutOfRangeException($"Phone number should not exceed '{Consts.MAX_VALID_LENGTH}' digits! Current value:'{phoneNumber}'");
        }
    }
}
