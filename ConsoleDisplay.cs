using System;
using static System.Net.Mime.MediaTypeNames;

namespace FlowAndString
{
    internal class ConsoleDisplay
    {
        public ConsoleDisplay(string programName)
        {
            ProgramName = programName;
        }

        string ProgramName { get; set; }

        internal void DisplayMenu(MenuState menuState = MenuState.MainMenu)
        {
            DisplayMenuHeader(ProgramName);
            DisplayUsageSimpleInstructions(menuState);

            switch (menuState)
            {
                case MenuState.MainMenu:
                    DisplayMenuChoices(menuState);
                    break;
                case MenuState.TicketPriceMenu:
                    DisplayMenuChoices(menuState);
                    break;
                case MenuState.TicketPriceByAge:
                case MenuState.TicketPriceByAgeForGroup:
                case MenuState.TenfoldRepeat:
                case MenuState.ThirdWord:
                    break;
                default:
                    break;
            }
        }

        private void DisplayMenuChoices(MenuState menuState)
        {
            switch (menuState)
            {
                case MenuState.MainMenu:
                    Console.WriteLine("1. Movie Ticket Calculator");
                    Console.WriteLine("2. Tenfold Repeater");
                    Console.WriteLine("3. Third Word Picker");
                    Console.WriteLine("0. Exit Application");
                    Console.WriteLine();
                    break;
                case MenuState.TicketPriceMenu:
                    Console.WriteLine("1. Calculate Ticket Price by Age");
                    Console.WriteLine("2. Calculate Ticket Price by Age for Group");
                    Console.WriteLine("0. Back to Main Menu");
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine($"Error: Unrecognized menu state: {menuState}");
                    break;
            }
        }

        //show an instruction and welcome text
        private void DisplayUsageSimpleInstructions(MenuState menuState)
        {
            switch (menuState)
            {
                case MenuState.MainMenu:
                    Console.WriteLine("Welcome to the Flow and Strings Master System!");
                    Console.WriteLine("Enter a number to select an option from the menu. Confirm with Enter.");
                    break;
                case MenuState.TicketPriceMenu:
                    Console.WriteLine("Welcome to the Ticket Price Calculator!");
                    Console.WriteLine("Enter a number to select an option from the menu. Confirm with Enter.");
                    break;
                case MenuState.TicketPriceByAge:
                    Console.WriteLine("Welcome to the Ticket Price Calculator!");
                    Console.WriteLine("Enter your age to calculate the ticket price. Confirm with Enter.");
                    break;
                case MenuState.TicketPriceByAgeForGroup:
                    Console.WriteLine("Welcome to the Ticket Price Calculator!");
                    Console.WriteLine("Enter the number of people in your group to calculate the total ticket price. Confirm with Enter.");
                    break;
                case MenuState.TenfoldRepeat:
                    Console.WriteLine("Welcome to the Tenfold Repeater!");
                    Console.WriteLine("Enter a text you would like to have repeated. Confirm with Enter.");
                    break;
                case MenuState.ThirdWord:
                    Console.WriteLine("Welcome to the Third Word Picker!");
                    Console.WriteLine("Enter a series of words separated by spaces. There needs to be at least three words. Confirm with Enter.");
                    break;
                default:
                    Console.WriteLine($"Error: Unrecognized menu state: {menuState}");
                    break;
            }
            Console.WriteLine();
        }

        private void DisplayMenuHeader(string programName)
        {
            Console.Clear();

            //make a nice header frame
            for (int i = 0; i < programName.Length + 6; i++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
            Console.WriteLine($"*  {programName}  *");

            for (int i = 0; i < programName.Length + 6; i++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }

        internal void Display(string text, bool hold = true)
        {
            Console.WriteLine(text);

            //hold the console on current display until user input
            if (hold)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        internal static void MultiDisplay(string input, int numberOfRepeats, bool singleLine = false)
        {
            for(int i = 0; i < numberOfRepeats; i++)
            {
                if(singleLine)
                {
                    //print on one line
                    Console.Write($"{i + 1}: {input}");

                    if(i < numberOfRepeats - 1)
                    {
                        //Put a separtor except after the last print
                        Console.Write(", ");
                    }
                }
                else
                {
                    //print on multiple lines
                    Console.WriteLine($"{i + 1}: {input}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}