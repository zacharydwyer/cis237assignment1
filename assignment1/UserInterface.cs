using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{

    // Class that handles all dealings with the console UI.
    static class UserInterface
    {

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

        /* PRINTS MAIN MENU; RETURNS NUMERIC ANSWER */
        public static int GetMainMenuSelection(string[] choices, string mainMenuTitle)
        {
            if (choices.Length > 9)
            {
                throw new System.Exception("Max size of 'choices' is 9.");                              // Crash program if given an amount of choices less than 9 (1 - 9 keys on keyboard)
            }

            ResetScreen();                                                                              // Reset the screen
            Console.WriteLine(mainMenuTitle + Environment.NewLine + Environment.NewLine);               // Print menu title

            for (int i = 0; i < choices.Length; i++)                                                    // Print out every option
            {
                Console.WriteLine(" " + (i + 1) + " - " + choices[i]);                                        // Print out " # - Choice goes here"
            }

            char hitKey;                                                                                // Hold the key that the user hit here, for later return statement

            do
            {                                                                                           // Keep looping until the user hits a valid key
                UserInterface.SetStatus("Press a number key corresponding to the menu option.");

                hitKey = Console.ReadKey(true).KeyChar;                                                 // Read the key the user pressed                               

                if (Char.IsNumber(hitKey) &&                                                            // Key must be a number between 0 and the 
                    (int.Parse(hitKey.ToString()) <= Globals.mainMenuChoices.Length) &&
                    (int.Parse(hitKey.ToString()) > 0))      
                {
                    break;      // Choice was valid.
                }
                else
                {
                    UserInterface.SetStatus("Key not recognized. (Press any key to continue)");
                    Console.ReadKey(true);
                }

            } while (true);     // Is a while(true) with a break in there somewhere good practice?

            return int.Parse(hitKey.ToString());      // This is the purpose of this method - to get the choice that the user selected (now in the form of a number)
        }

        // Columns 21 - 24 are reserved for the "status bar" which helps inform the user on what key to press/what to do next/what happened
        /* UPDATE THE PROGRAM STATUS, ALSO, CAN CUSTOMIZE WHAT LINE YOU WANT THE STATUS TO START AT (DEFAULT START DEFINED IN 'GLOBALS' CLASS */
        public static void SetStatus(string status)
        {
            // Before writing anything, get position of cursor on console right now
            int cursorPosLeft = Console.CursorLeft;
            int cursorPosTop = Console.CursorTop;

            Console.SetCursorPosition(0, Globals.defaultStatusLineStart);       // Set position of cursor
            Console.WriteLine(" ----------------------");                       
            ClearCurrentConsoleLine();                                          // Clears the existing status
            Console.WriteLine(" " + status);                                    // Writes a new status
            Console.WriteLine(" ----------------------");

            Console.SetCursorPosition(cursorPosLeft, cursorPosTop);             // Put the cursor back where it was
        }
        public static void SetStatus(string status, int startingRow)
        {
            // Before writing anything, get position of cursor on console right now
            int cursorPosLeft = Console.CursorLeft;
            int cursorPosTop = Console.CursorTop;

            Console.SetCursorPosition(0, startingRow);                          // Set position of cursor
            Console.WriteLine(" ----------------------");
            ClearCurrentConsoleLine();                                          // Clears the existing status
            Console.WriteLine(" " + status);                                    // Writes a new status
            Console.WriteLine(" ----------------------");

            Console.SetCursorPosition(cursorPosLeft, cursorPosTop);     // Put the cursor back where it was
        }

        /* CLEAR THE ENTIRE LINE THAT THE CURSOR IS CURRENTLY AT */
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        /* PRINT BIG RED ERROR SCREEN */
        public static void PrintFatalError(string errorText)
        {
            // doesn't actually stop the program, just takes care of the looks
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White; 
            Console.Clear();
            Console.SetCursorPosition(1, 11);
            Console.WriteLine(errorText);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        /* ASKS USER A QUESTION AND RETURNS THE ANSWER */
        public static string PrintQuestion(string query, string captionStatus, bool allowBlankAnswer) {

            string answer;                      // Holds the answer
            bool validAnswer = false;           // Holds status of answer validity

            ResetScreen();                      // Reset the screen (console pos 1,1)
            Console.WriteLine(query);           // Print the question
            Console.CursorVisible = true;       // Make cursor visible
            
            do
            {
                SetStatus(captionStatus);           // Set the status to the caption (usually extra information like "the search term cannot be more than 100 characters")
                Console.SetCursorPosition(1, 3);    // Set cursor to typing area
                ClearCurrentConsoleLine();          // Clear line of any previous questions
                Console.SetCursorPosition(1, 3);    // Set up the cursor position for the user to type.

                answer = Console.ReadLine();        // Get the answer from the user

                if (allowBlankAnswer == false)      // Did they allow the answer to be blank?
                {
                    if (String.IsNullOrEmpty(answer))                                           // Check if it was blank
                    {
                        SetStatus("Answer must not be blank. (Press any key to continue).");    // The answer was blank. 
                        Console.ReadKey(true);                                                  
                    }
                    else
                    {
                        validAnswer = true;
                    }
                }
                else
                {
                    validAnswer = true;
                }

            } while (!validAnswer);                 // Do this until the answer is valid

            Console.CursorVisible = false;          // After all of this, hide the cursor again
            return answer;                          // Finally, give them the answer that the user entered.                     
        }
        public static string PrintQuestion(string query, string captionStatus, bool allowBlankAnswer, bool requireNumericAnswer, int lowestAllowed, int highestAllowed)
        {
            string answer;                      // Holds the answer
            bool validAnswer = false;           // Holds status of answer validity

            ResetScreen();                      // Reset the screen (console pos 1,1)
            Console.WriteLine(query);           // Print the question
            Console.CursorVisible = true;       // Make cursor visible

            do
            {
                SetStatus(captionStatus);           // Set the status to the caption (usually extra information like "the search term cannot be more than 100 characters")
                Console.SetCursorPosition(1, 3);    // Set cursor to typing area
                ClearCurrentConsoleLine();          // Clear line of any previous questions
                Console.SetCursorPosition(1, 3);    // Set up the cursor position for the user to type.
                answer = Console.ReadLine();        // Get the answer from the user

                if (allowBlankAnswer == false)      // Do they not allow blank answers?
                {
                    if (String.IsNullOrEmpty(answer))                                           // Answer should not be blank. Is it blank?
                    {
                        SetStatus(GeneratePressAnyKeyPhrase("Answer cannot be blank."));        // The answer was blank. 
                        Console.ReadKey(true);
                    }
                    else
                    {
                        if (requireNumericAnswer)                                               // Answer was not blank. Do they require a numeric answer?
                        {
                            int number;
                            if (!int.TryParse(answer, out number) || number < lowestAllowed || number > highestAllowed) // Answer was not numeric, or between the lowest and highest allowed number.
                            {
                                SetStatus(GeneratePressAnyKeyPhrase("Answer must be a whole number between " + lowestAllowed + " and " + highestAllowed + "."));
                                Console.ReadKey(true);
                            }
                            else 
                            {
                                validAnswer = true;                                             // Answer was numeric
                            }
                        }
                        else 
                        {
                            validAnswer = true;                                                 // They did not require a numeric answer, but the answer was not blank
                        }
                    }
                }
                else
                {
                    validAnswer = true;                                                         // Answer was allowed blank
                }

            } while (!validAnswer);

            Console.CursorVisible = false;      // After all of this, hide the cursor again
            return answer;                      // Finally, give them the answer that the user entered.
        }

        /* GET SCREEN READY FOR A NEW STANDARD MENU */
        public static void ResetScreen()
        {
            Console.Clear();
            Console.SetCursorPosition(1, 1);
        }

        /* RETURN "PRESS ANY KEY TO CONTINUE" PHRASE */
        public static string GeneratePressAnyKeyPhrase()
        {
            return "Press any key to continue...";
        }
        public static string GeneratePressAnyKeyPhrase(string message)
        {
            return (message + " (Press any key to continue...)");
        }

        /* PRINT WINE ITEM LIST */
        public static void PrintWineItems(int maxLinesPerPage)
        {
            UserInterface.ResetScreen();

            if (Globals.wineListLoaded == false)                // Was the wine list already loaded?
            {
                PrintFatalError("Wine list must be loaded before printing!");
                Console.ReadKey(true);
            }
            else
            {
                int wineItemsLeftToPrint = Globals.wineItemList.GetList().Length;               // How many records are left to print
                int linesPrinted = 0;                                                           // How many have we printed so far

                // Print out all of the wineItems
                foreach (WineItem wineItem in Globals.wineItemList.GetList())
                {
                    if (linesPrinted >= maxLinesPerPage)
                    {
                        SetStatus(GeneratePressAnyKeyPhrase(), (Console.CursorTop + 1));
                        Console.ReadKey(true);
                        UserInterface.ResetScreen();
                        linesPrinted = 0;
                    }

                    Console.WriteLine(" " + wineItem.ID + ", " + wineItem.Description + ", " + wineItem.Pack);
                    linesPrinted++;
                }

                SetStatus(GeneratePressAnyKeyPhrase("Done printing."), (Console.CursorTop + 1));
                Console.ReadKey(true);
            }
        }

        /* SEARCH THROUGH WINE ITEM LIST */
        public static void SearchWineItemList()
        {
            if (Globals.wineListLoaded == true)
            {
                // Ask them from what they want to search through, and what term they want to search with.
                int numberSelection = int.Parse(PrintQuestion("Query from (1) IDs, (2) Descriptions, (3) Packs or (4) all?", "Enter a number between 1 and 4.", false, true, 1, 4));
                string query = PrintQuestion("Enter your query: ", "Enter your search term.", false);
                bool resultsFound = false;

                ResetScreen();

                foreach (WineItem currentWineItem in Globals.wineItemList.GetList())
                {          // Query the whole list
                    if (numberSelection == 1 || numberSelection == 4)
                    {
                        if (currentWineItem.ID.ToLower().Contains(query.ToLower()))
                        {
                            // Highlight the ID
                            HighlighterPrint(currentWineItem.ID);
                            Console.WriteLine(", " + currentWineItem.Description + ", " + currentWineItem.Pack);
                            resultsFound = true;
                        }
                    }
                    if (numberSelection == 2 || numberSelection == 4)
                    {
                        if (currentWineItem.Description.ToLower().Contains(query.ToLower()))
                        {
                            Console.Write(currentWineItem.ID + ", ");
                            HighlighterPrint(currentWineItem.Description);
                            Console.WriteLine(", " + currentWineItem.Pack);
                            resultsFound = true;
                        }
                    }
                    if (numberSelection == 3 || numberSelection == 4)
                    {
                        if (currentWineItem.Pack.ToLower().Contains(query.ToLower()))
                        {
                            Console.Write(currentWineItem.ID + ", " + currentWineItem.Description + ", ");
                            HighlighterPrint(currentWineItem.Pack);
                            Console.WriteLine();
                            resultsFound = true;
                        }
                    }
                }

                if (!resultsFound)
                {
                    Console.WriteLine("No results found.");
                }

                SetStatus(GeneratePressAnyKeyPhrase(), (Console.CursorTop + 1));
                Console.ReadKey(true);
            }
            else
            {
                PrintFatalError("The wine list must be loaded before searching through it!");
                Console.ReadKey(true);
            }
        }

        /* HIGHLIGHTS MESSAGE THEN PUTS IT BACK TO NORMAL */
        public static void HighlighterPrint(string phrase)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(phrase);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
