using Newtonsoft.Json;
using System.IO;

namespace RunForTheRoses
{

    //The JsonSaver class saves the horse bet as a Json array if the user chooses to set their answer as a Json value.
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