using System;
using System.Linq;

namespace Airways.Helper
{
    public class StringUtilsHelper
    {
        public static string getNumber()
        {
            var random = new Random();

            char[] letters = Enumerable.Range('A', 26).Select(i => (char)i).ToArray();

            var letter = letters[random.Next(letters.Length)];
            var number = random.Next(1000, 9999);
            var result = letter + Convert.ToString(number);

            return result;
        }
    }
}
