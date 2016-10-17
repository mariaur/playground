# Switchboard

Switchboard project supports phone number comparison
  - Compare using Linq
  - Compare using Regex
  - Compare using serial method that is scanning the numbers char by char
  - User custom compare method 

Input format:
Any string that consist of less than PhoneNumberLib.Consts.MAX_VALID_LENGTH
Example:
  - "1-123-456-7890", "1123456789"
  - "(123) 456-7890", "123.456.7890" 

The library ignores any character that isn't a digit.
Therefore, strings of the form: "sdkasjdsa  123456789", "(123)456789" will be equal.

Main function:
```sh
public static bool AreEqual(string phoneA, string phoneB, IEqualityComparer<string> comparer)
```
