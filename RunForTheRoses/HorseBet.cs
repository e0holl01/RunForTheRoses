using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunForTheRoses
{
    class HorseBet
    {
        public string UserName { get; set; }
        public string HorseBetPick { get; set; }
        public override string ToString()
        {
            return UserName + " bet " + HorseBetPick + " to win.";
        }
    }
}
