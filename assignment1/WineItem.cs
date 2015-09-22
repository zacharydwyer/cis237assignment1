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
        // Each WineItem has an ID, a Descrption, and a Pack property
        // (Using shorthand auto-implemented getters and setters for these properties)
        public string ID { get; set; }
        public string Description { get; set; }
        public string Pack { get; set; }
    
        // Default constructor (required for assignment), should not actually be used.
        public WineItem()
        {
            throw new System.Exception("Use my overloaded version instead.");
        }

        // 3 parameter constructor - accepts all of WineItem's necessary attributes 
        public WineItem(string id, string description, string pack)
        {
            // Give this instance of WineItem the given values.
            this.ID = id;
            this.Description = description;
            this.Pack = pack;
        }

        // Returns this WineItem's ID, Description and Pack, all comma separated
        public override string ToString()
        {
            return this.ID + ", " + this.Description + ", " + this.Pack;
        }
    }
}
