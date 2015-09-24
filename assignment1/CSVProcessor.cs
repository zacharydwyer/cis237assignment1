using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace assignment1
{
    static class CSVProcessor
    {
        /* FILL WINEITEMLIST WITH WINEITEM OBJECTS DERIVED FROM CSV FILE */
        public static void PopulateWineItemList()
        {
            UserInterface.ResetScreen();

            if (Globals.wineListLoaded)
            {
                Console.WriteLine(" Wine list already loaded!");
                UserInterface.SetStatus(UserInterface.GeneratePressAnyKeyPhrase());
                Console.ReadKey(true);
            }
            else
            {
                if (File.Exists(Globals.fileName))                                  // Does the file exist?
                {                 
                    Console.WriteLine(" Found the file.");

                    String[] arrayedFile = File.ReadAllLines(Globals.fileName);     // Read the whole file into an array

                    Console.WriteLine(" File read into array.");

                    Globals.wineItemList = new WineItemList(100);                   // Give it 100 size for now; it dynamically expands so we don't have to worry about size

                    Console.WriteLine(" WineItemList size allocated.");
                    Console.WriteLine(" Adding records...");

                    String[] threeParameters;                                       // Holds the three elements of the record, retrieved from Split

                    // For every record in the array, 
                    foreach (string record in arrayedFile)
                    {
                        threeParameters = record.Split(',');                          // Give the threeParameters array three fields to work with
                        Globals.wineItemList.Add(makeWineItem(threeParameters[0], threeParameters[1], threeParameters[2]));     // Make a wine item out of those parameters then add it to wineItemList
                        UserInterface.ClearCurrentConsoleLine();
                    }

                    Globals.wineListLoaded = true;
                    Console.WriteLine(" Done adding records to list.");

                }
                else
                {
                    Debug.WriteLine("Couldn't find the file.");
                    UserInterface.PrintFatalError("Could not find file with file name " + Globals.fileName + ". Shutting down...");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                }
            }

            
        }
        
        /* GENERATE WINE ITEM USING GIVEN PROPERTIES (PARAMETERS) */
        private static WineItem makeWineItem(string id, string description, string pack)
        {
            return new WineItem(id, description, pack);
        }
    }
}
