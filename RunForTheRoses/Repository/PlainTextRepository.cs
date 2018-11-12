using System.IO;
using RunForTheRoses.Models;

namespace RunForTheRoses.Repository
{
    //The PlainTextSaver class saves the horse bet as a Plain Text string if the user chooses to set their answer as a plain text.
    class PlainTextRepository : Repository<HorseBet>
    {
        public PlainTextRepository(string path) : base(path + ".txt")
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
            if (!FileExists()) 
                return null;

            var names = File.ReadAllText(Path).Split(',');
            return new HorseBet(names[0], names[1]);
        }
    }
}