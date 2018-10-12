using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunForTheRoses
{
    public class RootObject
    {
        public HorseRace[] HorseRace { get; set; }
    }

   public class HorseRace
    {
        public string Track { get; set; }
        public DateTime? Date { get; set; }
        public string Race { get; set; }
        public string Win { get; set; }
        public string Place { get; set; }
        public string Show { get; set; }
        public string Fourth { get; set; }

     
    }
}
