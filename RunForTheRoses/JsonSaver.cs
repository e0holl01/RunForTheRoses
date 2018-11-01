using Newtonsoft.Json;
using System.IO;

namespace RunForTheRoses
{
    class JsonSaver : Saver<HorseBet>
    {
        public JsonSaver(string path) : base(path)
        {
        }

        public override void Save(HorseBet obj)
        {
            var data = JsonConvert.SerializeObject(obj);
            File.WriteAllText(Path, data);
        }
    }
}
