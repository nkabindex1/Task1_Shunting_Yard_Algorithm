using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Shunting_Yard_Algorithm
{
    class ConverterApp
    {
        private readonly IExpressionConverter _converter;

        public ConverterApp(IExpressionConverter converter)
        {
            _converter = converter;
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                string strPolishNotation = GetUserInput();

                if (strPolishNotation != null)
                {
                    string strInfix = ConvertToInfix(strPolishNotation);
                    DisplayResults(strPolishNotation, strInfix);
                }

                running = AskToContinue();
                ClearConsole();
            }

            ExitApplication();
        }
        private string GetUserInput()
        {
            Console.WriteLine("Enter the arithmetic in Reverse Polish Notation: ");
            return Console.ReadLine();
        }

        private string ConvertToInfix(string strPolishNotation)
        {
            return _converter.ConvertToInfix(strPolishNotation);
        }

        private void DisplayResults(string rpnExpression, string infixExpression)
        {
            Console.WriteLine("RPN Expression: " + rpnExpression);
            Console.WriteLine("Infix Notation: " + infixExpression);
        }

        private bool AskToContinue()
        {
            Console.WriteLine("Continue converting? Y (Yes)/ N (exit) ");
            string response = Console.ReadLine();
            return string.Equals(response, "Y", StringComparison.OrdinalIgnoreCase);
        }

        private void ClearConsole()
        {
            Console.Clear();
        }

        private void ExitApplication()
        {
            Console.Write("Exiting application. Click any key to remove console.");
            Console.ReadLine();
        }

    }
}
