using System.IO;
using Newtonsoft.Json;
using RunForTheRoses.Models;

namespace RunForTheRoses.Repository
{

    //The JsonSaver class saves the horse bet as a Json array if the user chooses to set their answer as a Json value.
    class JsonRepository : Repository<HorseBet>
    {
        public JsonRepository(string path) : base(path + ".json")
        {
        }

        //saves as Json array
        public override void Save(HorseBet obj)
        {
            var data = JsonConvert.SerializeObject(obj);
            File.WriteAllText(Path, data);
        }

        //deserializes json
        public override HorseBet Load()
        {
            if (!FileExists())
                return null;

            var text = File.ReadAllText(Path);
            return JsonConvert.DeserializeObject<HorseBet>(text);
        }
    }
}
