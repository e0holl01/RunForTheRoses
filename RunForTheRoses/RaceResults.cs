using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunForTheRoses
{
    public class RootObject
    {
        public RaceResults[] RaceResults { get; set; }
    }

   public class RaceResults
    {
        public DateTime Date { get; set; }
        public string Race { get; set; }
        public string Win { get; set; }
        public string Place { get; set; }
        public string Show { get; set; }
        public string Fourth { get; set; }

        internal void Add(string[] values)
        {
            throw new NotImplementedException();
        }
    }
}
