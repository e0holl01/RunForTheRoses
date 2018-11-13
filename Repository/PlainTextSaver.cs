using System;
using System.IO;
using System.Linq;
using RunForTheRoses.Models;

namespace RunForTheRoses
{
    //The PlainTextSaver class saves the horse bet as a Plain Text string if the user chooses to set their answer as a plain text.
    class PlainTextSaver : Saver<HorseBet>
    {
        public PlainTextSaver(string path) : base(path)
        {
        }

        //saves as plain text
        public override void Save(HorseBet obj)
        {
            File.WriteAllText(Path, obj.ToString());
        }

        //deserializes plain text
        public override HorseBet Load()
        {
            var text = File.ReadAllText(Path);
            text.Split(',');
            var Names = text.Split(',');
            return new HorseBet
            {
                HorseBetPick = Names.Last(),
                UserName = Names.First()
            };
            
        }

    }
}