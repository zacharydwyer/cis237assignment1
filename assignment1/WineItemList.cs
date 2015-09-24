using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;           // For Debugging

namespace assignment1
{
    class WineItemList
    {
        private WineItem[] wineItems;           
        private int nextArrayPosition = 0;      // Where to put the next WineItem when added

        public WineItemList(int initialNumberOfItems)  // When this list is created, before being instantiated it needs to know how big the list is
        {
            if (initialNumberOfItems < 1)              // Throw an exception if the declared array size is less than 1 (Arrays cannot have 0 size)
            {
                throw new System.ArgumentException("Parameter cannot be less than 1");
            }
            else
            {
                wineItems = new WineItem[initialNumberOfItems];
                Debug.WriteLine("WINEITEMLIST: A WineItemList with " + wineItems.Length + " items was created.");
            }
        }

        /* ADD WINE ITEM TO THE LIST */
        public void Add(WineItem wineItem) {

            // If this item won't fit in the array, throw an exception.
            // Example, if we're trying to fit a WineItem into position 12, but there's only 11 spaces in the wineItems array, throw an exception
            // (-1 on the wineItems.Length value since its maximum index is 1 less than its length)

            if (nextArrayPosition > (wineItems.Length - 1))     // Is the next array position more than the last index of the wineItems array?
            {
                // Make the list larger
                WineItem[] newWineItemList = new WineItem[(wineItems.Length + 1)];                  // Make a wineItemList the size of the old one, but one more larger.

                for (int index = 0; index < wineItems.Length; index++) {                            // Copy all of the wineItems into the new wineItems array
                    newWineItemList[index] = wineItems[index];
                }

                wineItems = newWineItemList;                                                        // Give the old wineItems array a new, bigger wineItemList
            }

            wineItems[nextArrayPosition] = wineItem;        // Add the given WineItem to the wineItems array
            nextArrayPosition++;                            // Increment the array so it's ready for the next time a WineItem is added
            Debug.WriteLine("WineItem added: " + wineItem.ToString());
        }

        /* GET THE LIST */
        public WineItem[] GetList()
        {
            return this.wineItems;
        } 
    }
}
