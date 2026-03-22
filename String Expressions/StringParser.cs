using System;
using System.Collections.Generic;
using System.Linq;

namespace String_Expressions
{
    public class StringParser
    {
        public Operation Parser(string input)
        {
            int index = 0;
            List<string>chars = input.Replace("(", " ( ").Replace(")", " ) ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            return Parser(chars, ref index);
        }

        private Operation Parser(List<string> chars, ref int index)
        {
            Operation operation = new Operation();

            if (chars[index] != "(")
            {
                operation.Val = Convert.ToInt32(chars[index++]);
                return operation;
            }

            index++;
            operation.Sign = Convert.ToChar(chars[index++]);

            while (chars[index] != ")")
            {
                operation.Operations.Add(Parser(chars, ref index));
            }

            index++;
            return operation;
        }

        private Operation Parser2(string input)
        {
            Operation operation = new Operation();

            HashSet<char> signs = new HashSet<char>()
            {
                { '+' },
                { '-' },
                { '*' },
                { '/' },
                { '%' }
            };

            if (int.TryParse(input, out int value))
            {
                operation.Val = value;
                return operation;
            }

            for (int i = 1; i < input.Length - 1; i++) 
            {
                var currentChar = input[i];

                if (signs.Contains(currentChar) && operation.Sign == null)
                {
                    operation.Sign = currentChar;
                }

                if (currentChar == '(')
                {
                    Stack<char> paranthesis = new Stack<char>();
                    for (int j = i; j < input.Length - 1; j++)
                    {

                        if (input[j] == '(')
                        {
                            paranthesis.Push(input[j]);
                        }
                        else if (input[j] == ')')
                        {
                            paranthesis.Pop();
                        }

                        if (paranthesis.Count == 0)
                        {
                            var newOperation = input.Substring(i, j - i + 1);
                            operation.Operations.Add(Parser2(newOperation));
                            i = j;
                            break;
                        }
                    }
                }
                if (input[i - 1] == ' ' && char.IsDigit(currentChar))
                {
                    var newOperation = input.Substring(i, input.IndexOf(' ', i) - i);
                    operation.Operations.Add(Parser2(newOperation));
                }
            }


            return operation;
        }
    }
}
