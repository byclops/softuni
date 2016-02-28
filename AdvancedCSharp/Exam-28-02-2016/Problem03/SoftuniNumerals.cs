using System;
using System.Collections.Generic;
using System.Numerics;

namespace Problem03
{
    class SoftuniNumerals
    {
        static void Main(string[] args)
        {
            string numeral = Console.ReadLine();

            int index = 0;
            var digits = new Stack<int>();
            while (index<numeral.Length)
            {
                string digit = GetNextDigit(numeral, index);
                digits.Push(ConvertToDigit(digit));
                index += digit.Length;
            }

            BigInteger result = 0;
            BigInteger multiplier = 1;
            while (digits.Count > 0)
            {
                result += digits.Pop()*multiplier;
                multiplier *= 5;
            }

            Console.WriteLine(result);
        }

        public static int ConvertToDigit(string code)
        {
            switch (code)
            {
                case "aa":
                    return 0;
                case "aba":
                    return 1;
                case "bcc":
                    return 2;
                case "cc":
                    return 3;
                default:
                    return 4;
            }    
        }

        public static string GetNextDigit(string numeral, int index)
        {
            string digit = numeral.Substring(index, 2);
            switch (digit)
            {
                case "aa":
                    return "aa";
                case "cc":
                    return "cc";
            }

            digit = numeral.Substring(index, 3);
            switch (digit)
            {
                case "aba":
                    return "aba";
                case "bcc":
                    return "bcc";
                case "cdc":
                    return "cdc";
            }

            return "";
        }
    }
}
