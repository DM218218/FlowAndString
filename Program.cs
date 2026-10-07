using System;
using System.Collections.Generic;
using System.IO;

namespace FlowAndString
{
    enum MenuState
    {
        Unknown = -1,
        MainMenu = 0,
        TicketPriceMenu,
        TicketPriceByAge,
        TicketPriceByAgeForGroup,
        TenfoldRepeat,
        ThirdWord
    }

    internal class Program
    {
        ConsoleDisplay consoleDisplay;
        InputHandler inputHandler;
        ErrorHandler errorHandler;
        TicketPriceCalculator ticketPriceCalculator;

        MenuState currentMenuState = MenuState.MainMenu;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        private void Start()
        {
            consoleDisplay = new ConsoleDisplay("Flow and Strings Master System");
            inputHandler = new InputHandler();
            errorHandler = new ErrorHandler();
            ticketPriceCalculator = new TicketPriceCalculator();
            bool run = true;

            while (run)
            {
                switch (currentMenuState)
                {
                    case MenuState.MainMenu:
                        {
                            consoleDisplay.DisplayMenu(currentMenuState);
                            string input = inputHandler.GetUserInput();

                            switch (input)
                            {
                                case "1":
                                    currentMenuState = MenuState.TicketPriceMenu;
                                    break;
                                case "2":
                                    currentMenuState = MenuState.TenfoldRepeat;
                                    break;
                                case "3":
                                    currentMenuState = MenuState.ThirdWord;
                                    break;
                                case "0":
                                    run = false;
                                    break;
                                default:
                                    errorHandler.HandleError(input, currentMenuState);
                                    break;
                            }
                        }
                        break;
                    case MenuState.TicketPriceMenu:
                        {
                            consoleDisplay.DisplayMenu(currentMenuState);
                            string input = inputHandler.GetUserInput();

                            switch (input)
                            {
                                case "1":
                                    currentMenuState = MenuState.TicketPriceByAge;
                                    break;
                                case "2":
                                    currentMenuState = MenuState.TicketPriceByAgeForGroup;
                                    break;
                                case "0":
                                    currentMenuState = MenuState.MainMenu;
                                    break;
                                default:
                                    errorHandler.HandleError(input, currentMenuState);
                                    break;
                            }
                        }
                        break;
                    case MenuState.TicketPriceByAge:
                        {
                            consoleDisplay.DisplayMenu(currentMenuState);
                            int input = int.MinValue;
                            string individualTicketPrice;

                            try
                            {
                                input = inputHandler.GetUserInputAsInt();
                                individualTicketPrice = ticketPriceCalculator.CalculateTicketPriceByAge(input);
                            }
                            catch (FormatException ex)
                            {
                                errorHandler.HandleError($"{input}", currentMenuState, ex);
                                break;
                            }
                            catch (Exception ex)
                            {
                                errorHandler.HandleError($"{input}", currentMenuState, ex);
                                break;
                            }

                            consoleDisplay.Display(individualTicketPrice);
                            currentMenuState = MenuState.MainMenu;
                        }
                        break;
                    case MenuState.TicketPriceByAgeForGroup:
                        {
                            consoleDisplay.DisplayMenu(currentMenuState);
                            int input = int.MinValue;
                            string groupTicketPrice = "";
                            int groupSize;
                            List<int> groupAges = new List<int>();

                            try
                            {
                                input = inputHandler.GetUserInputAsInt();
                                groupSize = input;

                                for (var i = 0; i < groupSize; i++)
                                {
                                    consoleDisplay.Display("Enter age, confirm with Enter:", false);
                                    groupAges.Add(inputHandler.GetUserInputAsInt());
                                }

                                groupTicketPrice = ticketPriceCalculator.CalculateTicketPriceForGroup(groupAges);
                            }
                            catch (FormatException ex)
                            {
                                errorHandler.HandleError($"{input}", currentMenuState, ex);
                                break;
                            }

                            consoleDisplay.Display(groupTicketPrice);
                            currentMenuState = MenuState.MainMenu;
                        }
                        break;
                    case MenuState.TenfoldRepeat:
                        {
                            consoleDisplay.DisplayMenu(currentMenuState);

                            string input = inputHandler.GetUserInput();

                            ConsoleDisplay.MultiDisplay(input, 10, true);

                            currentMenuState = MenuState.MainMenu;
                        }
                        break;
                    case MenuState.ThirdWord:
                        {
                            consoleDisplay.DisplayMenu(currentMenuState);

                            string input = string.Empty;

                            input = inputHandler.GetUserInput();

                            var splitInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                            if (splitInput.Length < 3)
                            {
                                errorHandler.HandleError(input, currentMenuState);
                                break;
                            }
                            else
                            {
                                consoleDisplay.Display($"The third word is: '{splitInput[2]}'");
                            }

                            currentMenuState = MenuState.MainMenu;
                        }
                        break;
                    default:
                        errorHandler.HandleError("Unknown MenuState", currentMenuState);
                        break;
                }
            }
        }
    }
}
