using System;

namespace FlowAndString
{
    internal class ErrorHandler
    {
        internal void HandleError(string userInput, MenuState menuState)
        {
            switch (menuState)
            {
                case MenuState.MainMenu:
                case MenuState.TicketPriceMenu:
                    Console.WriteLine($"Invalid input: '{userInput}'. Please enter a valid option from the menu.");
                    break;
                case MenuState.TicketPriceByAge:
                    Console.WriteLine($"Invalid age input: '{userInput}'. Please enter a valid age (0 or above).");
                    break;
                case MenuState.TicketPriceByAgeForGroup:
                    Console.WriteLine($"Invalid group size input: '{userInput}'. Please enter a valid number of people.");
                    break;
                case MenuState.ThirdWord:
                    Console.WriteLine("Please enter at least three words.");
                    break;
                default:
                    Console.WriteLine($"An unexpected error occurred with input: '{userInput}'.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        internal void HandleError(string userInput, MenuState menuState, FormatException ex)
        {
            switch (menuState)
            {
                case MenuState.TicketPriceByAge:
                    Console.WriteLine($"Age must be a number. {ex.Message}.");
                    Console.WriteLine("Please enter a valid age (0 or above).");
                    break;
                case MenuState.TicketPriceByAgeForGroup:
                    Console.WriteLine($"Age must be a number. {ex.Message}.");
                    Console.WriteLine("Please enter a valid number of people.");
                    break;
                default:
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        internal void HandleError(string userInput, MenuState menuState, Exception ex)
        {
            switch (menuState)
            {
                case MenuState.TicketPriceByAge:
                    Console.WriteLine($"{ex.Message}.");
                    Console.WriteLine("Please enter a valid age (0 or above).");
                    break;
                default:
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}