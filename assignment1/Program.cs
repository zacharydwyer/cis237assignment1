using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Flags.wineListLoaded = false;

            UserInterface.initializeConsoleWindow("CIS 237 | ASSIGNMENT 1 | ZACHARY DWYER", ConsoleColor.Black, ConsoleColor.White);
            UserInterface.printMainMenu();
        }
    }
}
