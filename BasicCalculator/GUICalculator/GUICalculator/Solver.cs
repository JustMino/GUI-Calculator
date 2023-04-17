using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace GUICalculator
{
    public class Solver : ISolve
    {
        // Define attributes to be use
        public string[] equation;

        string[] splitequation;

        public bool error = false;

        // Constructor to initialize display equation and set 2nd line to ----------------------------
        public Solver()
        {
            equation = new string[3];
            equation[1] = "---------------------------";
        }

        // Keep adding to string to create equation
        public void Accumulate(string s)
        {
            error = false;
            string temp = equation[0] + s;
            equation[0] = temp;
        }

        public double Solve()
        {
            bool firstnegative = false;
            // Split the equation string into individual components Example: 2*3+6/3 becomes 2, *, 3, +, 6, /, 3
            splitequation = Regex.Split(equation[0], @"([*\/\%\+\-])");
            Debug.WriteLine("Equation:");
            foreach (string s in splitequation) { Debug.WriteLine(s); }
            string exceptions = "*/%";

            // Create Stack to contain double for calculation
            Stack<double> stack = new Stack<double>();

            // Push first number to start
            if (splitequation[1] == "-")
            {
                double temp = double.Parse(splitequation[2]);
                temp *= -1;
                stack.Push(temp);
                firstnegative = true;
            }
            else if (exceptions.Contains(splitequation[0]))
            {
                error = true;
                return 0;
            }
            else
            {
                stack.Push(double.Parse(splitequation[0]));
            }

            int startpos = 1;
            if (firstnegative) { startpos = 3; }

            for (int i = startpos; i < splitequation.Length; i += 2)
            {
                char operation = splitequation[i][0];
                double nextnum;
                if (splitequation[i+1] != "-") nextnum = double.Parse(splitequation[i + 1]);
                
                // if multiply divide, or mod pop the last pushed number in order to apply the multiply before doing the addition at the end
                if (operation == '*')
                {
                    double result = stack.Pop() * nextnum;
                    stack.Push(result);
                }
                else if (operation == '/')
                {
                    double result = stack.Pop() / nextnum;
                    stack.Push(result);
                }
                else if (operation == '%')
                {
                    double result = stack.Pop() % nextnum;
                    stack.Push(result);
                }
                // if add or subtract push the numbers with the respective + or - added to the front
                else if (operation == '+') { stack.Push(nextnum); }
                else if (operation == '-') { stack.Push(-nextnum); }
            }

            // Create temporary double to contain final result
            double total = 0;
            // Keep adding to the total to calculate final result
            while (stack.Count > 0) { total += stack.Pop(); }

            // Return total
            Debug.WriteLine(total);
            return total;
        }

        // Clear by setting equation sections by setting both to null
        public void Clear()
        {
            equation[0] = "";
            equation[2] = "";
        }
    }
}
