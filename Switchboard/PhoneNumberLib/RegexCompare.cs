using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PhoneNumberLib
{
    // <summary>
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
            var extractedObject = Regex.Replace(obj, _numberMatchingPattern, string.Empty);
            return extractedObject.GetHashCode();
        }
    }
}
