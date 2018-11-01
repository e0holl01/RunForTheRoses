using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunForTheRoses
{
    class PlainTextSaver : Saver<HorseBet>
    {
        public PlainTextSaver(string path) : base(path)
        {
        }

        public override void Save(HorseBet obj)
        {
            File.WriteAllText(Path, obj.ToString());
        }
    }
}
