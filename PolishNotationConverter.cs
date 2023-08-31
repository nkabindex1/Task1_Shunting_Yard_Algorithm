using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1_Shunting_Yard_Algorithm
{
    class PolishNotationConverter : IExpressionConverter
    {
        private static string AllowedOperators { get; } = "+-x/^%*";
        private static string AllowedCharacters { get; } = "1234567890" + AllowedOperators;

        private bool IsOperator(char c)
        {
            return AllowedOperators.IndexOf(c) != -1;
        }

        private bool IsStringMadeUpOfCharacters(string input, string allowedCharacters)
        {
            string pattern = "^[ " + Regex.Escape(allowedCharacters) + "]*$";
            return Regex.IsMatch(input, pattern);
        }

        private void AssertInvalidInput(string input)
        {
            if (!IsStringMadeUpOfCharacters(input, AllowedCharacters))
            {
                throw new InvalidOperationException("Assertion failed: Invalid characters in the input. Allowed characters: " + AllowedCharacters);
            }
        }


        public string ConvertToInfix(string strPolishNotation)
        {
            strPolishNotation = strPolishNotation.Replace(" ", "");
            AssertInvalidInput(strPolishNotation);

            var stInfix = new Stack<string>();

            foreach (char token in strPolishNotation)
            {
                if (Char.IsDigit(token))
                {
                    stInfix.Push(token.ToString());
                }
                else if (IsOperator(token))
                {
                    string operand2 = stInfix.Pop();
                    string operand1 = stInfix.Pop();
                    string infix = "(" + operand1 + " " + token + " " + operand2 + ")";
                    stInfix.Push(infix);
                }
            }

            return stInfix.Pop();
        }
    }
}
