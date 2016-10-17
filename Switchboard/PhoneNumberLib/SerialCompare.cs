using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneNumberLib
{
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

            for (int i = 0, j = 0; i < xLen && j < yLen; i++, j++)
            {
                if (i > Consts.MAX_VALID_LENGTH || j > Consts.MAX_VALID_LENGTH)
                    throw new ArgumentOutOfRangeException($"Phone number length doesn't match the valid length: '{Consts.MAX_VALID_LENGTH}', numbers are: '{y}', '{y}'");

                while (i < xLen && !Char.IsDigit(x[i])) { i++; }
                while (j < yLen && !Char.IsDigit(y[j])) { j++; }

                // One of the strings got to an end while the other still had digit - not equal
                if ((i == xLen && j < yLen) || (i < xLen && j == yLen))
                    return false;

                // Digits doesn't match, make sure we did not reach the end of the number
                if ((i < xLen && j < yLen) && x[i] != y[j])
                    return false;
            }
            
            // Phone numbers have valid length with matching digits
            return true;
        }

        public int GetHashCode(string obj)
        {
            var extractedObject = new string(obj.Where(Char.IsDigit).ToArray());
            return extractedObject.GetHashCode();
        }
    }
}
