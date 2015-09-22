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

        /* INITIALIZE CONSOLE WINDOW */
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
            resetScreen();    

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

        /* HANDLE KEY PRESSED BY USER (IN THE FORM OF A CHARACTER) */
        private static void handleKeyOption(char key)
        {
            switch (key)
            {
                case '1':
                    Globals.myCSVProcessor.processFile();
                    resetScreen();
                    Console.WriteLine("File successfully read!");
                    setStatus("Press any key to continue");
                    Console.ReadKey(true);
                    break;
                case '2':
                    printList();
                    break;
                case '3':
                    printFatalError("Has not been created yet.");
                    Console.ReadKey(true);
                    break;
                case '4':
                    printFatalError("Has not been created yet.");
                    Console.ReadKey(true);
                    break;
                case '5':
                    Environment.Exit(0);
                    break;
            }
        }

        /* USED TO UPDATE PROGRAM STATUS */
        private static void setStatus(string status)
        {
            Console.SetCursorPosition(0, 21);           // Set position of cursor
            Console.WriteLine(" ----------------------");           
            clearCurrentConsoleLine();                  // Clears the existing status
            Console.WriteLine(" " + status);            // Writes a new status
            Console.WriteLine(" ----------------------");
        }

        /* USED TO UPDATE PROGRAM STATUS, WITH A CUSTOM STARTING ROW */
        private static void setStatus(string status, int startingRow)
        {
            Console.SetCursorPosition(0, startingRow);           // Set position of cursor
            Console.WriteLine(" ----------------------");
            clearCurrentConsoleLine();                          // Clears the existing status
            Console.WriteLine(" " + status);                    // Writes a new status
            Console.WriteLine(" ----------------------");
        }

        /* CLEARS THE ENTIRE LINE THAT THE CURSOR IS CURRENT AT */
        public static void clearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        /* PRINT HUGE ERROR THAT WILL STOP THE PROGRAM */
        public static void printFatalError(string errorText)
        {
            // doesn't actually stop the program, just takes care of the looks
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White; 
            Console.Clear();
            Console.SetCursorPosition(1, 11);
            Console.WriteLine(errorText);
        }

        /* PRINT A LIST OF WINEITEMS */ 
        public static void printList()
        {
            // Check if the list was loaded
            if (Globals.wineListLoaded == false)
            {
                resetScreen();
                Console.WriteLine("No WineItems have been added to the list.");
                setStatus("Press any key to continue");
                Console.ReadKey(true);
                printMainMenu();
            }
            else
            {
                int linesCounter = 0;

                resetScreen();

                foreach (WineItem wineItem in Globals.wineItemList.getList())
                {
                    if (linesCounter > 18) {
                        setStatus("Press any key to continue printing list.");  // Prompt
                        Console.ReadKey(true);                                  // Let user hit a key to continue
                        linesCounter = 0;                                       // Reset number of lines printed
                        resetScreen();                                          // Reset the screen
                    }

                    // Print a line
                    Console.WriteLine(" " + wineItem.ID + ", " + wineItem.Description + ", " +
                        wineItem.Pack);

                    // Increment lines counter
                    linesCounter++;
                }

                /* DONE PRINTING LIST */
                setStatus("Press any key to go back to the main menu.");
                Console.ReadKey(true);
                printMainMenu();
            }
        }

        /* GET SCREEN READY FOR A NEW STANDARD MENU */
        private static void resetScreen()
        {
            Console.SetCursorPosition(1, 1);
            Console.Clear();
        }
    }
}
