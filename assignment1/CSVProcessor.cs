using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class CSVProcessor
    {
        // This is assigned to an object in the constructor
        StreamReader CSVFileHandle;

        public CSVProcessor(string fileName)
        {
            try
            {
                /* ATTEMPT TO OPEN FILE */
                CSVFileHandle = new StreamReader(fileName);         // Try to open the file with the given fileName
            }
            catch (Exception e)
            {
                /* FILE OPEN FAILED */
                UserInterface.printFatalError("Couldn't open the file with the given filename " + "'" + fileName + "'. Crashing...");
                Console.ReadKey(true);
                throw new System.Exception("Was unable to open file with filename " + fileName);
            }
        }

        public void processFile()
        {
            /* COUNT THE NUMBER OF LINES IN THE FILE */
            string aLineOfText = null;                          // (Stores the line of text read in)
            int linesCount = 0;                                 // Counter to keep track of the number of lines in the CSV file.

            do
            {
                // HAVING ISSUES HERE //
                CSVFileHandle.ReadLine();
                Console.WriteLine("A line was read.");
                
                if (CSVFileHandle.ReadLine() != null)           // If we read a line and it didn't equal null
                {
                    linesCount++;                               // Add 1 to line count
                }
            } while (aLineOfText != null);

            CSVFileHandle.BaseStream.Position = 0;              // Reset StreamReader position
            CSVFileHandle.DiscardBufferedData();                // Discard buffered data

            /* CREATE WINEITEMLIST NOW THAT WE KNOW HOW MANY LINES THERE ARE */
            Globals.wineItemList = new WineItemList(linesCount);

            /* CREATE A WINE ITEM FOR EVERY RECORD IN THE CSV FILE AND STORE IT IN THE WINE ITEM LIST*/
            int wineItemsMade = 0;                  // Keeps track of number of wine items made

            string[] fields = new string[3];        // Holds the three fields per record

            do
            {
                string currentRecord = CSVFileHandle.ReadLine();                    // Read one record.
                fields = currentRecord.Split(',');                                  // Split that record into three different strings, delimited by a comma
                Globals.wineItemList.Add(new WineItem(fields[0], fields[1], fields[2]));    // Use those three strings to create a wine item and then add it to the wineItemList

            } while (wineItemsMade < linesCount);                                   // Do this for however many lines there are in the CSV file

            Globals.wineListLoaded = true;
        }

        private WineItem makeWineItem(string id, string description, string pack)
        {
            return new WineItem(id, description, pack);
        }
    }
}
