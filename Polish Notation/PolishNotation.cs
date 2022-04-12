using System;
using Utilities;
namespace Calculator
{
    public class PolishNotation
    {
        public static double Calculate(string expression)
        {
            // Разделение на токены
            string[] tokens = Utils.SplitIntoTokens(expression);
            
            // Расчитываем и возвращаем
            return Utils.CalculateTokensExpression(tokens);
        }
    }
}
