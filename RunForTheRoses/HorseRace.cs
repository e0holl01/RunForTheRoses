using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunForTheRoses //this is from the json classes
{
    public class RootObject //represents Json file
    {
        public HorseRace[] HorseRace { get; set; }
    }

   public class HorseRace
    {
        public string Track { get; set; }
        public DateTime? Date { get; set; } //? makes null value - Date has some null values in file
        public string Race { get; set; }
        public string Win { get; set; }
        public string Place { get; set; }
        public string Show { get; set; }
        public string Fourth { get; set; }

     
    }
}
