
using System;

namespace String_Expressions
{
    internal class ExpressionSolver
    {
        public int Solve(string input)
        {
            StringParser parser = new StringParser();
            Operation operation = parser.Parser(input);

            return Solve(operation);
        }

        private int Solve(Operation operation)
        {
            if (operation.val != null)
            {
                return Convert.ToInt32(operation.val);
            }

            int value = 0;
            if (operation.sign == '+')
            {
                value = 0;

                foreach (var innerOperation in operation.operations)
                {
                    value += Solve(innerOperation);
                }
            }
            else if (operation.sign == '-')
            {
                if (operation.operations.Count == 1)
                {
                    value -= Solve(operation.operations[0]);
                }
                else
                {
                    value = Solve(operation.operations[0]);

                    for (int i = 1; i < operation.operations.Count; i++)
                    {
                        value -= Solve(operation.operations[i]);
                    }
                }
            }
            else if (operation.sign == '*')
            {
                value = 1;

                foreach (var innerOperation in operation.operations)
                {
                    value *= Solve(innerOperation);
                }
            }
            else if (operation.sign == '/')
            {
                value = Solve(operation.operations[0]);

                for (int i = 1; i < operation.operations.Count;i++)
                {
                    value /= Solve(operation.operations[i]);
                }                
            }
            else if (operation.sign == '%')
            {
                value = Solve(operation.operations[0]);

                for (int i = 1; i < operation.operations.Count; i++)
                {
                    value %= Solve(operation.operations[i]);
                }
            }

            return value;
        }
    }
}
