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

        //saves as Json array
        public override void Save(HorseBet obj)
        {
            var data = JsonConvert.SerializeObject(obj);
            File.WriteAllText(Path, data);
        }

        //deserializes json
        public override HorseBet Load(string text)
        {
            return JsonConvert.DeserializeObject<HorseBet>(text);
        }
    }
}
