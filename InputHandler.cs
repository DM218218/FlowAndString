using System;

namespace FlowAndString
{
    internal class InputHandler
    {
        internal string GetUserInput()
        {
            return Console.ReadLine();
        }

        internal int GetUserInputAsInt()
        {
            string rawInput = Console.ReadLine();

            if (int.TryParse(rawInput, out int input))
            {
                return input;
            }
            else
            {
                throw new FormatException($"Input received '{rawInput}'.");
            }
        }
    }
}