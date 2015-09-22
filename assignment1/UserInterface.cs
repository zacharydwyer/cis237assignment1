using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{

    // Class that handles all dealings with the console UI.

    // Columns 0 - 20 are reserved for the main screen.
    // Columns 21 - 24 are reserved for the "status bar" which helps inform the user on what key to press/what to do next/what happened
    // The "status bar" is taken care of in the "setStatus" method.

    static class UserInterface
    {

        // When redrawing the top part of the screen, this holds the last status applied.
        // _______***** note to self GET RID OF THIS IF YOU NEVER USE IT
        private static string currentStatus = "Ready";

        // Set the title, color, etc. of console window
        public static void initializeConsoleWindow(string windowTitle, ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            Console.Title = windowTitle;                                        // Set title
            Console.BackgroundColor = backgroundColor;                          // Set back and foreground colors of console window
            Console.ForegroundColor = foregroundColor;
            Console.CursorVisible = false;                                      // Do not show the cursor (this is a press-a-key kinda UI not a type-it-in)
            Console.Clear();                                                    // Resets console window which in turn applies the new specified colors
            Console.WindowHeight = 25;
            Console.WindowWidth = 100;
        }

        // 
        public static void printMainMenu()
        {
            // Get the cursor ready
            Console.SetCursorPosition(1, 1);     

            // Print the menu
            Console.WriteLine("MAIN MENU" + Environment.NewLine + " ------------------------------" + 
                Environment.NewLine + " 1 - Load Wine List" + 
                Environment.NewLine + " 2 - Print Wine List" +
                Environment.NewLine + " 3 - Search Wine List" + 
                Environment.NewLine + " 4 - Add New Wine to List" +
                Environment.NewLine + " 5 - Exit Program");
            
            // Handle the main menu options; don't stop until a valid menu option has been pressed.
            char hitKey;                    // Holds character of key that will soon be pressed by the user within the following do-while

            do
            {
                setStatus("Press a number key corresponding to the menu option.");      // Prompt status

                hitKey = Console.ReadKey(true).KeyChar;                            // Get the key the user hit

                // Check if the key hit was one of these options
                if (hitKey == '1' || hitKey == '2' || hitKey == '3' || hitKey == '4' || hitKey == '5')
                {
                    break;      // Key is valid - get outta here
                }
                else
                {
                    setStatus("Key not recognized. (Press any key to continue)");
                    Console.ReadKey(true);
                }

            } while (true);

            // Handle the key the user put in
            handleKeyOption(hitKey);
        }

        // Handles the characters 1 through 5
        // Called from printMainMenu
        private static void handleKeyOption(char key)
        {
            Console.Clear();
            Console.WriteLine("You're done son");
            Console.ReadKey(true);
        }

        // Set the status of the program
        private static void setStatus(string status)
        {
            Console.SetCursorPosition(0, 21);           // Set position of cursor
            Console.WriteLine(" ----------------------");           
            ClearCurrentConsoleLine();                  // Clears the existing status
            Console.WriteLine(" " + status);            // Writes a new status
            Console.WriteLine(" ----------------------");
        }

        private static void setStatus(string status, int startingRow)
        {
            Console.SetCursorPosition(0, 21);           // Set position of cursor
            Console.WriteLine(" ----------------------");
            ClearCurrentConsoleLine();                  // Clears the existing status
            Console.WriteLine(" " + status);            // Writes a new status
            Console.WriteLine(" ----------------------");
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }



        // GOD LEFT ME UNFINISHED
        // Prints a WineItemList out. 
        public static void printList(WineItemList wineItemList, int linesAtATime)
        {
            // Check if first item is empty/null (means the wineItemList hasn't been added to yet)
            if (wineItemList.List()[0].ID == String.Empty || wineItemList.List()[0].ID == null)
            {
                
            }
        }
    }
}
