using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace assignment1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            UserInterface.initializeConsoleWindow("CIS 237 | ASSIGNMENT 1 | ZACHARY DWYER", ConsoleColor.Black, ConsoleColor.White);        // Set up the console window's colors and window title
            mainProgramLoop();                                                                                                              // Start main loop of program
        }

        private static void mainProgramLoop()
        {
            while (true)
            {
                int menuSelection = UserInterface.GetMainMenuSelection(Globals.mainMenuChoices, "Wine List Program - Main Menu");           // Get menu selection from user
                handleMenuSelection(menuSelection);                                                                                         // Handle what they selected
            }
        }

        // This is the part of the program that takes a number and executes its corresponding method
        private static void handleMenuSelection(int optionChoice)
        {
            switch (optionChoice) {
                case 1:
                    // Load wine list
                    loadWineList();
                    mainProgramLoop();
                    break;
                case 2:
                    // Print wine list
                    printWineList();
                    mainProgramLoop();
                    break;
                case 3:
                    // Search wine list
                    searchWineList();
                    mainProgramLoop();
                    break;
                case 4:
                    // Add new wine item to list
                    addToWineList();
                    mainProgramLoop();
                    break;
                case 5:
                    // Exit program
                    Environment.Exit(0);
                    break;
                default:
                    // Should never happen
                    Debug.WriteLine("Program.handleMenuSelection() given a wrong optionChoice!");
                    break;
            }
        }

        private static void loadWineList()
        {
            UserInterface.ResetScreen();
            CSVProcessor.PopulateWineItemList();
            UserInterface.SetStatus(UserInterface.GeneratePressAnyKeyPhrase());
            Console.ReadKey(true);
            mainProgramLoop();
        }

        private static void printWineList()
        {
            // UserInterface.PrintQuestion, when required to give a numeric answer, will always output a whole number
            int linesPerPage = int.Parse(UserInterface.PrintQuestion("How many lines do you want printed per page? (1-1000)", "Enter a whole number between 1 and 1000.", false, true, 1, 1000));
            UserInterface.PrintWineItems(linesPerPage);
        }

        private static void searchWineList()
        {
            UserInterface.SearchWineItemList();
        }

        private static void addToWineList()
        {
            if (Globals.wineListLoaded)
            {
                string id = UserInterface.PrintQuestion("Enter ID of the Wine Item: ", "Please enter the ID of the Wine Item.", false);
                string description = UserInterface.PrintQuestion("Enter the Description of the Wine Item: ", "Please enter the Description of the Wine Item.", false);
                string pack = UserInterface.PrintQuestion("Enter the Pack value of the Wine Item: ", "Please enter the Pack value of the Wine Item.", false);

                Globals.wineItemList.Add(new WineItem(id, description, pack));

                UserInterface.ResetScreen();
                Console.WriteLine("Wine item added!");
                UserInterface.SetStatus(UserInterface.GeneratePressAnyKeyPhrase());
                Console.ReadKey();
            }
            else
            {
                UserInterface.PrintFatalError("Wine list must be loaded before adding to it!");
                Console.ReadKey(true);
            }
        }
    }
}
