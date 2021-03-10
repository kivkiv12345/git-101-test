using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace LommeregnerMedRasmus
{
    class Program
    {
        #region operatormethods
        static double Add(double a, double b)
        {
            return a + b;
        }

        static double Minus(double a, double b)
        {
            return a - b;
        }

        static double Multiply(double a, double b)
        {
            return a * b;
        }
        
        static double Divide(double a, double b)
        {
            return a / b;
        }
        #endregion

        /// <summary>
        /// Takes a string with multiple numbers and operators to calculate, example: "5*2/4-2+7*2".
        /// Work In Progress. Not working at the moment, DO NOT USE.
        /// </summary>
        /// <param name="calcString"></param>
        /// <returns>A double that is the result of the calculation</returns>
        static double LongCalculation(string calcString)
        {
            throw new NotImplementedException("LongCalculation has not been finished yet.");

            string patternNaN = "[a-zA-Z]+";
            string patternNum = "[0-9]";
            string[] numberStringArr = Regex.Split(calcString, patternNaN);
            string[] operatorsArr = Regex.Split(calcString, patternNum);
            List<string> operatorList = Regex.Split(calcString, patternNum).ToList();
            for (int i = 0; i < numberStringArr.Length; i++)
            {
                static double CalcCurrent(string operatorString, double a, double b)
                {
                    if(operatorString == "+")
                    {
                        return Add(a, b);
                    }
                    else if(operatorString == "-")
                    {
                        return Minus(a, b);
                    }
                    else if(operatorString == "*")
                    {
                        return Multiply(a, b);
                    }
                    else if(operatorString == "/")
                    {
                        return Divide(a, b);
                    }
                    return 0.0;
                }
                double currentNumber = Convert.ToDouble(numberStringArr[i]);
                bool check = true;
                int pos = Array.IndexOf(operatorsArr, "*");
                if (pos > -1)
                {
                    break;
                }

                try
                {
                    double nextNumber = Convert.ToDouble(numberStringArr[i + 1]);
                }
                catch (Exception)
                {
                    check = false;
                }

                if (check)
                {
                    break;
                }

            }

            return 0.0;
        }

        /// <summary>
        /// Continuously prompts the user for a value until it may be converted to a double.
        /// </summary>
        /// <returns>The provided user input converted to a double.</returns>
        static double ReadDouble()
        {
            try
            {
                return Convert.ToDouble(Console.ReadLine());
            } catch (Exception)
            {
                Console.WriteLine("Could not parse the provided value, please provide a valid input: ");
                return ReadDouble();
            }
        }

        /// <summary>
        /// Continuously prompts the user for an operator until a valid one is provided.
        /// </summary>
        /// <returns>The operator entered by the user.</returns>
        static char ReadOperator()
        {
            List<char> validOperators = new List<char> {'+', '-', '/', '*'};

            char inputkey = Console.ReadKey().KeyChar;

            if (validOperators.Contains(inputkey))
            {
                return inputkey;
            } else
            {
                Console.WriteLine("\nInvalid operator provided. Please provide a valid operator.");
                return ReadOperator();
            }
        }

        /// <summary>
        /// Will prompt the user for the required inputs and perform the desired calculation from there.
        /// </summary>
        static void Main(string[] args)
        {
            // Prompt the user for required variables.
            Console.WriteLine("Please enter your first number: ");
            double firstnumber = ReadDouble();
            Console.WriteLine("Please enter your second number: ");
            double secondnumber = ReadDouble();
            Console.WriteLine("Please enter your operator symbol: ");
            char operatorsymbol = ReadOperator();
            double result;

            switch (operatorsymbol)
            {
                case '-':
                    result = Minus(firstnumber, secondnumber);
                    break;
                case '*':
                    result = Multiply(firstnumber, secondnumber);
                    break;
                case '/':
                    result = Divide(firstnumber, secondnumber);
                    break;
                default:
                    result = Add(firstnumber, secondnumber);
                    break;
            }

            Console.WriteLine("\nYour result is: " + result);
            Console.ReadLine();
        }
    }
}
