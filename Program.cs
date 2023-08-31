using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task1_Shunting_Yard_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            RunConverterApp(new PolishNotationConverter());
        }

        static void RunConverterApp(IExpressionConverter converter)
        {
            ConverterApp app = new ConverterApp(converter);
            app.Run();
        }
    }

    
}
