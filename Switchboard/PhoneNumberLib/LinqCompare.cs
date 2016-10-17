using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneNumberLib
{
    /// <summary>
    /// Compare phone numbers using Linq
    /// Will throw in case phone number isn't valid, see ValidateNumber function
    /// </summary>
    public class LinqCompare : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            var extractedA = new string(x.Where(Char.IsDigit).ToArray());
            PhoneNumberComparer.ValidateNumber(extractedA);

            var extractedB = new string(y.Where(Char.IsDigit).ToArray());
            PhoneNumberComparer.ValidateNumber(extractedB);

            return extractedA == extractedB;
        }

        public int GetHashCode(string obj)
        {
            var extractedObject = new string(obj.Where(Char.IsDigit).ToArray());
            return extractedObject.GetHashCode();
        }
    }
}
