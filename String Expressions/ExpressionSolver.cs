using System;

namespace String_Expressions
{
    public class ExpressionSolver
    {
        public float Solve(string input)
        {
            StringParser parser = new StringParser();
            Operation operation = parser.Parser(input);

            return Solve(operation);
        }

        private float Solve(Operation operation)
        {
            if (operation.Val != null)
            {
                return Convert.ToInt32(operation.Val);
            }

            float value = 0;
            if (operation.Sign == '+')
            {
                value = 0;

                foreach (var innerOperation in operation.Operations)
                {
                    value += Solve(innerOperation);
                }
            }
            else if (operation.Sign == '-')
            {
                if (operation.Operations.Count == 1)
                {
                    value -= Solve(operation.Operations[0]);
                }
                else
                {
                    value = Solve(operation.Operations[0]);

                    for (int i = 1; i < operation.Operations.Count; i++)
                    {
                        value -= Solve(operation.Operations[i]);
                    }
                }
            }
            else if (operation.Sign == '*')
            {
                value = 1;

                foreach (var innerOperation in operation.Operations)
                {
                    value *= Solve(innerOperation);
                }
            }
            else if (operation.Sign == '/')
            {
                value = Solve(operation.Operations[0]);

                for (int i = 1; i < operation.Operations.Count;i++)
                {
                    value /= Solve(operation.Operations[i]);
                }                
            }
            else if (operation.Sign == '%')
            {
                value = Solve(operation.Operations[0]);

                for (int i = 1; i < operation.Operations.Count; i++)
                {
                    value %= Solve(operation.Operations[i]);
                }
            }
             
            return value; 
        }
    }
}
