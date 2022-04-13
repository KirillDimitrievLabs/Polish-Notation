using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Utilities
{
    static class Utils
    {
        private readonly static string PossibleOperators = "+-/*";
        private static string WrongFormatExceptionString = "Wrong expression format";

        // Расчёт выражения по токенам
        internal static double CalculateTokensExpression(string[] tokens)
        {
            //Проверка на количество операндов и операторов
            if (IsCorrectNumsOfTokens(tokens) == true)
            {
                List<string> elements = new List<string>();

                //  массив с токенами перебираем с конца
                for (int i = tokens.Length - 1; i >= 0; i--)
                {
                    // если токен это оператор
                    if (PossibleOperators.Contains(tokens[i]))
                    {
                        try
                        {
                            // Операнды
                            double a = double.Parse(elements[elements.Count - 1]);
                            double b = double.Parse(elements[elements.Count - 2]);

                            elements.RemoveRange(elements.Count - 2, 2);

                            elements.Add(CalculateTwoDigitsWithOperator(tokens[i], a, b).ToString());
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            throw new FormatException(WrongFormatExceptionString);
                        }
                    }
                    // Если токен является операндом
                    else if (double.TryParse(tokens[i], out _))
                    {
                        // Добавляем в конец
                        elements.Add(tokens[i]);
                    }
                    else
                    {
                        throw new FormatException("Unknown symbol '" + tokens[i] + "' ");
                    }
                }
                return double.Parse(elements[0]);
            }
            else
            {
                throw new FormatException(WrongFormatExceptionString);
            }
        }

        // Метод разделения на токены
        internal static string[] SplitIntoTokens(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new ArgumentNullException(nameof(expression), "Input string cannot be empty or WhiteSpace");
            }
            else
            {
                // Заменяем множественные пробелы на одинарный и
                // обрезаем пробелы в начале и конце
                expression = Regex.Replace(expression, @"\s+", " ").Trim();

                // Разделяем выражение на токены и возвращаем
                Console.WriteLine(expression);
                return expression.Split(' ');
            }
        }
        
        // Метод проверки на корректность количества операторов и операндов
        private static bool IsCorrectNumsOfTokens(string[] tokens)
        {
            List<string> operators = new List<string>();
            List<string> digits = new List<string>();

            for (int i = 0; i < tokens.Length; i++)
            {
                if (!double.TryParse(tokens[i], out _))
                {
                    operators.Add(tokens[i]);
                }
                else
                {
                    digits.Add(tokens[i]);
                }
            }

            if (digits.Count == operators.Count+1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Метод расчёта двух чисел с оператором типа string
        private static double CalculateTwoDigitsWithOperator(string _operator, double firstOperand, double secondOperand)
        {
            double result;
            if (!Char.IsLetter(Char.Parse(_operator)))
            {
                switch (_operator)
                {
                    case "+":
                        result = firstOperand + secondOperand;
                        break;
                    case "-":
                        result = firstOperand - secondOperand;
                        break;
                    case "/":
                        // Проверка на деление на 0
                        if (secondOperand != 0)
                        {
                            result = firstOperand / secondOperand;
                        }
                        else
                        {
                            throw new DivideByZeroException();
                        }
                        break;
                    case "*":
                        result = firstOperand * secondOperand;
                        break;
                    default:
                        throw new Exception("Unknown operand");
                }
                return result;
            }
            else
            {
                throw new FormatException("Input string cannot contain letters");
            }
        }
    }
}
