﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunForTheRoses
{
    //The PlainTextSaver class saves the horse bet as a Plain Text string if the user chooses to set their answer as a plain text.
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
