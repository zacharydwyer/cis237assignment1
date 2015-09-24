using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    static class Globals
    {
        /* FLAGS */
        public static bool wineListLoaded = false;                              // Is the wine list already loaded?

        /* VARIABLES */
        public static WineItemList wineItemList;
        public static int defaultStatusLineStart = 21;                          // The default line to start drawing the status section
        public static string fileName = "../../../datafiles/WineList.csv";      // File name of wine list csv 

        /* DATA */
        public static string[] mainMenuChoices = {                              // Menu choices - used in printing main menu 
                                                      "Load wine list",
                                                      "Print wine list",
                                                      "Search wine list",
                                                      "Add new wine item to list",
                                                      "Exit program"
                                                  };
    }
}
