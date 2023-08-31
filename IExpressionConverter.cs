using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Shunting_Yard_Algorithm
{
    interface IExpressionConverter
    {
        string ConvertToInfix(string strPolishNotation);
    }

}
