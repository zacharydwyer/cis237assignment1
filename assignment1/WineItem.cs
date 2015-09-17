using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    // Each instance of this class represents/mirrors one record in the WineList.csv file.
    class WineItem
    {
        // All of these values are obtained from the WineList.csv file. They are all alphanumeric.
        private string id, description, pack;                       

        // Default constructor (required for assignment)
        public WineItem()
        {

        }

        // 3 parameter constructor - accepts all of WineItem's necessary attributes 
        public WineItem(string id, string description, string pack)
        {
            // Give this instance of WineItem the given values.
            this.id = id;
            this.description = description;
            this.pack = pack;
        }

        public string ToString()
        {
            
        }
    }
}
