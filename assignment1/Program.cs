using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Globals.wineListLoaded = false;     // Wine list has yet to be loaded.

            /* CREATE A CSV PROCESSOR */
            string fileName = "../../../datafiles/WineList.csv";
            Globals.myCSVProcessor = new CSVProcessor(fileName);

            /* INITIALIZE THE CONSOLE WINDOW */
            UserInterface.initializeConsoleWindow("CIS 237 | ASSIGNMENT 1 | ZACHARY DWYER", ConsoleColor.Black, ConsoleColor.White);

            /* START THE MAIN MENU */
            UserInterface.printMainMenu();

        }
    }
}
