using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    // Class that holds a collection of WineItems that can be added to and retrieved.
    class WineItemList
    {
        private WineItem[] wineItems;           // This is where WineItems are stored

        private int nextArrayPosition = 0;      // Marks the next address of the wineItems array to put a new WineItem; incremented every time one is added

        // When this list is created, before being instantiated it needs to know how big the list is
        public WineItemList(int numberOfItems)
        {
            // Throw an exception if the amount is less than 1 (Arrays cannot have 0 size)
            if (numberOfItems < 1)
            {
                throw new System.ArgumentException("Parameter cannot be less than 1");
            }
            else
            {
                wineItems = new WineItem[numberOfItems];
            }
        }

        // This is the method of which you add WineItems to the list
        public void Add(WineItem wineItem) {

            // If this item won't fit in the array, throw an exception.
            // Example, if we're trying to fit a WineItem into position 12, but there's only 11 spaces in the wineItems array, throw an exception
            // (-1 on the wineItems.Length value since its maximum index is 1 less than its length)
            if (nextArrayPosition > (wineItems.Length - 1))
            {
                throw new System.Exception("The list is full.");
            }
            else
            {
                wineItems[nextArrayPosition] = wineItem;        // Add the given WineItem to the wineItems array
                nextArrayPosition++;                            // Increment the array so it's ready for the next time a WineItem is made
            }
        }

        // Return the WineItem list
        public WineItem[] List()
        {
            return this.wineItems;
        } 
    }
}
