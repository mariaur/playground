using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SwitchboardTests
{
    using PhoneNumberLib;
    using PhoneNumberPairList = List<Tuple<string, string>>;

    [TestClass]
    public class PhoneNumberComparerPerformaceTests
    {
        // Used for perf test
        const int _maxSizeOfGeneratedPhoneNumbers = 10000;

        // Input generation methods 
        /// <summary>
        /// Generate random equl phone number pairs
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private PhoneNumberPairList GenerateMatchingPhoneNumbers(int count)
        {
            Random random = new Random();

            PhoneNumberPairList list = new PhoneNumberPairList();
            for (int i = 0; i < count; i++)
            {
                var number = GenerateNumber();
                var paddedNumber = PadPhoneNumber(number, PhoneNumberLib.Consts.MAX_VALID_LENGTH, _maxSizeOfGeneratedPhoneNumbers);
                var paddedNumber2 = PadPhoneNumber(number, PhoneNumberLib.Consts.MAX_VALID_LENGTH, _maxSizeOfGeneratedPhoneNumbers);
                list.Add(Tuple.Create(paddedNumber, paddedNumber2));
            }

            return list;
        }

        /// <summary>
        /// Get phone number and pad it with random chars
        /// </summary>
        /// <param name="number"> Phone number </param>
        /// <param name="minLen"> Min length of the padded number </param>
        /// <param name="maxLen"> Max length of the padded number </param>
        /// <returns></returns>
        private string PadPhoneNumber(string number, int minLen, int maxLen)
        {
            var random = new Random();

            // Generate PhoneNumberLib.Consts.MAX_VALID_LENGTH unique position to distribute the number
            var uniqueDigitPositions = new List<int>();
            while (uniqueDigitPositions.Count < PhoneNumberLib.Consts.MAX_VALID_LENGTH)
            {
                var pos = random.Next(minLen, maxLen);
                if (!uniqueDigitPositions.Contains(pos))
                { uniqueDigitPositions.Add(pos); }
            }

            // Create the padded number
            var length = random.Next(minLen, maxLen);
            StringBuilder paddedNumber = new StringBuilder(length);

            // Position the phone number
            for (int i = 0; i < PhoneNumberLib.Consts.MAX_VALID_LENGTH; i++)
            {
                paddedNumber.Insert(uniqueDigitPositions[i], number[i]);
            }

            // Position random chars in the rest of the string
            const string chars = "(){}[]$%#@!*abcdefghijklmnopqrstuvwxyz?;: ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
            for (int i = 0; i < length; i++)
            {
                if (!Char.IsDigit(paddedNumber[i]))
                {
                    var randomCharPos = random.Next(chars.Length);
                    paddedNumber[i] = chars[randomCharPos];
                }
            }

            return paddedNumber.ToString();
        }

        /// <summary>
        /// Generate random Phone number 
        /// </summary>
        /// <returns> Phone number </returns>
        private string GenerateNumber()
        {
            var random = new Random();

            var randomDigits = new int[9]
            {
                random.Next(0,9),
                random.Next(0,9),
                random.Next(0,9),
                random.Next(0,9),
                random.Next(0,9),
                random.Next(0,9),
                random.Next(0,9),
                random.Next(0,9),
                random.Next(0,9)
            };

            return randomDigits.ToString();
        }

    }
}