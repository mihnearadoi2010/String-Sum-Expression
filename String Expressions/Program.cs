
using System;

namespace String_Expressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "( * ( + ( / 4 2 ) 3 ) ( - 8 6 ) 3 )";
            
            ExpressionSolver solver = new ExpressionSolver();
            Console.Write(solver.Solve(input));

        }
    }
}
