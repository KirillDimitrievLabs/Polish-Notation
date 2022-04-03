using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public class PolishNotation
    {
        
        public static double Calculate(string expression)
        {
            string[] splitedExpression = expression.Split(' ', 2); //split by operators and numbers
            if (expression==String.Empty)
            {
                throw new ArgumentNullException();
            }
            else if (splitedExpression[0].Length + 1 != splitedExpression[1].Split(' ').Length)
            {
                throw new FormatException();
            }
            else
            {
                List<char> operators = splitedExpression[0].ToList();
                string[] numbers = splitedExpression[1].Split(' ');

                int result = Int32.Parse(numbers[0]); //first number

                for (int i = 1; i < numbers.Length; i++)
                {
                    for (int j = 0; j < operators.Count; j++)
                    {
                        if (numbers[i] != " ")
                        {
                            switch (operators[j])
                            {
                                case '+':
                                    result += Int32.Parse(numbers[i]);
                                    break;
                                case '-':
                                    result -= Int32.Parse(numbers[i]);
                                    break;
                                case '/':
                                    result /= Int32.Parse(numbers[i]);
                                    break;
                                case '*':
                                    result *= Int32.Parse(numbers[i]);
                                    break;
                                default:
                                    throw new FormatException();
                            }
                            operators.RemoveAt(j);
                            break;
                        }
                    }
                }
                return result;
            }
        }
    }
}
